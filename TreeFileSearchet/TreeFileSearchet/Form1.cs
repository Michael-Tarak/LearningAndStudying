using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeFileSearchet
{
    public partial class Form1 : Form
    {
        public readonly string LastUsagePath = "lastusage.txt";

        private bool _isSearchCanceled = false;
        public int FilesTotal;
        public int FilesAllowed;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
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

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;
            btnCancel.Enabled = true;
            btnCancel.Text = "Отмена";
            if (string.IsNullOrEmpty(txtSearchWord.Text))
                txtSearchWord.Text = ".";
            if (string.IsNullOrEmpty(txtDirectoryPath.Text)|| !Directory.Exists(txtDirectoryPath.Text))
            {
                MessageBox.Show("Неверный путь!");
            }
            else
            {
                SearchFiles();
            }
            btnSearch.Enabled = true;
            btnCancel.Enabled = false;
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblCurrentDirectory.Text = treeView1.SelectedNode.FullPath;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (_isSearchCanceled)
            {
                btnSearch.Enabled = false;
                btnCancel.Text = "Отмена"; 
                 _isSearchCanceled = false;
            }
            else
            {
                btnSearch.Enabled = true;
                btnCancel.Text = "Возобновить";
                _isSearchCanceled = true;
            }
        }
        private void AwaitingForResume()
        {
            while (_isSearchCanceled)
            {
                Application.DoEvents();
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
            FilesTotal += Directory.GetFiles(dir).Length;
            var files = Directory.GetFiles(dir, txtSearchWord.Text);
            FilesAllowed += files.Length;
            foreach (var file in files)
            {
                FileInfo fi = new FileInfo(file);
                TreeNode tds = tn.Nodes.Add(fi.Name);
            }
            Application.DoEvents();
            if (_isSearchCanceled)
            {
                AwaitingForResume();
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
        private void SearchFiles()
        {
            FilesTotal = 0;
            FilesAllowed = 0;
            var startTime = DateTimeOffset.Now;
            treeView1.Nodes.Clear();
            LoadDirectory(txtDirectoryPath.Text);
            File.WriteAllLines(
                LastUsagePath,
                new string[] { txtDirectoryPath.Text, txtSearchWord.Text });
            lblFilesFoundOfTotal.Text = $"Найдено {FilesAllowed} из {FilesTotal} файлов";
            lblTimeElapsed.Text = $"Затрачено времени: {(DateTimeOffset.Now - startTime).Seconds} сек";

        }
    }
}
