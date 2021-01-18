using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.Visible = true;
        }
    }
}
