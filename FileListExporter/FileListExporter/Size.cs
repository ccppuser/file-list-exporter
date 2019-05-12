using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileListExporter
{
	/// <summary>
	/// Represents size of a folder or file
	/// </summary>
	[Serializable]
	public class Size : IComparable<Size>
	{
		public enum SizeUnits
		{
			B,	// Bytes
			KB,	// Kilobytes
			MB,	// Megabytes
			GB,	// Gigabytes
			TB	// Terabytes
		}

		public static readonly Size Zero = new Size("0B");	// represents zero byte

		protected float _number;	// shrinked number with size unit
		protected SizeUnits _sizeUnit;
		protected ulong _actualNumber;	// real number
		protected bool _isValid;	// whether this size valid

		public Size(string strSize)
		{
			AnalyzeSize(strSize);
		}

		public float Number => _number;

		public SizeUnits SizeUnit => _sizeUnit;

		public ulong ActualNumber => _actualNumber;

		public bool IsValid => _isValid;

		/// <summary>
		/// Figure out size information from strSize
		/// </summary>
		/// <param name="strSize"></param>
		protected void AnalyzeSize(string strSize)
		{
			_sizeUnit = SizeUnits.B;
			_actualNumber = ulong.MaxValue;
			ulong multiplier = 1;

			// terabytes
			if (strSize[strSize.Length - 2] == 'T' ||
				strSize[strSize.Length - 2] == 't')
			{
				_sizeUnit = SizeUnits.TB;
				multiplier = 1024LU * 1024LU * 1024LU * 1024LU;
			}
			// gigabytes
			else if (strSize[strSize.Length - 2] == 'G' ||
				strSize[strSize.Length - 2] == 'g')
			{
				_sizeUnit = SizeUnits.GB;
				multiplier = 1024LU * 1024LU * 1024LU;
			}
			// megabytes
			else if (strSize[strSize.Length - 2] == 'M' ||
				strSize[strSize.Length - 2] == 'm')
			{
				_sizeUnit = SizeUnits.MB;
				multiplier = 1024LU * 1024LU;
			}
			// kilobytes
			else if (strSize[strSize.Length - 2] == 'K' ||
				strSize[strSize.Length - 2] == 'k')
			{
				_sizeUnit = SizeUnits.KB;
				multiplier = 1024LU;
			}

			string strNumber;
			// if the size is less than 1MB
			// (ex. "100b")
			if (multiplier == 1)
			{
				strNumber = strSize.Substring(0, strSize.Length - 1);
			}
			// (ex. "10TB")
			else
			{
				strNumber = strSize.Substring(0, strSize.Length - 2);
			}

			if (float.TryParse(strNumber, out _number))
			{
				_actualNumber = (ulong)(_number * multiplier);
				_isValid = true;
			}
			else
			{
				_actualNumber = ulong.MaxValue;
				_isValid = false;
			}
		}

		public override string ToString()
		{
			return _number.ToString() + _sizeUnit.ToString();
		}

		/// <summary>
		/// Implement IComparable
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public int CompareTo(Size other)
		{
			if (_actualNumber < other._actualNumber)
			{
				return -1;
			}
			else if (_actualNumber == other._actualNumber)
			{
				return 0;
			}
			else
			{
				return 1;
			}
		}
	}
}
