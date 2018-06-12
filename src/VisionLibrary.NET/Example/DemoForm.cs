using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ImageListViewDemo
{
    public partial class DemoForm : Form
    {
        public DemoForm()
        {
            InitializeComponent();
            Application.Idle += new EventHandler(Application_Idle);
            renderertoolStripComboBox.SelectedIndex = 0;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            // Refresh UI cues
            removeToolStripButton.Enabled = (imageListView1.SelectedItems.Count > 0);
            deleteToolStripMenuItem.Enabled = (imageListView1.SelectedItems.Count > 0);
            detailsToolStripButton.Checked = (imageListView1.View == View.Details);
            thumbnailsToolStripButton.Checked = (imageListView1.View == View.Thumbnails);
        }

        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                imageListView1.Items.AddRange(openFileDialog.FileNames);
        }

        private void removeToolStripButton_Click(object sender, EventArgs e)
        {
            // Suspend the layout logic while we are removing items.
            // Otherwise the control will be refreshed after each item
            // is removed.
            imageListView1.SuspendLayout();

            // Remove selected items
            foreach (var item in imageListView1.SelectedItems)
                imageListView1.Items.Remove(item);

            // Resume layout logic.
            imageListView1.ResumeLayout(true);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeToolStripButton_Click(sender, e);
        }

        private void renderertoolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Change the renderer
            if (renderertoolStripComboBox.SelectedIndex == 0)
                imageListView1.SetRenderer(new ImageListView.ImageListViewRenderer());
            else
                imageListView1.SetRenderer(new DemoRenderer());
            imageListView1.Focus();
        }

        private void detailsToolStripButton_Click(object sender, EventArgs e)
        {
            // Switch to Details mode.
            imageListView1.View = View.Details;
        }

        private void thumbnailsToolStripButton_Click(object sender, EventArgs e)
        {
            // Switch to Thumbnails mode.
            imageListView1.View = View.Thumbnails;
        }

        private void imageListView1_ThumbnailCached(object sender, ItemEventArgs e)
        {
            // This event is fired after a new thumbnail is cached.
            UpdateStatus(string.Format("Cached image: {0}", e.Item.Text));
            timerStatus.Enabled = true;
        }

        private void imageListView1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            UpdateStatus();
            timerStatus.Enabled = false;
        }

        private void UpdateStatus(string text)
        {
            toolStripStatusLabel.Text = text;
        }

        private void UpdateStatus()
        {
            if (imageListView1.Items.Count == 0)
                UpdateStatus("Ready");
            else if (imageListView1.SelectedItems.Count == 0)
                UpdateStatus(string.Format("{0} images", imageListView1.Items.Count));
            else
                UpdateStatus(string.Format("{0} images ({1} selected)", imageListView1.Items.Count, imageListView1.SelectedItems.Count));
        }

        private void imageListView1_ItemDoubleClick(object sender, ItemClickEventArgs e)
        {
            var a = imageListView1.SelectedItems;
        }
    }
}
