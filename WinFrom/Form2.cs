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

        public static string ImageTypeName = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("文件路径与保存路径不能为空");

            }
            else
            {
                if (textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("缩放比列不能为空");
                }
                else
                {
                    if (!File.Exists(textBox1.Text))
                    {
                        MessageBox.Show("文件为空");
                    }
                    else
                    {
                        if (!Directory.Exists(textBox2.Text))
                        {
                            MessageBox.Show("不存在此文件夹");
                        }
                        else
                        {
                            if (ImageTypeName == "")
                            {
                                MessageBox.Show("请选择压缩保存格式");
                            }
                            else 
                            {
                                var savPath = Path.Combine(textBox2.Text, Guid.NewGuid().ToString()) + ImageTypeName;
                                var bl = ImageTool.ImageTool.CompressPercent(textBox1.Text, savPath, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                                if (bl == true)
                                {
                                    MessageBox.Show("成功");
                                }
                                else
                                {
                                    MessageBox.Show("失败");
                                }
                            }
                        }
                    }

                }
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("退出成功");
            System.Environment.Exit(0);
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
                    textBox1.Text = wewe;
                    pictureBox1.BackgroundImage = Image.FromFile(textBox1.Text);
                    pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    MessageBox.Show("文件格式有误");
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ImageTypeName = ".jpg";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ImageTypeName = ".jpeg";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ImageTypeName = ".png";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
