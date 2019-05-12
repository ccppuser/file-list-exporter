using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FileListExporter
{
	/// <summary>
	/// Load a txt file which is exported from SpaceSniffer program
	/// </summary>
	public class SpaceSnifferFile
	{
		/// <summary>
		/// Load a txt file which is exported from SpaceSniffer program and returns file hierarchies
		/// </summary>
		/// <param name="txtFilePath">A full path of a txt file</param>
		/// <returns>True, if the file is successfully loaded</returns>
		public FileHierarchies LoadTxtFile(string txtFilePath)
		{
			FileHierarchies hierarchies = new FileHierarchies();

			// open the file
			using (StreamReader reader = new StreamReader(txtFilePath))
			{
				try
				{
					string line;
					Folder lastFolder = null;

					// process line by line
					while (!reader.EndOfStream)
					{
						// load one line
						line = reader.ReadLine();

						// if the line is empty:
						if (line == null || line == "")
						{
							// ignore
						}
						// if the line is file information
						//	(ex. "  [  67.4MB] AtestLeap.zip")
						else if (line.Length > 2 && line[0] == ' ' && line[1] == ' ')
						{
							// insert a file to the last folder
							if (lastFolder != null)
							{
								// split size and file name
								int sizeEndIndex = line.IndexOf(']');
								string strSize = line.Substring(3, sizeEndIndex - 3);
								Size size = new Size(strSize);
								string fileName = line.Substring(sizeEndIndex + 2);

								// add a file to the last folder
								lastFolder.AddFile(fileName, size);
							}
						}
						// if the line is path information
						//	(ex. "F:\BackUp\BackUp\Dcut [31.0GB]")
						else
						{
							// split path and size
							int sizeStartIndex = line.LastIndexOf(" [");
							string path = line.Substring(0, sizeStartIndex);
							string strSize = line.Substring(sizeStartIndex + 2);
							strSize = strSize.Remove(strSize.LastIndexOf(']'));
							Size size = new Size(strSize);

							// add a path and ready to insert files into it
							lastFolder = hierarchies.AddPath(path, size);
						}
					}
				}
				// if an exception is occured while loading file
				catch (Exception e)
				{
					MessageBox.Show(
						text: "Failed to load \"" + txtFilePath + "\"!\nPlease make sure you select the correct file.\n\nException message: " + e.ToString(),
						caption: "",
						buttons: MessageBoxButtons.OK,
						icon: MessageBoxIcon.Error);

					hierarchies = null;
				}
				finally
				{
				}
			}

			return hierarchies;
		}
	}
}
