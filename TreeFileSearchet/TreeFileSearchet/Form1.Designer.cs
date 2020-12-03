namespace TreeFileSearchet
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDirectoryPath = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchWord = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTimeElapsed = new System.Windows.Forms.Label();
            this.lblFilesFoundOfTotal = new System.Windows.Forms.Label();
            this.lblCurrentDirectory = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDirectoryPath
            // 
            this.txtDirectoryPath.Location = new System.Drawing.Point(151, 6);
            this.txtDirectoryPath.Name = "txtDirectoryPath";
            this.txtDirectoryPath.Size = new System.Drawing.Size(275, 23);
            this.txtDirectoryPath.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(317, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtSearchWord
            // 
            this.txtSearchWord.Location = new System.Drawing.Point(151, 34);
            this.txtSearchWord.Name = "txtSearchWord";
            this.txtSearchWord.Size = new System.Drawing.Size(127, 23);
            this.txtSearchWord.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(8, 64);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(249, 396);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Путь к корневой папке";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Искомый файл";
            // 
            // lblTimeElapsed
            // 
            this.lblTimeElapsed.AutoSize = true;
            this.lblTimeElapsed.Location = new System.Drawing.Point(263, 73);
            this.lblTimeElapsed.Name = "lblTimeElapsed";
            this.lblTimeElapsed.Size = new System.Drawing.Size(149, 15);
            this.lblTimeElapsed.TabIndex = 10;
            this.lblTimeElapsed.Text = "Затрачено времени: 0 сек";
            this.lblTimeElapsed.UseMnemonic = false;
            // 
            // lblFilesFoundOfTotal
            // 
            this.lblFilesFoundOfTotal.AutoSize = true;
            this.lblFilesFoundOfTotal.Location = new System.Drawing.Point(263, 101);
            this.lblFilesFoundOfTotal.Name = "lblFilesFoundOfTotal";
            this.lblFilesFoundOfTotal.Size = new System.Drawing.Size(90, 15);
            this.lblFilesFoundOfTotal.TabIndex = 11;
            this.lblFilesFoundOfTotal.Text = "Начните поиск";
            // 
            // lblCurrentDirectory
            // 
            this.lblCurrentDirectory.AutoSize = true;
            this.lblCurrentDirectory.Location = new System.Drawing.Point(263, 125);
            this.lblCurrentDirectory.Name = "lblCurrentDirectory";
            this.lblCurrentDirectory.Size = new System.Drawing.Size(16, 15);
            this.lblCurrentDirectory.TabIndex = 12;
            this.lblCurrentDirectory.Text = "...";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(263, 156);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 472);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblCurrentDirectory);
            this.Controls.Add(this.lblFilesFoundOfTotal);
            this.Controls.Add(this.lblTimeElapsed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.txtSearchWord);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtDirectoryPath);
            this.Name = "Form1";
            this.Text = "Поисковик файла";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDirectoryPath;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchWord;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTimeElapsed;
        private System.Windows.Forms.Label lblFilesFoundOfTotal;
        private System.Windows.Forms.Label lblCurrentDirectory;
        private System.Windows.Forms.Button btnCancel;
    }
}

