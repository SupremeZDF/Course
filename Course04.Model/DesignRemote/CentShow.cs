using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.DesignRemote
{
    public class CentShow : KoujPerform, ICharge , IJueHuo
    {
        public override void DogVoice()
        {
            Console.WriteLine("中部狗叫");
        }

        /// <summary>
        /// 收费
        /// </summary>
        public void PersonCharge()
        {
            Console.WriteLine("中部收费");
        }

        public override void PersonVoice()
        {
            Console.WriteLine("中部人叫");
        }

        public override void WindVoidc()
        {
            Console.WriteLine("中部风声");
        }

        public event EventHandler startEvent;

        public event EventHandler ShowGC;

        public event EventHandler showEnd;


        /// <summary>
        /// 表演结束 
        /// </summary>
        public virtual void ShowEnd()
        {
            Console.WriteLine("中部表演结束");

            //ShowGC.Invoke();
        }

        public void JHShowContent()
        {
            Console.WriteLine("中部没有海，山多，内陆，有湖");
        }

        /// <summary>
        /// 表演开始
        /// </summary>
        public void show() 
        {
            this.Start();
            this.ShowTime();
            this.startEvent?.Invoke(this,new EventArgs() { });
            this.DogVoice();
            this.PersonVoice();
            this.WindVoidc();
            this.JHShowContent();
            this.ShowGC?.Invoke(this, new EventArgs() { });
            this.ShowEnd();
            this.PersonCharge();
            this.showEnd?.Invoke(this, new EventArgs() { });
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
