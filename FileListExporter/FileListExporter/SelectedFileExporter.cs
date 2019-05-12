using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FileListExporter
{
	/// <summary>
	/// Export a txt file which contains selected folders and files
	/// </summary>
	public class SelectedFileExporter
	{
		/// <summary>
		/// Export selected folders and files to a txt file
		/// </summary>
		/// <param name="filePath">A full path of a txt file</param>
		/// <param name="rootFolders"></param>
		public void Export(string filePath, SortedDictionary<string, Folder> rootFolders)
		{
			using (StreamWriter writer = new StreamWriter(filePath))
			{
				foreach (var pair in rootFolders)
				{
					Folder folder = pair.Value;
					string accumulatedDirectory = folder.Name+ '\\';

					ExportFolderRecursively(writer, accumulatedDirectory, folder);
				}

				writer.Close();
			}
		}

		/// <summary>
		/// Export files and sub-folders recursively
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="accumulatedDirectory"></param>
		/// <param name="folder"></param>
		protected void ExportFolderRecursively(StreamWriter writer, string accumulatedDirectory, Folder folder)
		{
			// in this case, we don't need to descend anymore, because FastCopy will copy every folders and files under this folder
			if (folder.CheckState== CheckState.Checked)
			{
				writer.WriteLine(accumulatedDirectory);
			}
			// in this case, we export files and descend to all sub-folders
			else if (folder.CheckState== CheckState.Indeterminate)
			{
				foreach (File file in folder.Files)
				{
					if (file.Checked)
					{
						writer.WriteLine(accumulatedDirectory + file.Name);
					}
				}

				foreach (var pair in folder.SubFolders)
				{
					Folder subFolder = pair.Value;

					ExportFolderRecursively(writer, accumulatedDirectory + subFolder.Name+ '\\', subFolder);
				}
			}
			// we ignore unchecked folders
			else
			{
			}
		}
	}
}
