using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFrom.ImageTool
{
    public class ImageTool
    {

        public static string ImagePath = "D:\\学习\\架构版班_学习课程\\ImagePath";

        public static string imageName = "";

        public static string Code = "";

        public static string ImageUrl = "";

        //生成随机的字符串
        public static string CreateRandomCode(int codeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,a,b,c,d,e,f,g,h,i,g,k,l,m,n,o,p,q,r,F,G,H,I,G,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,s,t,u,v,w,x,y,z";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(35);
                if (temp == t)
                {
                    return CreateRandomCode(codeCount);
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }

        /// <summary>
        /// 创建验证码图片
        /// </summary>
        /// <param name="validateCode">验证码无干扰字符串</param>
        /// <returns></returns>
        public static void CreateValidateGraphic()
        {
            string validateCode = CreateRandomCode(6);
            Code = validateCode;
            //绘图的原理很简单：Bitmap就像一张画布，Graphics如同画图的手，把Pen或Brush等绘图对象画在Bitmap这张画布上
            //画布
            Bitmap bitmap = new Bitmap((int)Math.Ceiling(validateCode.Length * 22.0), 40);
            //手
            Graphics graphics = Graphics.FromImage(bitmap);
            try
            {
                //生成随机数
                Random random = new Random();
                //清空图片背景颜色
                graphics.Clear(Color.White);
                //画图片的干扰线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(bitmap.Width);
                    int x2 = random.Next(bitmap.Width);
                    int x3 = random.Next(bitmap.Height);
                    int x4 = random.Next(bitmap.Height);
                    //笔
                    graphics.DrawLine(new Pen(Color.Silver), x1, x2, x3, x4);
                }
                Font font = new Font("Arial", 20, (FontStyle.Bold | FontStyle.Italic));
                //Rectangle 矩形
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, bitmap.Width, bitmap.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                graphics.DrawString(validateCode, font, brush, 3, 2);
                //画图片的前景的干扰线
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(bitmap.Width);
                    int y = random.Next(bitmap.Height);
                    bitmap.SetPixel(x, y, Color.FromArgb(random.Next()));
                    //画图片的边框线
                    graphics.DrawRectangle(new Pen(Color.Silver), 0, 0, bitmap.Width - 1, bitmap.Height - 1);
                }
                imageName = Guid.NewGuid().ToString();
                ImageUrl = Path.Combine(ImagePath, imageName);
                bitmap.Save(ImageUrl, ImageFormat.Jpeg);
                //保存图片数据
                //MemoryStream memoryStream = new MemoryStream();
                //bitmap.Save(memoryStream, ImageFormat.Jpeg);
                //var by = memoryStream.ToArray();
                //释放所有对象
                graphics.Dispose();
                bitmap.Dispose();
                //return by;
            }
            catch (Exception ex)
            {
                graphics.Dispose();
                bitmap.Dispose();
                //return new byte[] {};
            }
        }
    }
}
