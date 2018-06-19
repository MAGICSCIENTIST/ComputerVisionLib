namespace ImageListViewDemo
{
    partial class DemoForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemoForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_baiduAnimal = new System.Windows.Forms.Button();
            this.btn_one = new System.Windows.Forms.Button();
            this.btn_mutity = new System.Windows.Forms.Button();
            this.imageListView1 = new ImageListViewDemo.ImageListView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.addToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.rendererToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.renderertoolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.detailsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.thumbnailsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(824, 494);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(824, 541);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip);
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(824, 22);
            this.statusStrip.TabIndex = 0;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_baiduAnimal);
            this.splitContainer1.Panel1.Controls.Add(this.btn_one);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.btn_mutity);
            this.splitContainer1.Panel1.Controls.Add(this.imageListView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(824, 494);
            this.splitContainer1.SplitterDistance = 555;
            this.splitContainer1.TabIndex = 2;
            // 
            // btn_baiduAnimal
            // 
            this.btn_baiduAnimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_baiduAnimal.Location = new System.Drawing.Point(291, 468);
            this.btn_baiduAnimal.Name = "btn_baiduAnimal";
            this.btn_baiduAnimal.Size = new System.Drawing.Size(99, 23);
            this.btn_baiduAnimal.TabIndex = 2;
            this.btn_baiduAnimal.Text = "是哪个(BAIDU)";
            this.btn_baiduAnimal.UseVisualStyleBackColor = true;
            this.btn_baiduAnimal.Click += new System.EventHandler(this.btn_baiduAnimal_Click);
            // 
            // btn_one
            // 
            this.btn_one.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_one.Location = new System.Drawing.Point(396, 468);
            this.btn_one.Name = "btn_one";
            this.btn_one.Size = new System.Drawing.Size(75, 23);
            this.btn_one.TabIndex = 1;
            this.btn_one.Text = "单个";
            this.btn_one.UseVisualStyleBackColor = true;
            this.btn_one.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_mutity
            // 
            this.btn_mutity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_mutity.Location = new System.Drawing.Point(477, 468);
            this.btn_mutity.Name = "btn_mutity";
            this.btn_mutity.Size = new System.Drawing.Size(75, 23);
            this.btn_mutity.TabIndex = 1;
            this.btn_mutity.Text = "复数";
            this.btn_mutity.UseVisualStyleBackColor = true;
            this.btn_mutity.Click += new System.EventHandler(this.btn_mutity_Click);
            // 
            // imageListView1
            // 
            this.imageListView1.AllowDrag = true;
            this.imageListView1.AllowDrop = true;
            this.imageListView1.ContextMenuStrip = this.contextMenuStrip;
            this.imageListView1.DefaultImage = ((System.Drawing.Image)(resources.GetObject("imageListView1.DefaultImage")));
            this.imageListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListView1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("imageListView1.ErrorImage")));
            this.imageListView1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.imageListView1.Location = new System.Drawing.Point(0, 0);
            this.imageListView1.Name = "imageListView1";
            this.imageListView1.Size = new System.Drawing.Size(555, 494);
            this.imageListView1.TabIndex = 0;
            this.imageListView1.ItemDoubleClick += new ImageListViewDemo.ItemDoubleClickEventHandler(this.imageListView1_ItemDoubleClick);
            this.imageListView1.SelectionChanged += new System.EventHandler(this.imageListView1_SelectionChanged);
            this.imageListView1.ThumbnailCached += new ImageListViewDemo.ThumbnailCachedEventHandler(this.imageListView1_ThumbnailCached);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(265, 494);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripButton,
            this.removeToolStripButton,
            this.toolStripSeparator1,
            this.rendererToolStripLabel,
            this.renderertoolStripComboBox,
            this.toolStripSeparator2,
            this.detailsToolStripButton,
            this.thumbnailsToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(3, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(296, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // addToolStripButton
            // 
            this.addToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripButton.Image")));
            this.addToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolStripButton.Name = "addToolStripButton";
            this.addToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addToolStripButton.Text = "Add Files...";
            this.addToolStripButton.Click += new System.EventHandler(this.addToolStripButton_Click);
            // 
            // removeToolStripButton
            // 
            this.removeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeToolStripButton.Image")));
            this.removeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeToolStripButton.Name = "removeToolStripButton";
            this.removeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.removeToolStripButton.Text = "Remove Selected Files";
            this.removeToolStripButton.Click += new System.EventHandler(this.removeToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // rendererToolStripLabel
            // 
            this.rendererToolStripLabel.Name = "rendererToolStripLabel";
            this.rendererToolStripLabel.Size = new System.Drawing.Size(57, 22);
            this.rendererToolStripLabel.Text = "Renderer:";
            // 
            // renderertoolStripComboBox
            // 
            this.renderertoolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.renderertoolStripComboBox.Items.AddRange(new object[] {
            "Built-In",
            "Custom"});
            this.renderertoolStripComboBox.Name = "renderertoolStripComboBox";
            this.renderertoolStripComboBox.Size = new System.Drawing.Size(121, 25);
            this.renderertoolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.renderertoolStripComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // detailsToolStripButton
            // 
            this.detailsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.detailsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("detailsToolStripButton.Image")));
            this.detailsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.detailsToolStripButton.Name = "detailsToolStripButton";
            this.detailsToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.detailsToolStripButton.Text = "Details";
            this.detailsToolStripButton.Click += new System.EventHandler(this.detailsToolStripButton_Click);
            // 
            // thumbnailsToolStripButton
            // 
            this.thumbnailsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.thumbnailsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("thumbnailsToolStripButton.Image")));
            this.thumbnailsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.thumbnailsToolStripButton.Name = "thumbnailsToolStripButton";
            this.thumbnailsToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.thumbnailsToolStripButton.Text = "Thumbnails";
            this.thumbnailsToolStripButton.Click += new System.EventHandler(this.thumbnailsToolStripButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "JPEG Images (*.jpg)|*.jpg";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.ShowReadOnly = true;
            // 
            // timerStatus
            // 
            this.timerStatus.Interval = 2000;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(477, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "复数-进度条";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_mutity_progress_Click);
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 541);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "DemoForm";
            this.Text = "ImageListView Demo";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton addToolStripButton;
        private System.Windows.Forms.ToolStripButton removeToolStripButton;
        private ImageListView imageListView1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel rendererToolStripLabel;
        private System.Windows.Forms.ToolStripComboBox renderertoolStripComboBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton detailsToolStripButton;
        private System.Windows.Forms.ToolStripButton thumbnailsToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btn_mutity;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_one;
        private System.Windows.Forms.Button btn_baiduAnimal;
        private System.Windows.Forms.Button button1;
    }
}

