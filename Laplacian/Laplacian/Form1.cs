using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laplacian
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pictureBox1.ImageLocation = "https://upload.wikimedia.org/wikipedia/commons/f/f6/Icon_Einstein_256x256.png";
            pictureBox1.ImageLocation = "image.jpg";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var out3x3 = (Bitmap)pictureBox1.Image;
            pictureBox2.Image = Laplac3x3.Laplacian3x3Filter(out3x3);
            var out5x5 = (Bitmap)pictureBox1.Image;
            pictureBox3.Image = Laplac5x5.Laplacian5x5Filter(out5x5);
        }
    }
}
