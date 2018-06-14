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
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision.Contract;
using Newtonsoft.Json;
using VisionLibrary.Common;
using VisionLibrary.Conclusion;
using VisionLibrary.Enum;
using VisionLibrary.Module;
using VisionLibrary.VisionClass;

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

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.imageListView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("please select a image");
                return;
            }
            string path = this.imageListView1.SelectedItems[0].FileName;
            AnalyzeImage(path);
        }

        private void btn_mutity_Click(object sender, EventArgs e)
        {

            if (this.imageListView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("please select a image");
                return;
            }
            List<string> path = this.imageListView1.SelectedItems.Select(x => x.FileName).ToList();
            AnalyzeImage(path);
        }

        private async void AnalyzeImage(string path)
        {
            //time watcher
            var watch = System.Diagnostics.Stopwatch.StartNew();


            AzureVisionAnalyze analyze = VisionClassFactory.CreateVisionClass(VisionAPIType.AzureVisionAnalyze) as AzureVisionAnalyze;
            analyze.Key = "43ff244f1b5047d49d82aac0b482d939";



            Task<AnalysisResult> resTask = analyze.UploadAndAnalyzeImage(path, AzureTagFeature.Tags, AzureTagFeature.Description, AzureTagFeature.Categories, AzureTagFeature.Color);
            AnalysisResult res = await resTask;

            //watch end
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            //write result
            this.richTextBox1.Text = $"is animal:{res.IsAnimal()}\n";
            this.richTextBox1.Text += $"run with {path}\n";
            this.richTextBox1.Text += $"used {elapsedMs} ms\n";
            this.richTextBox1.Text += VisCommonClass.JsonPrettyPrint(JsonConvert.SerializeObject(res));
            MessageBox.Show($"cost {elapsedMs}ms");
        }

        private async void AnalyzeImage(List<string> pathList)
        {
            //time watcher
            var watch = System.Diagnostics.Stopwatch.StartNew();

            AzureVisionAnalyze analyze = VisionClassFactory.CreateVisionClass(VisionAPIType.AzureVisionAnalyze) as AzureVisionAnalyze;
            analyze.Key = "43ff244f1b5047d49d82aac0b482d939";

            string dir = Path.Combine(Application.StartupPath, "result", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
            if (!System.IO.Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string dirAnimal = Path.Combine(dir, "aniaml");
            if (!System.IO.Directory.Exists(dirAnimal))
            {
                Directory.CreateDirectory(dirAnimal);
            }
            string dirNoAnimal = Path.Combine(dir, "NoAniaml");
            if (!System.IO.Directory.Exists(dirNoAnimal))
            {
                Directory.CreateDirectory(dirNoAnimal);
            }

            int animalCount = 0;
            int noAnimalCount = 0;
            int errCount = 0;
            int maxThread = 5;

            using (SemaphoreSlim concurrencySemaphore = new SemaphoreSlim(maxThread))
            {
                List<Task> taskList = new List<Task>();
                foreach (string path in pathList)
                {

                    concurrencySemaphore.Wait();
                    Task task = Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            Task<AnalysisResult> resTask = analyze.UploadAndAnalyzeImage(path, AzureTagFeature.Tags,
                                AzureTagFeature.Description, AzureTagFeature.Categories);

                            AnalysisResult res = resTask.GetAwaiter().GetResult();
                            string fileName = Path.GetFileName(path);
                            if (res.IsAnimal())
                            {
                                File.Copy(path, Path.Combine(dirAnimal, fileName));
                                animalCount++;
                            }
                            else
                            {
                                File.Copy(path, Path.Combine(dirNoAnimal, fileName));
                                noAnimalCount++;
                            }
                        }
                        catch (Exception ex)
                        {
                            errCount++;
                        }
                        finally
                        {
                            concurrencySemaphore.Release();
                        }
                    });
                    taskList.Add(task);

                }
                Task.WaitAll(taskList.ToArray());
            }





            //watch end
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            //write result
            this.richTextBox1.Text = $"animal: {animalCount}\n";
            this.richTextBox1.Text += $"no Animal: {noAnimalCount}\n";
            this.richTextBox1.Text += $"error: {errCount}\n";
            this.richTextBox1.Text += $"cost: {elapsedMs} ms\n";
            MessageBox.Show($"done {elapsedMs}ms");
            System.Diagnostics.Process.Start(dir);
        }

        private void btn_baiduAnimal_Click(object sender, EventArgs e)
        {
            if (this.imageListView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("please select a image");
                return;
            }
            BaiduVisionAnalyze ana = new BaiduVisionAnalyze();
            ana.Key = "vKHUR4T6BMeO3yTVwW3nR1NN";
            ana.SKey = "u8A17o87RD7Q35lU8qQKjxrDs1bguBrD";
            BaiduAnalyzeResult res = ana.UploadAndAnalyzeImage(imageListView1.SelectedItems[0].FileName).Result;
        }
    }
}
