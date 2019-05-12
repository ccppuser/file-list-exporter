using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileListExporter
{
	/// <summary>
	/// Save or load a FileListExporter file
	/// </summary>
	public class FileListExporterFile
	{
		protected string _filePath = "";    // file path including full path and file name
		protected string _fileDirectory = "";   // directory which contains the save file
		protected string _fileNameBody = "";    // file name without path and extention
		protected string _fileExtention = "";	// extention of file

		public string FilePath => _filePath;

		public string FileDirectory => _fileDirectory;

		public string FileNameBody => _fileNameBody;

		public string FileExtention => _fileExtention;

		/// <summary>
		/// Store save file path which decides initial directory and file name of exporting or saving other files later
		/// </summary>
		/// <param name="filePath">A full path of a FileListExporter file</param>
		public void SetFilePath(string filePath)
		{
			_filePath = filePath;

			if (_filePath != null && _filePath != "")
			{
				SplitFilePath(_filePath, out _fileDirectory, out _fileNameBody, out _fileExtention);
			}
		}

		/// <summary>
		/// Extract directory hierarchy, file name body, and extention from filePath
		/// </summary>
		/// <param name="filePath">A full path of a file</param>
		/// <param name="directory">Directory hierarchy</param>
		/// <param name="fileNameBody">File name without extention</param>
		/// <param name="extention">Extention</param>
		protected static void SplitFilePath(string filePath, out string directory, out string fileNameBody, out string extention)
		{
			directory = "";
			fileNameBody = "";
			extention = "";

			FileInfo fileInfo = new FileInfo(filePath);

			directory = fileInfo.DirectoryName;

			int extentionIndex = fileInfo.Name.LastIndexOf('.');
			fileNameBody = fileInfo.Name.Substring(0, extentionIndex);
			extention = fileInfo.Name.Substring(extentionIndex + 1);
		}

		/// <summary>
		/// Save the information of selected folders and files to a FileListExporter file
		/// </summary>
		/// <param name="rootFolders"></param>
		public void SaveFile(SortedDictionary<string, Folder> rootFolders)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream saveFile = System.IO.File.Create(_filePath);

			formatter.Serialize(saveFile, rootFolders);

			saveFile.Close();
		}

		/// <summary>
		/// Load the information of selected folders and files from a FileListExporter file
		/// </summary>
		/// <returns></returns>
		public FileHierarchies LoadFile()
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream loadFile = System.IO.File.Open(_filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

			SortedDictionary<string, Folder> rootFolders = formatter.Deserialize(loadFile) as SortedDictionary<string, Folder>;
			FileHierarchies fileHierarchies = new FileHierarchies(rootFolders);

			loadFile.Close();

			return fileHierarchies;
		}
	}
}
