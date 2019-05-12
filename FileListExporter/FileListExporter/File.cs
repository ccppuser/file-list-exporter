using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileListExporter
{
	/// <summary>
	/// Represents information of a file
	/// </summary>
	[Serializable]
	public class File
	{
		protected string _name;	// file name without extention
		protected string _extention;	// file extention
		protected Size _size;	// size of the file
		protected bool _checked = false;	// whether this file is checked by a user

		public File(string name, Size size, bool isChecked = false)
		{
			int extentionIndex = name.LastIndexOf('.');
			if (extentionIndex == -1)
			{
				_name = name;
				_extention = "";
			}
			else
			{
				_name = name;
				_extention = name.Substring(extentionIndex);
			}

			_size = size;
			_checked = isChecked;
		}

		public string Name => _name;

		public string Extention => _extention;

		public Size Size => _size;

		public bool Checked { get => _checked; set => _checked = value; }

		public override string ToString()
		{
			return "Name: " + _name + ", Size: " + _size.ToString() + ", Checked: " + _checked.ToString();
		}
	}
}
