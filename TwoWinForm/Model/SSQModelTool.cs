using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwoWinForm.Model
{
    public class SSQModelTool
    {
         public static string [] RedSSQ = {"01","02", "03", "04", "05", "06", "07", "08", "09", "10",
        "11","12","13","14","15","16","17","18","19","20","21","22","23","24","25","26","27","28","29","30","31","32","33"};

        public static string[] BlueSSQ = {"01","02", "03", "04", "05", "06", "07", "08", "09", "10",
        "11","12","13","14","15","16"};

        public static int RanDomSJZZ(int min, int max)  
        {
            var guid = Guid.NewGuid().ToString();

            int seed = DateTime.Now.Millisecond;

            for (var i = 0; i < guid.Length; i++) 
            {
                switch (guid[i]) 
                {
                    case 'a':
                    case 'b':
                    case 'c':
                    case 'd':
                    case 'e':
                    case 'f':
                    case 'g':
                        seed += 10;
                        break;
                    case 'h':
                    case 'i':
                    case 'j':
                    case 'k':
                    case 'l':
                    case 'm':
                    case 'n':
                        seed += 15;
                        break;
                    case 'o':
                    case 'p':
                    case 'q':
                    case 'r':
                    case 's':
                    case 't':
                        seed += 20;
                        break;
                    case 'u':
                    case 'v':
                    case 'w':
                    case 'x':
                    case 'y':
                    case 'z':
                        seed += 25;
                        break;
                }
            }
            Random random = new Random(seed);
            return random.Next(min, max); 
        }

        public static int GetSjZZ(int min ,int max) 
        {
            Thread.Sleep(RanDomSJZZ(1000,2000));
            return RanDomSJZZ(min,max);
        }
    }
}
