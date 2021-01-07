using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.DesignRemote
{
    public class NorthShow : KoujPerform, ICharge, IJueHuo
    {

        /// <summary>
        /// 温度
        /// </summary>
        public string Temper { get; set; }

        /// <summary>
        /// 威武
        /// </summary>
        public string WeiW { get; set; }

        /// <summary>
        /// 打架
        /// </summary>
        public void Fight()
        {
            Console.WriteLine("打架");
        }

        public override void DogVoice()
        {
            Console.WriteLine("北方狗叫");
        }

        /// <summary>
        /// 收费
        /// </summary>
        public void PersonCharge()
        {
            Console.WriteLine("北方收费");
        }

        public override void PersonVoice()
        {
            Console.WriteLine("北方人叫");
        }

        public override void WindVoidc()
        {
            Console.WriteLine("北方风声");
        }

        /// <summary>
        /// 表演开始
        /// </summary>
        public override void ShowTime()
        {
            Console.WriteLine("西方表演开始");
        }

        /// <summary>
        /// 表演结束
        /// </summary>
        public override void ShowEnd()
        {
            Console.WriteLine("北方表演结束");
        }

        public void JHShowContent()
        {
            Console.WriteLine("温度低，人威武要打架");
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
