using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileListExporter
{
	/// <summary>
	/// Manages hierarchies of folders and files for multiple root folders
	/// </summary>
	public class FileHierarchies
	{
		protected SortedDictionary<string, Folder> _rootFolders = null;   // stores root folders (string: folder name, Folder: folder)

		public FileHierarchies()
		{
			_rootFolders = new SortedDictionary<string, Folder>();
		}

		public FileHierarchies(SortedDictionary<string, Folder> rootFolders)
		{
			_rootFolders = rootFolders;
		}

		public SortedDictionary<string, Folder> GetRootFolders() => _rootFolders;

		/// <summary>
		/// Export folder names from path and add them to root folders hierarchically
		/// </summary>
		/// <param name="path">A full path of a folder</param>
		/// <param name="size">Size of path</param>
		/// <returns>The last folder which extracted from path</returns>
		public Folder AddPath(string path, Size size)
		{
			Folder createdFolder = null;

			// split path into folders
			string[] folderNames = path.Split('/', '\\');

			if (folderNames.Length > 0)
			{
				// folderNames[0] is drive character (ex. "C:")
				// add a drive character as a root folder into _rootFolders
				if (!_rootFolders.ContainsKey(folderNames[0]))
				{
					_rootFolders.Add(folderNames[0], new Folder(folderNames[0], folderNames[0], FileListExporter.Size.Zero));
				}

				// start from a root folder
				Folder parentFolder = _rootFolders[folderNames[0]];
				string subPath = parentFolder.Path;

				// add child folders to parentFolder hierarchically C:\a\b\c
				for (int i = 1; i < folderNames.Length; ++i)
				{
					string folderName = folderNames[i];
					subPath += '\\' + folderName;

					Folder existingFolder = parentFolder.GetSubFolder(folderName);

					if (existingFolder == null)
					{
						parentFolder = parentFolder.AddSubFolder(subPath, folderName, size);
					}
					else
					{
						parentFolder = existingFolder;
					}
				}

				createdFolder = parentFolder;
			}

			return createdFolder;
		}
	}
}
