using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            button2.Enabled = true;
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> vs = new List<string>();
            vs.Add("123");
            vs.Add("23");

            var a = vs.Contains("1");
            var b = vs.Contains("23");

            //FourThreadExercise.OneRunThread();
            //this.Invoke()

            IEnumerable<string> vs1=new List<string>();

            vs1.ElementAt(12);
        }

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
           

      

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = "运行 ing";
            button2.Enabled = false;
            button3.Enabled = true;
            Bl = true;
            Red1.Text = "00";
            Red2.Text = "00";
            Red3.Text = "00";
            Red4.Text = "00";
            Red5.Text = "00";
            Red6.Text = "00";
            Blue7.Text = "00";


            foreach (var i in groupBox1.Controls) 
            {
                if (i is Label) 
                {
                    Label label = (Label)i;
                    if (label.Name.Contains("Blue")) 
                    {
                        tasks.Add(Task.Run(() => 
                        {
                            try
                            {
                                while (Bl)
                                {
                                    //获取随机数
                                    // 获取随机数
                                    //循环
                                    int indx = SSQModelTool.GetSjZZ(0, 16);
                                    string sNumber = SSQModelTool.BlueSSQ[indx];
                                    //更新解面  线程 无法操作 UI 线程
                                    //委托给主线程执行
                                    this.Invoke(new Action(() =>
                                    {
                                        label.Text = sNumber;
                                    }));
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                           
                        }));
                    }
                    if (label.Name.Contains("Red")) 
                    {
                        tasks.Add(Task.Run(() => 
                        {
                            try
                            {
                                while (Bl)
                                {
                                    //获取随机数
                                    // 获取随机数
                                    //循环
                                    int indx = SSQModelTool.GetSjZZ(0, 33);
                                    string sNumber = SSQModelTool.RedSSQ[indx];
                                    //更新解面  线程 无法操作 UI 线程
                                    //委托给主线程执行

                                    lock (DD) 
                                    {
                                        List<string> vs = GetSSQListString();
                                        if (!vs.Contains(sNumber))
                                        {
                                            //丢给 ui 线程执行 （主线程） 主线程阻塞 容易死锁
                                            this.Invoke(new Action(() =>
                                            {
                                                //Thread.Sleep(2000);
                                                //Debug.WriteLine("1");
                                                label.Text = sNumber;
                                            }));
                                            //Debug.WriteLine("2");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                
                            }  
                        }));
                    }
                }
            }
            TaskFactory taskFactory = new TaskFactory();

            //后台任务  线程执行玩的后续任务
            taskFactory.ContinueWhenAll(tasks.ToArray(), task =>
             { 
                  //执行一系列动作
             });
        }

        private readonly static object DD = new object();

        private bool Bl;

        private List<Task> tasks =new List<Task>();

        public  List<string> GetSSQListString() 
        {
            List<string> vs = new List<string>();
            var i = groupBox1.Controls;
            foreach (var j in i) 
            {
                if (j is Label)
                {
                    Label label = (Label)j;
                    if (label.Name.Contains("Red")) 
                    {
                        vs.Add(label.Text);
                    }
                }
            }

            Task.Delay(1000).ContinueWith((task)=> { });

            if (vs.Distinct().Count() < 6) 
            {
            
            }
            return vs;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Text = "Start";
            Bl = false;
            button2.Enabled = true;
            button3.Enabled = false;

            //Task.WaitAll(tasks.ToArray()); //会死锁

            //Task.Run(()=> {
            //    Task.WaitAll(tasks.ToArray());
            //});
        }
    }
}
