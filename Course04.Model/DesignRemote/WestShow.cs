using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.DesignRemote
{
    public class WestShow : KoujPerform, ICharge , IJueHuo
    {

        public int HB { get; set; }

        public int Wind { get; set; }

        public void GH() 
        {
            Console.WriteLine("干旱");
        }

        public override void DogVoice()
        {
            Console.WriteLine("西方狗叫");
        }

        /// <summary>
        /// 收费
        /// </summary>
        public void PersonCharge()
        {
            Console.WriteLine("西方收费");
        }

        public override void PersonVoice()
        {
            Console.WriteLine("西方人叫");
        }

        public override void WindVoidc()
        {
            Console.WriteLine("西方风声");
        }


        /// <summary>
        /// 表演结束
        /// </summary>
        public virtual void ShowEnd()
        {
            Console.WriteLine("西方表演结束");
        }

        public void JHShowContent()
        {
            Console.WriteLine("西方海拔高，有大风，冷");
        }

        public override void MOvementEvent()
        {
            action += c => { Console.WriteLine($"一起大户{c.CurrentWenDu}_{c.WenDu}"); };
            action += Movenent.fUDaHU;
            action += Movenent.SonDaHU;
            action += Movenent.EDaHU;
            action += Movenent.BQDaHU;
            action += Movenent.DogFDaHU;
        }
    }
}
