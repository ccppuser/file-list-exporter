using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace FileListExporter
{
	/// <summary>
	/// Manage a TreeView for showing hierarchies of folders and files
	/// </summary>
	public class FolderTreeViewManager
	{
		protected TreeView _tvwFolders = null;

		public FolderTreeViewManager(TreeView tvwFolders)
		{
			_tvwFolders = tvwFolders;
		}

		/// <summary>
		/// Show folders and files hierarchically on the TreeView
		/// </summary>
		/// <param name="rootFolders"></param>
		public void SetFileHierarchies(FileHierarchies fileHierarchies)
		{
			SortedDictionary<string, Folder> _rootFolders = fileHierarchies.GetRootFolders();

			if (_rootFolders == null)
			{
				return;
			}

			// remove all existing nodes in tree view
			_tvwFolders.Nodes.Clear();

			foreach (var pair in _rootFolders)
			{
				Folder rootFolder = pair.Value;

				TreeNode rootNode = new TreeNode(rootFolder.Name);
				rootNode.Tag = rootFolder;  // bind a folder information to the node

				SetCheckState(rootNode, rootFolder.CheckState);

				ConstructTreeRecursively(rootFolder, rootNode);

				_tvwFolders.Nodes.Add(rootNode);
			}
		}

		/// <summary>
		/// Construct folder tree recursively
		/// </summary>
		/// <param name="currentFolder"></param>
		/// <param name="currentNode"></param>
		protected void ConstructTreeRecursively(Folder currentFolder, TreeNode currentNode)
		{
			foreach (var pair in currentFolder.SubFolders)
			{
				Folder subFolder = pair.Value;
				string subFolderName = pair.Value.Name;

				TreeNode subNode = new TreeNode(subFolderName);
				subNode.Tag = subFolder;    // bind a folder information to the node

				SetCheckState(subNode, subFolder.CheckState);

				currentNode.Nodes.Add(subNode);

				ConstructTreeRecursively(subFolder, subNode);
			}
		}

		/// <summary>
		/// Update check states of all related folders
		/// </summary>
		/// <param name="node"></param>
		public void UpdateCheckStates(TreeNode node)
		{
			// 1. unchecked -> checked:
			//		1.1. all sub-folders are also checked and their images are set as "Selected.png"
			//		1.2. if all siblings are checked, parent folder's image is set as "Selected.png", recursively
			//		1.3. if partial siblings are checked, parent folder's image is set as "Partial.png", recursively
			//
			// 2. checked -> unchecked:
			//		2.1. ask user if they really want to uncheck all sub-folders
			//			2.1.1. if they want: uncheck all sub-folders
			//			2.1.2. if they don't want: cancle the unchecking
			//		2.2. if all siblings are unchecked, parent folder's image is set as "Unselected.png", recursively
			//		2.3. if partial siblings are unchecked, parent folder's image is set as "Partial.png", recursively

			// 1. unchecked -> checked:
			if (node.Checked)
			{
				//		1.1. all sub-folders are also checked and their images are set as "Selected.png"
				CheckAllSubNodesRecursively(node);

				//		1.2. if all siblings are checked, parent folder's image is set as "Selected.png", recursively
				//		1.3. if partial siblings are checked, parent folder's image is set as "Partial.png", recursively
				CheckParentsRecursively(node.Parent);
			}
			// 2. checked -> unchecked:
			else
			{
				DialogResult result = DialogResult.Yes;

				// if the node has children:
				if (node.Nodes != null && node.Nodes.Count > 0)
				{
					//		2.1. ask user if they really want to uncheck all sub-folders
					result = MessageBox.Show("All sub-folders and files in them will be unchecked.\nDo you really want to continue?", "Confirm", MessageBoxButtons.YesNo);
				}

				//			2.1.1. if they want: uncheck all sub-folders
				if (result == DialogResult.Yes)
				{
					UncheckAllSubNodesRecursively(node);

					//		2.2. if all siblings are unchecked, parent folder's image is set as "Unselected.png", recursively
					//		2.3. if partial siblings are unchecked, parent folder's image is set as "Partial.png", recursively
					UncheckParentsRecursively(node.Parent);
				}
				//			2.1.2. if they don't want: cancle the unchecking
				else
				{
					node.Checked = true;
				}
			}
		}

		/// <summary>
		/// Check all check buttons of child nodes in parentNode recursively
		/// </summary>
		/// <param name="parentNode"></param>
		protected void CheckAllSubNodesRecursively(TreeNode parentNode)
		{
			SetCheckState(parentNode, CheckState.Checked);

			foreach (TreeNode subNode in parentNode.Nodes)
			{
				CheckAllSubNodesRecursively(subNode);
			}
		}

		/// <summary>
		/// Uncheck all check buttons of child nodes in parentNode recursively
		/// </summary>
		/// <param name="parentNode"></param>
		protected void UncheckAllSubNodesRecursively(TreeNode parentNode)
		{
			SetCheckState(parentNode, CheckState.Unchecked);

			foreach (TreeNode subNode in parentNode.Nodes)
			{
				UncheckAllSubNodesRecursively(subNode);
			}
		}

		/// <summary>
		/// Check all parents recursively
		/// </summary>
		/// <param name="parentNode"></param>
		protected void CheckParentsRecursively(TreeNode parentNode)
		{
			if (parentNode != null)
			{
				bool allSiblingsAreSelected = true;
				foreach (TreeNode siblingNode in parentNode.Nodes)
				{
					if (siblingNode.ImageIndex != (int)CheckState.Checked)// SelectStates.Selected)
					{
						allSiblingsAreSelected = false;
						break;
					}
				}

				bool allFilesOfParentAreSelected = true;
				Folder folder = parentNode.Tag as Folder;
				foreach (File file in folder.Files)
				{
					if (!file.Checked)
					{
						allFilesOfParentAreSelected = false;
						break;
					}
				}

				//		1.2. if all siblings are checked, parent folder's image is set as "Selected.png", recursively
				if (allSiblingsAreSelected && allFilesOfParentAreSelected)
				{
					SetCheckState(parentNode, CheckState.Checked);
				}
				//		1.3. if partial siblings are checked, parent folder's image is set as "Partial.png", recursively
				else
				{
					SetCheckState(parentNode, CheckState.Indeterminate);
				}

				CheckParentsRecursively(parentNode.Parent);
			}
		}

		/// <summary>
		/// Uncheck all parents recursively
		/// </summary>
		/// <param name="parentNode"></param>
		protected void UncheckParentsRecursively(TreeNode parentNode)
		{
			if (parentNode != null)
			{
				bool allSiblingsAreUnselected = true;
				foreach (TreeNode siblingNode in parentNode.Nodes)
				{
					if (siblingNode.ImageIndex != (int)CheckState.Unchecked)
					{
						allSiblingsAreUnselected = false;
						break;
					}
				}

				bool allFilesOfParentAreUnselected = true;
				Folder folder = parentNode.Tag as Folder;
				foreach (File file in folder.Files)
				{
					if (file.Checked)
					{
						allFilesOfParentAreUnselected = false;
						break;
					}
				}

				//		2.2. if all siblings are unchecked, parent folder's image is set as "Unselected.png", recursively
				if (allSiblingsAreUnselected && allFilesOfParentAreUnselected)
				{
					SetCheckState(parentNode, CheckState.Unchecked);
				}
				//		2.3. if partial siblings are unchecked, parent folder's image is set as "Partial.png", recursively
				else
				{
					SetCheckState(parentNode, CheckState.Indeterminate);
				}

				UncheckParentsRecursively(parentNode.Parent);
			}
		}

		/// <summary>
		/// Set check state of a node
		/// </summary>
		/// <param name="node"></param>
		/// <param name="checkState"></param>
		protected void SetCheckState(TreeNode node, CheckState checkState)
		{
			node.ImageIndex = (int)checkState;
			node.SelectedImageIndex = (int)checkState;

			if (checkState == CheckState.Checked)
			{
				node.Checked = true;

				// all files in the node are also checked
				CheckAllFiles(node, true);
			}
			else if (checkState == CheckState.Indeterminate)
			{
				node.Checked = false;
			}
			else
			{
				node.Checked = false;

				// all files in the node are also checked
				CheckAllFiles(node, false);
			}

			Folder folder = node.Tag as Folder;
			folder.CheckState = checkState;
		}

		/// <summary>
		/// Check all files in the node
		/// </summary>
		/// <param name="node"></param>
		/// <param name="check"></param>
		protected void CheckAllFiles(TreeNode node, bool check)
		{
			Folder folder = node.Tag as Folder;

			foreach (File file in folder.Files)
			{
				file.Checked = check;
			}
		}

		/// <summary>
		/// Open Explorer.exe which locates the path of the node
		/// </summary>
		/// <param name="node"></param>
		public void OpenFolder(TreeNode node)
		{
			Folder folder = node.Tag as Folder;

			// open the selected folder only if the path exists
			if (Directory.Exists(folder.Path))
			{
				Process.Start(folder.Path);
			}
			else
			{
				MessageBox.Show("The folder is not existed: " + folder.Path);
			}
		}

		/// <summary>
		/// Return a path of the node
		/// </summary>
		/// <param name="node"></param>
		/// <returns>A full path of the node</returns>
		public string GetPath(TreeNode node)
		{
			Folder folder = node.Tag as Folder;

			// show path of the selected folder
			return folder.Path;
		}

		/// <summary>
		/// Update check states of all parents folders
		/// </summary>
		/// <param name="parentNode"></param>
		/// <param name="isChecked"></param>
		public void UpdateParentCheckStates(TreeNode parentNode, bool isChecked)
		{
			if (isChecked)
			{
				CheckParentsRecursively(parentNode);
			}
			else
			{
				UncheckParentsRecursively(parentNode);
			}
		}
	}
}
