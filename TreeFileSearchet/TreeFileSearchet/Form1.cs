using System;
using System.IO;
using System.Windows.Forms;

namespace TreeFileSearchet
{
    public partial class Form1 : Form
    {
        public readonly string LastUsagePath = "lastusage.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(LastUsagePath))
            {
                using FileStream fs = File.Create(LastUsagePath);
            }
            else
            {
                if (File.ReadAllLines(LastUsagePath).Length !=0)
                {
                    txtDirectoryPath.Text = File.ReadAllLines(LastUsagePath)[0];
                    txtSearchWord.Text = File.ReadAllLines(LastUsagePath)[1];
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchWord.Text))
            {
                txtSearchWord.Text = ".";
            }
            if (string.IsNullOrEmpty(txtDirectoryPath.Text)|| !Directory.Exists(txtDirectoryPath.Text))
            {
                MessageBox.Show("Неверный путь!");
            }
            else
            {
                var startTime = DateTimeOffset.Now;
                treeView1.Nodes.Clear();
                LoadDirectory(txtDirectoryPath.Text);
                File.WriteAllLines(
                    LastUsagePath,
                    new string[] { txtDirectoryPath.Text, txtSearchWord.Text });
                lblTimeElapsed.Text = $"Затрачено времени: {(DateTimeOffset.Now - startTime).Seconds.ToString()} сек";
            }
        }
        private void LoadDirectory(string dir)
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            TreeNode tds = treeView1.Nodes.Add(di.Name);
            LoadFiles(dir, tds);
            LoadSubdirectories(dir, tds);
        }
        private void LoadFiles(string dir, TreeNode tn)
        {
            var files = Directory.GetFiles(dir, txtSearchWord.Text);
            foreach (var file in files)
            {
                FileInfo fi = new FileInfo(file);
                TreeNode tds = tn.Nodes.Add(fi.Name);
            }
        }
        private void LoadSubdirectories(string dir, TreeNode tn)
        {
            var subdirectories = Directory.GetDirectories(dir);
            foreach (var subdirectory in subdirectories)
            {
                DirectoryInfo di = new DirectoryInfo(subdirectory);
                TreeNode tds = tn.Nodes.Add(di.Name);
                LoadFiles(subdirectory, tds);
                LoadSubdirectories(subdirectory, tds);
            }
        }
    }
}
