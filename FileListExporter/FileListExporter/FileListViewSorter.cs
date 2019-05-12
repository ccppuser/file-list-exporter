using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileListExporter
{
	public static class SortingMethods
	{
		public const string Name = "Name";
		public const string Name_Ascending = "↑" + Name;
		public const string Name_Descending = "↓" + Name;
		public const string Size = "Size";
		public const string Size_Ascending = "↑" + Size;
		public const string Size_Descending = "↓" + Size;
		public const string Type = "Type";
		public const string Type_Ascending = "↑" + Type;
		public const string Type_Descending = "↓" + Type;
		public const string None = "None";

		public static string CurrentSortingMethod = None;
	}

	/// <summary>
	/// ListView sorter for files
	/// </summary>
	public class ListViewSorter : IComparer
	{
		protected int _column;
		protected SortOrder _sortOrder;

		public ListViewSorter(int column, SortOrder sortOrder)
		{
			_column = column;
			_sortOrder = sortOrder;
		}

		public void SetSortingMethod(int column, SortOrder sortOrder)
		{
			_column = column;
			_sortOrder = sortOrder;
		}

		/// <summary>
		/// Implement IComparer
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int Compare(object x, object y)
		{
			if (_column == 2)
			{
				if (_sortOrder == SortOrder.Ascending)
					return ((Size)((ListViewItem)x).SubItems[_column].Tag).CompareTo(((Size)((ListViewItem)y).SubItems[_column].Tag));
				else
					return ((Size)((ListViewItem)y).SubItems[_column].Tag).CompareTo(((Size)((ListViewItem)x).SubItems[_column].Tag));
			}
			else
			{
				if (_sortOrder == SortOrder.Ascending)
					return String.Compare(((ListViewItem)x).SubItems[_column].Text, ((ListViewItem)y).SubItems[_column].Text);
				else
					return String.Compare(((ListViewItem)y).SubItems[_column].Text, ((ListViewItem)x).SubItems[_column].Text);
			}
		}
	}
}
