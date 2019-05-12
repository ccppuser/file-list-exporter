namespace FileListExporter
{
	partial class AboutForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnOk = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lnkSpaceSniffer = new System.Windows.Forms.LinkLabel();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lnkFastCopy = new System.Windows.Forms.LinkLabel();
			this.label4 = new System.Windows.Forms.Label();
			this.lnkFileListExporter = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnOk.Location = new System.Drawing.Point(407, 229);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(87, 21);
			this.btnOk.TabIndex = 25;
			this.btnOk.Text = "&Ok";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(365, 12);
			this.label1.TabIndex = 26;
			this.label1.Text = "\'File List Exporter\' is useful with \'SpaceSniffer\' and \'FastCopy\'.";
			// 
			// lnkSpaceSniffer
			// 
			this.lnkSpaceSniffer.AutoSize = true;
			this.lnkSpaceSniffer.Location = new System.Drawing.Point(181, 58);
			this.lnkSpaceSniffer.Name = "lnkSpaceSniffer";
			this.lnkSpaceSniffer.Size = new System.Drawing.Size(300, 12);
			this.lnkSpaceSniffer.TabIndex = 27;
			this.lnkSpaceSniffer.TabStop = true;
			this.lnkSpaceSniffer.Text = "http://www.uderzo.it/main_products/space_sniffer/";
			this.lnkSpaceSniffer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSpaceSniffer_LinkClicked);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(162, 12);
			this.label2.TabIndex = 28;
			this.label2.Text = "SpaceSniffer download link:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(145, 12);
			this.label3.TabIndex = 29;
			this.label3.Text = "FastCopy download link:";
			// 
			// lnkFastCopy
			// 
			this.lnkFastCopy.AutoSize = true;
			this.lnkFastCopy.Location = new System.Drawing.Point(164, 80);
			this.lnkFastCopy.Name = "lnkFastCopy";
			this.lnkFastCopy.Size = new System.Drawing.Size(136, 12);
			this.lnkFastCopy.TabIndex = 30;
			this.lnkFastCopy.TabStop = true;
			this.lnkFastCopy.Text = "https://fastcopy.jp/en/";
			this.lnkFastCopy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFastCopy_LinkClicked);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 102);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(168, 12);
			this.label4.TabIndex = 31;
			this.label4.Text = "File List Exporter homepage:";
			// 
			// lnkFileListExporter
			// 
			this.lnkFileListExporter.AutoSize = true;
			this.lnkFileListExporter.Location = new System.Drawing.Point(187, 102);
			this.lnkFileListExporter.Name = "lnkFileListExporter";
			this.lnkFileListExporter.Size = new System.Drawing.Size(266, 12);
			this.lnkFileListExporter.TabIndex = 32;
			this.lnkFileListExporter.TabStop = true;
			this.lnkFileListExporter.Text = "https://github.com/ccppuser/file-list-exporter";
			this.lnkFileListExporter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFileListExporter_LinkClicked);
			// 
			// AboutForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(507, 261);
			this.Controls.Add(this.lnkFileListExporter);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lnkFastCopy);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lnkSpaceSniffer);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About File List Exporter";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel lnkSpaceSniffer;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.LinkLabel lnkFastCopy;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel lnkFileListExporter;
	}
}