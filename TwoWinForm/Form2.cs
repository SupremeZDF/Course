using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using TwoWinForm.Model;

namespace TwoWinForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadExercise.SixExercise();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThreadExercise.FiveExercise();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThreadPool.SetMaxThreads(10, 10);
            ThreadPool.GetAvailableThreads(out int maxWorkThreads, out int completionPortThreads);
            Console.WriteLine($"线程池中辅助线程的最大数目:{maxWorkThreads}, 线程池中异步 I/O 线程的最大数目{completionPortThreads}");

            TwoThreadExercise.OneTaskExercse();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TwoThreadExercise.OneTaskExercse();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TwoThreadExercise.ThreeTaskExercise();
        }
    }
}
