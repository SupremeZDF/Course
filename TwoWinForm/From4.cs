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
    public partial class From4 : Form
    {
        public From4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FourThreadExercise.OneRunThread();
            //this.Invoke()
        }
    }
}
