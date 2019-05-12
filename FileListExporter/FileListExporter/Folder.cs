using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileListExporter
{
	/// <summary>
	/// Represents information of a folder
	/// </summary>
	[Serializable]
	public class Folder
	{
		protected string _path;	// full path including all folder hierarchy
		protected string _name;	// folder name
		protected Size _size;	// folder size
		protected CheckState _checkState = CheckState.Unchecked;	// whether all sub-folders and files are all checked
		protected SortedDictionary<string, Folder> _subFolders = new SortedDictionary<string, Folder>();	// sub-folders in this folder
		protected List<File> _files = new List<File>();	// files in this folder

		public Folder(string path, string name, Size size, CheckState checkState = CheckState.Unchecked)
		{
			_path = path;
			_name = name;
			_size = size;
			_checkState = checkState;
		}

		public string Path => _path;

		public string Name => _name;

		public Size Size => _size;

		public CheckState CheckState { get => _checkState; set => _checkState = value; }

		public SortedDictionary<string, Folder> SubFolders => _subFolders;

		public List<File> Files => _files;

		/// <summary>
		/// Find and return a sub-folder with name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public Folder GetSubFolder(string name)
		{
			Folder subFolder = null;

			if (_subFolders.ContainsKey(name))
			{
				subFolder = _subFolders[name];
			}

			return subFolder;
		}

		/// <summary>
		/// Add path as a sub-folder of this folder
		/// </summary>
		/// <param name="path"></param>
		/// <param name="name"></param>
		/// <param name="size"></param>
		/// <returns></returns>
		public Folder AddSubFolder(string path, string name, Size size)
		{
			Folder newSubFolder = new Folder(path, name, size);
			_subFolders.Add(name, newSubFolder);

			return newSubFolder;
		}

		/// <summary>
		/// Add a file to this folder
		/// </summary>
		/// <param name="name"></param>
		/// <param name="size"></param>
		public void AddFile(string name, Size size)
		{
			_files.Add(new File(name, size));
		}

		public override string ToString()
		{
			return "Path: " + _path + ", Name: " + _name + ", Size: " + _size.ToString() + ", CheckState: " + _checkState.ToString() + ", SubFolders: " + _subFolders.Count.ToString() + ", Files: " + _files.Count.ToString();
		}
	}
}
