namespace FileListExporter
{
	partial class MainForm
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
			this.tvwFolders = new System.Windows.Forms.TreeView();
			this.imgsFolderStates = new System.Windows.Forms.ImageList(this.components);
			this.lvwFiles = new System.Windows.Forms.ListView();
			this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chkSelectAll = new System.Windows.Forms.CheckBox();
			this.btnExportForFastCopy = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnExpandAllFolders = new System.Windows.Forms.Button();
			this.btnShrinkAllFolders = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.btnOpenSelectedFolder = new System.Windows.Forms.Button();
			this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
			this.btnSaveAs = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
			this.dlgExportFile = new System.Windows.Forms.SaveFileDialog();
			this.btnAbout = new System.Windows.Forms.Button();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tvwFolders
			// 
			this.tvwFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tvwFolders.CheckBoxes = true;
			this.tvwFolders.HideSelection = false;
			this.tvwFolders.ImageIndex = 0;
			this.tvwFolders.ImageList = this.imgsFolderStates;
			this.tvwFolders.Location = new System.Drawing.Point(3, 34);
			this.tvwFolders.Name = "tvwFolders";
			this.tvwFolders.SelectedImageIndex = 0;
			this.tvwFolders.Size = new System.Drawing.Size(419, 320);
			this.tvwFolders.TabIndex = 3;
			this.tvwFolders.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwFolders_AfterCheck);
			this.tvwFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwFolders_AfterSelect);
			// 
			// imgsFolderStates
			// 
			this.imgsFolderStates.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgsFolderStates.ImageStream")));
			this.imgsFolderStates.TransparentColor = System.Drawing.Color.Transparent;
			this.imgsFolderStates.Images.SetKeyName(0, "unchecked.png");
			this.imgsFolderStates.Images.SetKeyName(1, "checked.png");
			this.imgsFolderStates.Images.SetKeyName(2, "partial.png");
			// 
			// lvwFiles
			// 
			this.lvwFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvwFiles.CheckBoxes = true;
			this.lvwFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colType,
            this.colSize});
			this.lvwFiles.HideSelection = false;
			this.lvwFiles.Location = new System.Drawing.Point(3, 34);
			this.lvwFiles.Name = "lvwFiles";
			this.lvwFiles.Size = new System.Drawing.Size(341, 320);
			this.lvwFiles.TabIndex = 1;
			this.lvwFiles.UseCompatibleStateImageBehavior = false;
			this.lvwFiles.View = System.Windows.Forms.View.Details;
			this.lvwFiles.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwFiles_ColumnClick);
			this.lvwFiles.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwFiles_ItemChecked);
			// 
			// colName
			// 
			this.colName.Text = "Name";
			// 
			// colType
			// 
			this.colType.Text = "Type";
			// 
			// colSize
			// 
			this.colSize.Text = "Size";
			// 
			// chkSelectAll
			// 
			this.chkSelectAll.AutoSize = true;
			this.chkSelectAll.Location = new System.Drawing.Point(3, 9);
			this.chkSelectAll.Name = "chkSelectAll";
			this.chkSelectAll.Size = new System.Drawing.Size(77, 16);
			this.chkSelectAll.TabIndex = 0;
			this.chkSelectAll.Text = "Select All";
			this.chkSelectAll.UseVisualStyleBackColor = true;
			this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
			// 
			// btnExportForFastCopy
			// 
			this.btnExportForFastCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExportForFastCopy.Location = new System.Drawing.Point(632, 402);
			this.btnExportForFastCopy.Name = "btnExportForFastCopy";
			this.btnExportForFastCopy.Size = new System.Drawing.Size(156, 23);
			this.btnExportForFastCopy.TabIndex = 2;
			this.btnExportForFastCopy.Text = "Export for FastCopy";
			this.btnExportForFastCopy.UseVisualStyleBackColor = true;
			this.btnExportForFastCopy.Click += new System.EventHandler(this.btnExportForFastCopy_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(470, 402);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnExpandAllFolders
			// 
			this.btnExpandAllFolders.Location = new System.Drawing.Point(3, 5);
			this.btnExpandAllFolders.Name = "btnExpandAllFolders";
			this.btnExpandAllFolders.Size = new System.Drawing.Size(134, 23);
			this.btnExpandAllFolders.TabIndex = 0;
			this.btnExpandAllFolders.Text = "Expand all folders";
			this.btnExpandAllFolders.UseVisualStyleBackColor = true;
			this.btnExpandAllFolders.Click += new System.EventHandler(this.btnExpandAllFolders_Click);
			// 
			// btnShrinkAllFolders
			// 
			this.btnShrinkAllFolders.Location = new System.Drawing.Point(143, 5);
			this.btnShrinkAllFolders.Name = "btnShrinkAllFolders";
			this.btnShrinkAllFolders.Size = new System.Drawing.Size(134, 23);
			this.btnShrinkAllFolders.TabIndex = 1;
			this.btnShrinkAllFolders.Text = "Shrink all folders";
			this.btnShrinkAllFolders.UseVisualStyleBackColor = true;
			this.btnShrinkAllFolders.Click += new System.EventHandler(this.btnShrinkAllFolders_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(12, 39);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.btnOpenSelectedFolder);
			this.splitContainer1.Panel1.Controls.Add(this.tvwFolders);
			this.splitContainer1.Panel1.Controls.Add(this.btnExpandAllFolders);
			this.splitContainer1.Panel1.Controls.Add(this.btnShrinkAllFolders);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.chkSelectAll);
			this.splitContainer1.Panel2.Controls.Add(this.lvwFiles);
			this.splitContainer1.Size = new System.Drawing.Size(776, 357);
			this.splitContainer1.SplitterDistance = 425;
			this.splitContainer1.TabIndex = 4;
			this.splitContainer1.TabStop = false;
			// 
			// btnOpenSelectedFolder
			// 
			this.btnOpenSelectedFolder.Location = new System.Drawing.Point(283, 5);
			this.btnOpenSelectedFolder.Name = "btnOpenSelectedFolder";
			this.btnOpenSelectedFolder.Size = new System.Drawing.Size(134, 23);
			this.btnOpenSelectedFolder.TabIndex = 2;
			this.btnOpenSelectedFolder.Text = "Open selected folder";
			this.btnOpenSelectedFolder.UseVisualStyleBackColor = true;
			this.btnOpenSelectedFolder.Click += new System.EventHandler(this.btnOpenSelectedFolder_Click);
			// 
			// btnSaveAs
			// 
			this.btnSaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveAs.Location = new System.Drawing.Point(551, 402);
			this.btnSaveAs.Name = "btnSaveAs";
			this.btnSaveAs.Size = new System.Drawing.Size(75, 23);
			this.btnSaveAs.TabIndex = 1;
			this.btnSaveAs.Text = "Save as...";
			this.btnSaveAs.UseVisualStyleBackColor = true;
			this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusStrip});
			this.statusStrip1.Location = new System.Drawing.Point(0, 428);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(800, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblStatusStrip
			// 
			this.lblStatusStrip.Name = "lblStatusStrip";
			this.lblStatusStrip.Size = new System.Drawing.Size(121, 17);
			this.lblStatusStrip.Text = "toolStripStatusLabel1";
			// 
			// btnAbout
			// 
			this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAbout.Location = new System.Drawing.Point(12, 402);
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Size = new System.Drawing.Size(75, 23);
			this.btnAbout.TabIndex = 5;
			this.btnAbout.Text = "About";
			this.btnAbout.UseVisualStyleBackColor = true;
			this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(105, 12);
			this.txtPath.Name = "txtPath";
			this.txtPath.ReadOnly = true;
			this.txtPath.Size = new System.Drawing.Size(680, 21);
			this.txtPath.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 12);
			this.label1.TabIndex = 7;
			this.label1.Text = "Selected path:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.btnAbout);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.btnSaveAs);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnExportForFastCopy);
			this.MinimumSize = new System.Drawing.Size(816, 489);
			this.Name = "MainForm";
			this.Text = "File List Exporter";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog dlgOpenFile;
		private System.Windows.Forms.TreeView tvwFolders;
		private System.Windows.Forms.ListView lvwFiles;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ColumnHeader colSize;
		private System.Windows.Forms.ColumnHeader colType;
		private System.Windows.Forms.CheckBox chkSelectAll;
		private System.Windows.Forms.Button btnExportForFastCopy;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnExpandAllFolders;
		private System.Windows.Forms.Button btnShrinkAllFolders;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ImageList imgsFolderStates;
		private System.Windows.Forms.SaveFileDialog dlgSaveFile;
		private System.Windows.Forms.Button btnSaveAs;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lblStatusStrip;
		private System.Windows.Forms.SaveFileDialog dlgExportFile;
		private System.Windows.Forms.Button btnAbout;
		private System.Windows.Forms.Button btnOpenSelectedFolder;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Label label1;
	}
}

