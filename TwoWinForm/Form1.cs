using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwoWinForm.Model;
using System.Threading;

namespace TwoWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (var i = 0; i < 10; i++) 
            {
                Thread.Sleep(1000);
            }

            ThreadExercise.OneExercise();
            
            //Thread.
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThreadExercise.TwoExercise();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ThreadExercise.ThreeExercise();
        }
    }
}
