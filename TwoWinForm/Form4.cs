using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Threading;

namespace TwoWinForm
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            {
                //byte[] bytesTest = new byte[] { 192, 6 };
                //string strResult = "";
                //for (int i = 0; i < bytesTest.Length; i++)
                //{
                //    string strTemp = System.Convert.ToString(bytesTest[i], 2);
                //    strTemp = strTemp.Insert(0, new string('0', 8 - strTemp.Length));

                //    strResult += strTemp;
                //}

                byte[] ds = { 255 };

                //var t = Encoding.uni.GetString(ds);


                var d = "A";
                var by = Encoding.UTF8.GetBytes(d);

                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in by)
                {
                    stringBuilder.AppendFormat("{0:x2}", b);
                }

                foreach (var i in by)
                {
                    var dd = Convert.ToString(i, 2);
                    //var ii = Convert.ToByte(dd);
                    var ii = Convert.ToByte(dd, 2);
                }
            }

            {
                var dd = " AA";
                var be = Encoding.UTF8.GetBytes(dd);



                foreach (var i in be)
                {
                    var a = i.ToString("x2");
                    a = i.ToString("X2");

                    var b = i.ToString("X");
                    b = i.ToString("x");

                    var c = Convert.ToString(i, 2);
                }

            }

            {
                string input = "Hello World!";
                char[] values = input.ToCharArray();
                var da = "A";
                var by = Encoding.UTF8.GetBytes(da);
                by = Encoding.ASCII.GetBytes(da);
                var str = Convert.ToBase64String(by);
                var dd = Convert.FromBase64String(str);
            }


            //StreamWriter streamWriter = new StreamWriter();

            //StreamReader streamReader = new StreamReader();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rsaPKCS1SignatureDeformatter = new RSAPKCS1SignatureDeformatter();

            InitSign(@"D:\学习\eEncrypt\CA_证书\IIS\supremezdf.xyz.pfx", "65nfe4bpx43");  //私钥加密
        }
        // Token: 0x04000233 RID: 563
        private static RSAPKCS1SignatureFormatter rsaPKCS1SignatureFormatter;

        // Token: 0x04000234 RID: 564
        private static RSAPKCS1SignatureDeformatter rsaPKCS1SignatureDeformatter;

        public static void InitSign(string keystoreFile, string keystorePass)
        {
            try
            {
                {
                    X509Certificate2 x509Certificate = new X509Certificate2(@"D:\学习\架构版班_学习课程\Course1\TwoWinForm\Encryt\paytest.cer");
                    string xmlString = x509Certificate.PublicKey.Key.ToXmlString(false);
                    RSACryptoServiceProvider rsacryptoServiceProvider = new RSACryptoServiceProvider();
                    rsacryptoServiceProvider.FromXmlString(xmlString);
                }
                {
                    RSACryptoServiceProvider key = new RSACryptoServiceProvider();
                    rsaPKCS1SignatureFormatter = new RSAPKCS1SignatureFormatter(key);
                    X509Certificate2 x509Certificate = new X509Certificate2(keystoreFile, keystorePass, X509KeyStorageFlags.MachineKeySet);
                    rsaPKCS1SignatureFormatter.SetKey(x509Certificate.PrivateKey);
                    rsaPKCS1SignatureFormatter.SetHashAlgorithm("SHA1");
                }

            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
            catch (SystemException ex2)
            {
                throw ex2;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button3_Click(object sender, EventArgs e)
        {
            await ExerCise();
            //Thread.Sleep(10000);
            //Debug.WriteLine($"Start Start {Thread.CurrentThread.ManagedThreadId}");
        }

        public async Task ExerCise()
        {
            await OneRunName();

            Thread.Sleep(4000);
            //await ToExercise();

            //Thread.Sleep(10000);
            Debug.WriteLine($"主 {Thread.CurrentThread.ManagedThreadId}");
            //return a;
        }

        public async Task<int> ToExercise()
        {
            var task = Task.Run(() =>
            {
                Thread.Sleep(2000);
            });

            await task;


            Task.Run(() => 
            {
                Debug.WriteLine($"End  {Thread.CurrentThread.ManagedThreadId}");
                for (var i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                    Debug.WriteLine("1");
                }
            });

            return 1;
   
            //return null;
        }

        public async Task OneRunName()
        {
            Debug.WriteLine($"Start {Thread.CurrentThread.ManagedThreadId}");
            var task = Task.Run(() =>
            {

                Debug.WriteLine($"For End {Thread.CurrentThread.ManagedThreadId}");
                for (var i = 0; i < 5; i++)
                {
                    Debug.WriteLine(i);
                    Thread.Sleep(1000);
                }
                return "11";
            });

            await task;

            Task.Run(() =>
            {
                Debug.WriteLine($"End {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(4000);
                Debug.WriteLine($"End {Thread.CurrentThread.ManagedThreadId}");
            });
            Thread.Sleep(4000);

            //task.ContinueWith(s=> 
            //{
            Debug.WriteLine($"End {Thread.CurrentThread.ManagedThreadId}");
            //});

            //return await task;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine($"Start  {Thread.CurrentThread.ManagedThreadId}");
            //var i = ToExercise().Result;

            await A();
            for (var i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
            }
        }

        public async Task A() 
        {
            B();
            for (var i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
            }
        }

        public async Task B()
        {
            await C();
            for (var i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
            }
        }

        public async Task C()
        {
            Task task = Task.Run(() => 
            {
                for (var i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                }
            });

            await task;

            for (var i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
