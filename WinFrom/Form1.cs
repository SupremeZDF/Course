using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFrom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //DriveInfo[] driveInfos = DriveInfo.GetDrives();

            ////获取驱动盘符信息
            //foreach (DriveInfo drive in driveInfos)
            //{

            //    if (drive.IsReady)
            //    {
            //        Console.WriteLine($"{drive.DriveType}_{drive.VolumeLabel}_{drive.Name}_{drive.TotalSize}_{drive.TotalFreeSpace}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"{drive.DriveType}");
            //    }
            //}
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var code = textBox1.Text.ToLower();
            if (code == ImageTool.ImageTool.Code.ToLower())
            {
                var a = new Form2(this);
                this.Hide();
                a.ShowDialog();
            }
            else 
            {
                MessageBox.Show("验证失败");
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Convert.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ImageTool.ImageTool.CreateValidateGraphic();
            pictureBox1.BackgroundImage=Image.FromFile(ImageTool.ImageTool.ImageUrl);
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("退出成功");
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1_Load(null,null);
        }
    }
}
