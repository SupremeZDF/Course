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
    public partial class Form2 : Form
    {
        public Form1 Form1 = null;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
        }

        public static bool bl = false;

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //文件夹对话框
            openFileDialog1.ShowDialog();
            openFileDialog1.Title = "请选择文件";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                var wewe = openFileDialog1.FileName;
                var fileExtend = Path.GetExtension(wewe);
                var i = fileExtend.LastIndexOf(".");
                string StrType = fileExtend.Substring(i);
                if (StrType == ".jpg" || StrType == ".gif" || StrType == ".jpeg" || StrType == ".png")
                {
                    bl = true;
                    textBox1.Text = fileExtend;
                }
                else
                {
                    bl = false;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "请选择文件路径";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) 
            {
                string foldPath = folderBrowserDialog1.SelectedPath;
                textBox2.Text = foldPath;
                //MessageBox.Show("");

            }
        }
    }
}
