using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gistogramma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pictureBox1.ImageLocation = "https://foto.hrsstatic.com/fotos/0/3/256/256/80/FFFFFF/http%3A%2F%2Ffoto-origin.hrsstatic.com%2Ffoto%2F4%2F3%2F9%2F8%2F%2Fteaser_439803.jpg/vJZAboPVZO02CzB1GJ3JPA%3D%3D/1024%2C868/6/ibis_Moscow_Paveletskaya-Moscow-Single_room_standard-439803.jpg";
            pictureBox1.ImageLocation = "lenna.png";
        }

        private void button2_Click(object sender, EventArgs e)
        {
           pictureBox2.Image = new Bitmap(pictureBox1.Image).Equalize(color => color.R, (color, index) => Color.FromArgb(color.A, index, color.G, color.B));
        }
    }
}
