using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileListExporter
{
	/// <summary>
	/// Manage a ListView for showing files in a folder
	/// </summary>
	public class FileListViewManager
	{
		protected ListView _lvwFiles = null;
		protected ColumnHeader _colName = null;
		protected ColumnHeader _colType = null;
		protected ColumnHeader _colSize = null;
		protected ListViewSorter _listViewSorter = null;    // sorter for lvwFiles

		public FileListViewManager(ListView lvwFiles, ColumnHeader colName, ColumnHeader colType, ColumnHeader colSize)
		{
			_lvwFiles = lvwFiles;
			_colName = colName;
			_colType = colType;
			_colSize = colSize;

			// initialize sorter for lvwFiles
			SortingMethods.CurrentSortingMethod = SortingMethods.None;
			colName.Text = SortingMethods.Name;
			colType.Text = SortingMethods.Type;
			colSize.Text = SortingMethods.Size;
			_listViewSorter = new ListViewSorter(0, SortOrder.Ascending);

			lvwFiles.ListViewItemSorter = _listViewSorter;   // set the sorter to lvwFiles
		}

		/// <summary>
		/// Update check states of all files
		/// </summary>
		/// <returns>CheckState.Checked, if all items are checked, CheckState.Unchecked, if all items are unchecked, or CheckState.Intermediate, if some items are checked</returns>
		public CheckState UpdateCheckStates()
		{
			CheckState checkState = CheckState.Unchecked;

			if (_lvwFiles.Items != null && _lvwFiles.Items.Count > 0)
			{
				bool allItemsAreChecked = true;

				foreach (ListViewItem item in _lvwFiles.Items)
				{
					File file = item.Tag as File;

					item.Checked = file.Checked;

					if (item.Checked)
					{
						checkState = CheckState.Indeterminate;
					}
					else
					{
						allItemsAreChecked = false;
					}
				}

				if (allItemsAreChecked)
				{
					checkState = CheckState.Checked;
				}
			}

			return checkState;
		}

		/// <summary>
		/// Return whether all, some, or none of files are checked
		/// </summary>
		/// <returns>CheckState.Checked, if all items are checked, CheckState.Unchecked, if all items are unchecked, or CheckState.Intermediate, if some items are checked</returns>
		public CheckState IsAllItemsChecked()
		{
			CheckState checkState = CheckState.Unchecked;

			if (_lvwFiles.Items != null && _lvwFiles.Items.Count > 0)
			{
				bool allItemsAreChecked = true;

				foreach (ListViewItem item in _lvwFiles.Items)
				{
					if (item.Checked)
					{
						checkState = CheckState.Indeterminate;
					}
					else
					{
						allItemsAreChecked = false;
					}
				}

				if (allItemsAreChecked)
				{
					checkState = CheckState.Checked;
				}
			}

			return checkState;
		}

		/// <summary>
		/// Set check state of an item and the corresponding file
		/// </summary>
		/// <param name="item"></param>
		/// <param name="check"></param>
		protected void SetCheckState(ListViewItem item, bool check)
		{
			item.Checked = check;

			File file = item.Tag as File;
			file.Checked = check;
		}

		/// <summary>
		/// Set check states of all items and the corresponding files
		/// </summary>
		/// <param name="check"></param>
		public void SetAllCheckStates(bool check)
		{
			foreach (ListViewItem item in _lvwFiles.Items)
			{
				SetCheckState(item, check);
			}
		}

		/// <summary>
		/// Set file items in the folder node
		/// </summary>
		/// <param name="node"></param>
		/// <returns>True, if the node has one or more files</returns>
		public bool SetItems(TreeNode node)
		{
			Folder folder = node.Tag as Folder;

			List<File> files = folder.Files;

			// remove all existing files
			_lvwFiles.Items.Clear();

			bool hasFiles = true;

			if (files == null || files.Count == 0)
			{
				hasFiles = false;
			}
			else
			{
				foreach (File file in files)
				{
					string[] subItems = new string[] { file.Name, file.Extention, file.Size.ToString() };
					ListViewItem item = new ListViewItem(subItems);
					item.SubItems[2].Tag = file.Size;
					item.Tag = file;
					item.Checked = file.Checked;

					_lvwFiles.Items.Add(item);
				}
			}

			return hasFiles;
		}

		/// <summary>
		/// Sort file list
		/// </summary>
		/// <param name="column"></param>
		public void Sort(ColumnHeader column)
		{
			SortOrder sortOrder = AnalyzeSortingOrder(column);

			if (sortOrder == SortOrder.None)
			{
				MessageBox.Show("?");
			}

			_listViewSorter.SetSortingMethod(column.Index, sortOrder);

			_lvwFiles.Sort();
		}

		/// <summary>
		/// Figure out sorting order using the name of column
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		protected SortOrder AnalyzeSortingOrder(ColumnHeader column)
		{
			SortOrder sortOrder = SortOrder.None;

			if (column == _colName)
			{
				if (column.Text == SortingMethods.Name)
				{
					column.Text = SortingMethods.Name_Ascending;
					sortOrder = SortOrder.Ascending;
				}
				else if (column.Text == SortingMethods.Name_Ascending)
				{
					column.Text = SortingMethods.Name_Descending;
					sortOrder = SortOrder.Descending;
				}
				else
				{
					column.Text = SortingMethods.Name_Ascending;
					sortOrder = SortOrder.Ascending;
				}

				_colType.Text = SortingMethods.Type;
				_colSize.Text = SortingMethods.Size;
			}
			else if (column == _colType)
			{
				if (column.Text == SortingMethods.Type)
				{
					column.Text = SortingMethods.Type_Ascending;
					sortOrder = SortOrder.Ascending;
				}
				else if (column.Text == SortingMethods.Type_Ascending)
				{
					column.Text = SortingMethods.Type_Descending;
					sortOrder = SortOrder.Descending;
				}
				else
				{
					column.Text = SortingMethods.Type_Ascending;
					sortOrder = SortOrder.Ascending;
				}

				_colName.Text = SortingMethods.Name;
				_colSize.Text = SortingMethods.Size;
			}
			else
			{
				if (column.Text == SortingMethods.Size)
				{
					column.Text = SortingMethods.Size_Ascending;
					sortOrder = SortOrder.Ascending;
				}
				else if (column.Text == SortingMethods.Size_Ascending)
				{
					column.Text = SortingMethods.Size_Descending;
					sortOrder = SortOrder.Descending;
				}
				else
				{
					column.Text = SortingMethods.Size_Ascending;
					sortOrder = SortOrder.Ascending;
				}

				_colName.Text = SortingMethods.Name;
				_colType.Text = SortingMethods.Type;
			}

			return sortOrder;
		}

		/// <summary>
		/// Update check state of the corresponding file of item
		/// </summary>
		/// <param name="item"></param>
		public void UpdateItemCheckState(ListViewItem item)
		{
			File file = item.Tag as File;
			file.Checked = item.Checked;
		}
	}
}
