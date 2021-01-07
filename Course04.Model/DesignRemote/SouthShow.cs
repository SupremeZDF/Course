using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.DesignRemote
{
    public class SouthShow : KoujPerform, ICharge , IJueHuo
    {

        public int T { get; set; }

        public string Wrou { get; set; }

        /// <summary>
        /// 炎热
        /// </summary>
        public void Heat() 
        {
            Console.WriteLine("炎热");
        }

        public override void DogVoice()
        {
            Console.WriteLine("南方狗叫");
        }

        //付费
        public void PersonCharge()
        {
            Console.WriteLine("南方收费");
        }

        public override void PersonVoice()
        {
            Console.WriteLine("南方收费");
        }

        public override void WindVoidc()
        {
            Console.WriteLine("南方风声");
        }

        /// <summary>
        /// 表演开始
        /// </summary>
        public override void ShowTime()
        {
            Console.WriteLine("南方表演开始");
        }

        public void JHShowContent()
        {
            Console.WriteLine("南方温度高，炎热，降雨多");
        }

        public override void MOvementEvent()
        {
            action += c=> { Console.WriteLine($"一起大户{c.CurrentWenDu}_{c.WenDu}"); };
            action += Movenent.fUDaHU;
            action += Movenent.SonDaHU;
            action += Movenent.EDaHU;
            action += Movenent.BQDaHU;
            action += Movenent.DogFDaHU;
        }
    }
}
