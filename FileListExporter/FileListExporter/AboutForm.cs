using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace FileListExporter
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
		}

		private void lnkSpaceSniffer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(lnkSpaceSniffer.Text);
		}

		private void lnkFastCopy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(lnkFastCopy.Text);
		}

		private void lnkFileListExporter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(lnkFileListExporter.Text);
		}
	}
}
