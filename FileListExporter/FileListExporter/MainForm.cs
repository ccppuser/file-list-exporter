using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace FileListExporter
{
	/// <summary>
	/// MainForm of the program
	/// </summary>
	public partial class MainForm : Form
	{
		protected const string _txtExtention = "txt";
		protected const string _fileListExtention = "filelist";

		protected string _defaultMainFormText;

		protected FileHierarchies _fileHierarchies = null;

		protected SpaceSnifferFile spaceSnifferFile = new SpaceSnifferFile();
		protected FileListExporterFile fileListExporterFile = new FileListExporterFile();
		protected SelectedFileExporter exporter = new SelectedFileExporter();

		protected FolderTreeViewManager tvwFoldersManager = null;
		protected FileListViewManager lvwFilesManager = null;

		protected bool _isFileSaved = true;

		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Initialize this program
		/// </summary>
		/// <param name="e"></param>
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			EventHandlerManager.AddEventHandler(tvwFolders, "AfterCheck", this, "tvwFolders_AfterCheck");
			EventHandlerManager.AddEventHandler(tvwFolders, "AfterSelect", this, "tvwFolders_AfterSelect");
			EventHandlerManager.AddEventHandler(lvwFiles, "ItemChecked", this, "lvwFiles_ItemChecked");
			EventHandlerManager.AddEventHandler(chkSelectAll, "CheckedChanged", this, "chkSelectAll_CheckedChanged");

			tvwFoldersManager = new FolderTreeViewManager(tvwFolders);
			lvwFilesManager = new FileListViewManager(lvwFiles, colName, colType, colSize);

			// initialize the title message of the form
			_defaultMainFormText = Text;
			SetMessageToMainFormText("");

			// initialize the status strip bar
			lblStatusStrip.Text = "";

			// restrict file types that this app can open
			dlgOpenFile.Filter = "SpaceSniffer export file|*." + _txtExtention + "|FileListExporter File|*." + _fileListExtention;

			// show file open dialog
			DialogResult result = dlgOpenFile.ShowDialog();

			// if a file is selected:
			if (result == DialogResult.OK)
			{
				fileListExporterFile.SetFilePath(dlgOpenFile.FileName);

				// if a txt file(SpaceSniffer export filer) is selected:
				if (fileListExporterFile.FileExtention == _txtExtention)
				{
					SetStatusLoading(dlgOpenFile.FileName);

					// try to load the selected txt file
					_fileHierarchies = spaceSnifferFile.LoadTxtFile(dlgOpenFile.FileName);

					// if the file hierarchies are successfully loaded:
					if (_fileHierarchies != null)
					{
						SetStatusLoaded(dlgOpenFile.FileName);

						// show FileListExporter file save dialog
						if (ShowSaveFileDialog(fileListExporterFile.FileDirectory, fileListExporterFile.FileNameBody))
						{
							SetStatusSaving(fileListExporterFile.FilePath);

							fileListExporterFile.SaveFile(_fileHierarchies.GetRootFolders());

							SetMessageToMainFormText(fileListExporterFile.FilePath);

							SetStatusSaved(fileListExporterFile.FilePath);

							SetStatusFoldersLoading();

							EventHandlerManager.PauseAllEventHandlers();
							{
								tvwFoldersManager.SetFileHierarchies(_fileHierarchies);
							}
							EventHandlerManager.ResumeAllEventHandlers();

							SetStatusFoldersLoaded();
						}
						// if a user gave up to proceed:
						else
						{
							// close the program
							Dispose();
						}
					}
					else
					{
						// close the program
						Dispose();
					}
				}
				// if a FileListExporter file is selected:
				else if (fileListExporterFile.FileExtention == _fileListExtention)
				{
					fileListExporterFile.SetFilePath(dlgOpenFile.FileName);

					SetStatusLoading(fileListExporterFile.FilePath);

					_fileHierarchies = fileListExporterFile.LoadFile();

					// if the file hierarchies are successfully loaded:
					if (_fileHierarchies != null)
					{
						SetStatusLoaded(fileListExporterFile.FilePath);

						SetMessageToMainFormText(fileListExporterFile.FilePath);

						tvwFoldersManager.SetFileHierarchies(_fileHierarchies);
					}
					else
					{
						// close the program
						Dispose();
					}
				}
				else
				{
					// close the program
					MessageBox.Show("Please select a file with these types only: " + dlgOpenFile.Filter);
					Dispose();
				}
			}
			// if canceled:
			else
			{
				// close the app
				Dispose();
			}
		}

		/// <summary>
		/// Set a message after the title of the program
		/// </summary>
		/// <param name="message"></param>
		protected void SetMessageToMainFormText(string message)
		{
			if (message == null || message == "")
			{
				Text = _defaultMainFormText;
			}
			else
			{
				Text = _defaultMainFormText + " - " + message;
			}
		}

		/// <summary>
		/// Show dlgSaveFile dialog
		/// </summary>
		/// <param name="initialDirectory">InitialDirectory for dlgSaveFile</param>
		/// <param name="initialFileNameBody">initial file name without extention for dlgSaveFile</param>
		/// <returns>True, if a user decided the file name</returns>
		protected bool ShowSaveFileDialog(string initialDirectory, string initialFileNameBody)
		{
			string saveFileName = initialFileNameBody + '.' + _fileListExtention;

			dlgSaveFile.Filter = "FileListExporter File|*." + _fileListExtention;
			dlgSaveFile.DefaultExt = _fileListExtention;
			dlgSaveFile.InitialDirectory = initialDirectory;	// set InitialDirectory to the same directory where the loaded file exists
			dlgSaveFile.FileName = saveFileName;

			// show file save dialog
			DialogResult result = dlgSaveFile.ShowDialog();

			// if a file is selected:
			if (result == DialogResult.OK)
			{
				fileListExporterFile.SetFilePath(dlgSaveFile.FileName);

				return true;
			}
			// if canceled:
			else
			{
				fileListExporterFile.SetFilePath("");

				return false;
			}
		}

		// will be called whenever a user check a check button of a folder in tvwFolders
		protected void tvwFolders_AfterCheck(object sender, TreeViewEventArgs e)
		{
			SetStatusModified();

			EventHandlerManager.PauseAllEventHandlers();
			{
				tvwFoldersManager.UpdateCheckStates(e.Node);

				CheckState checkState = lvwFilesManager.UpdateCheckStates();

				chkSelectAll.CheckState = checkState;
			}
			EventHandlerManager.ResumeAllEventHandlers();
		}

		protected void btnExpandAllFolders_Click(object sender, EventArgs e)
		{
			tvwFolders.ExpandAll();
		}

		protected void btnShrinkAllFolders_Click(object sender, EventArgs e)
		{
			tvwFolders.CollapseAll();
		}

		protected void btnOpenSelectedFolder_Click(object sender, EventArgs e)
		{
			if (tvwFolders.SelectedNode == null)
			{
				MessageBox.Show("Please select a folder to open!");
			}
			else
			{
				tvwFoldersManager.OpenFolder(tvwFolders.SelectedNode);
			}
		}

		protected void tvwFolders_AfterSelect(object sender, TreeViewEventArgs e)
		{
			EventHandlerManager.PauseAllEventHandlers();
			{
				// show file list in the selected folder
				string path = tvwFoldersManager.GetPath(e.Node);

				txtPath.Text = path;    // show the path of selected folder

				bool hasFiles = lvwFilesManager.SetItems(e.Node);	// show files on lvwFiles

				splitContainer1.Panel2.Enabled = hasFiles;  // lvwFiles and chkSelectAll are enabled only one of more files are existed in the selected folder

				CheckState checkState = lvwFilesManager.IsAllItemsChecked();

				chkSelectAll.CheckState = checkState;
			}
			EventHandlerManager.ResumeAllEventHandlers();
		}

		protected void lvwFiles_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			lvwFilesManager.Sort(lvwFiles.Columns[e.Column]);
		}

		protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
		{
			SetStatusModified();

			EventHandlerManager.PauseAllEventHandlers();
			{
				if (chkSelectAll.CheckState != CheckState.Indeterminate)
				{
					lvwFilesManager.SetAllCheckStates(chkSelectAll.Checked);
				}

				tvwFoldersManager.UpdateParentCheckStates(tvwFolders.SelectedNode, chkSelectAll.Checked);
			}
			EventHandlerManager.ResumeAllEventHandlers();
		}

		protected void lvwFiles_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			SetStatusModified();

			EventHandlerManager.PauseAllEventHandlers();
			{
				lvwFilesManager.UpdateItemCheckState(e.Item);

				CheckState checkState = lvwFilesManager.IsAllItemsChecked();

				chkSelectAll.CheckState = checkState;

				tvwFoldersManager.UpdateParentCheckStates(tvwFolders.SelectedNode, e.Item.Checked);
			}
			EventHandlerManager.ResumeAllEventHandlers();
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			fileListExporterFile.SaveFile(_fileHierarchies.GetRootFolders());
		}

		protected void btnSaveAs_Click(object sender, EventArgs e)
		{
			if (ShowSaveFileDialog(fileListExporterFile.FileDirectory, fileListExporterFile.FileNameBody))
			{
				fileListExporterFile.SaveFile(_fileHierarchies.GetRootFolders());
			}
		}

		protected void btnExportForFastCopy_Click(object sender, EventArgs e)
		{
			string filePath;
			if (ShowSaveExportFileForFastCopyDialog(out filePath))
			{
				SetStatusSaving(filePath);

				exporter.Export(filePath, _fileHierarchies.GetRootFolders());

				SetStatusSaved(filePath);
			}
		}

		protected bool ShowSaveExportFileForFastCopyDialog(out string outFilePath)
		{
			dlgExportFile.Filter = "Txt file for FastCopy|*." + _txtExtention;
			dlgExportFile.DefaultExt = _txtExtention;
			dlgExportFile.InitialDirectory = fileListExporterFile.FileDirectory;
			dlgExportFile.FileName = "(ForFastCopy)" + fileListExporterFile.FileNameBody+ '.' + _txtExtention;

			// show file save dialog
			DialogResult result = dlgExportFile.ShowDialog();

			// if a file is selected:
			if (result == DialogResult.OK)
			{
				outFilePath = dlgExportFile.FileName;

				return true;
			}
			// if canceled:
			else
			{
				outFilePath = "";

				return false;
			}
		}

		protected void SetStatusModified()
		{
			_isFileSaved = false;

			lblStatusStrip.Text = "Modified...";
		}

		protected void SetStatusLoading(string fileName)
		{
			lblStatusStrip.Text = "Loading " + fileName + "...";
			Cursor.Current = Cursors.WaitCursor;
		}

		protected void SetStatusLoaded(string fileName)
		{
			lblStatusStrip.Text = fileName + " is loaded!";
			Cursor.Current = Cursors.Default;
		}

		protected void SetStatusFoldersLoading()
		{
			lblStatusStrip.Text = "Loading folders...";
			Cursor.Current = Cursors.WaitCursor;
		}

		protected void SetStatusFoldersLoaded()
		{
			lblStatusStrip.Text = "Folders are loaded!";
			Cursor.Current = Cursors.Default;
		}

		protected void SetStatusSaving(string fileName)
		{
			lblStatusStrip.Text = "Saving " + fileName + "...";
			Cursor.Current = Cursors.WaitCursor;
		}

		protected void SetStatusSaved(string fileName)
		{
			_isFileSaved = true;

			lblStatusStrip.Text = fileName + " is saved!";
			Cursor.Current = Cursors.Default;
		}

		protected void btnAbout_Click(object sender, EventArgs e)
		{
			AboutForm aboutForm = new AboutForm();
			aboutForm.ShowDialog();
		}

		protected void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!_isFileSaved)
			{
				DialogResult result = MessageBox.Show(
					text: "Will you save \"" + fileListExporterFile.FileNameBody+ '.' + _fileListExtention + "\" before closing?\n\nIf you click \"Yes\", the file will be saved before closing.\nIf you click \"No\", the program will be closed without saving the file.\nIf you click \"Cancel\", you can cancel closing the program.",
					caption: "",
					buttons: MessageBoxButtons.YesNoCancel,
					icon: MessageBoxIcon.Warning);

				if (result == DialogResult.Yes)
				{
					fileListExporterFile.SaveFile(_fileHierarchies.GetRootFolders());
				}
				else if (result == DialogResult.No)
				{
				}
				else
				{
					e.Cancel = true;
				}
			}
		}
	}
}
