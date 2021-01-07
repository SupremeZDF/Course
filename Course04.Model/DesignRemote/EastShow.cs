using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.DesignRemote
{
    public class EastShow : KoujPerform, ICharge, IJueHuo
    {
        public int HB { get; set; }

        public void Raining() 
        {
            Console.WriteLine("下雨");
        }

        /// <summary>
        /// 海拔
        /// </summary>
        public double Money { get; set; }

        public override void DogVoice()
        {
            Console.WriteLine("东方狗叫");
        }

        //付费
        public void PersonCharge()
        {
            Console.WriteLine("东方收费");
        }

        public override void PersonVoice()
        {
            Console.WriteLine("东方收费");
        }

        public override void WindVoidc()
        {
            Console.WriteLine("东方风声");
        }

        public void JHShowContent()
        {
            Console.WriteLine("东方海拔低，有长江，money多，降雨多");
        }

        public override void MOvementEvent()
        {
            action += Movenent.DaHU;
            action += Movenent.fUDaHU;
            action += Movenent.SonDaHU;
            action += Movenent.EDaHU;
            action += Movenent.BQDaHU;
            action += Movenent.DogFDaHU;
        }
    }
}
