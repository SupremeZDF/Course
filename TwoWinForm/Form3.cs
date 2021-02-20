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

namespace TwoWinForm
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            ThreThreadExercise.OneThreadExercise();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThreThreadExercise.TwoThreadRunExercise();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThreThreadExercise.ThreeThreadExercise();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < 1; i++) 
            {
                Task.Run(()=> 
                {
                    ThreThreadExercise threThread = new ThreThreadExercise();
                    threThread.OneName();
                });
                Task.Run(() =>
                {
                    ThreThreadExercise threThread = new ThreThreadExercise();
                    threThread.TwoName();
                });
            }
        }
    }
}
