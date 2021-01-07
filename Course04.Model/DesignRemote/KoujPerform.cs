using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.DesignRemote
{
    public abstract class KoujPerform
    {
        [AttrbutePatamete(propertyOrparameterName = "person")]
        public string Person { get; set; }

        [AttrbutePatamete(propertyOrparameterName = "Desk")]
        public string Desk { get; set; }

        public string Chair { get; set; }

        /// <summary>
        /// 事件
        /// </summary>
        public event EventHandler TEvent;

        /// <summary>
        /// 方法事件
        /// </summary>
        public Action<KoujPerform> action;

        /// <summary>
        /// 温度
        /// </summary>
        public int WenDu { get; set; }

        private int _CurrentWenDu;

        /// <summary>
        /// 当前温度
        /// </summary>
        public virtual int CurrentWenDu  {  set
            {
                _CurrentWenDu = value;
                if (value > WenDu)
                {
                    TEvent += new EventTool().OneEvent;
                    TEvent?.Invoke(this, new WenduEventArages() { WenDuRD = WenDu, CurRentWenDu = value });
                    MOvementEvent();
                    action?.Invoke(this);
                }
            } get { return _CurrentWenDu; } }


        /// <summary>
        /// 动作事件
        /// </summary>
        public abstract void MOvementEvent();

        /// <summary>
        /// 扇子
        /// </summary>
        [AttrbutePatamete(propertyOrparameterName = "Fan")]
        public string Fan { get; set; }

        public string Ruler { get; set; }

        public void Start()
        {
            Console.WriteLine("表演开始了");
        }

        /// <summary>
        /// 狗叫
        /// </summary>
        public abstract void DogVoice();

        /// <summary>
        /// 人叫
        /// </summary>
        public abstract void PersonVoice();

        /// <summary>
        /// 风声
        /// </summary>
        public abstract void WindVoidc();

        /// <summary>
        /// 表演开始
        /// </summary>
        public virtual void ShowTime()
        {
            Console.WriteLine("表演开始");
        }

        /// <summary>
        /// 表演结束
        /// </summary>
        public virtual void ShowEnd()
        {
            Console.WriteLine("表演结束");
        }
    }

    public class Movenent 
    {
        public static void DaHU(KoujPerform koujPerform) 
        {
            Console.WriteLine("一起大户");
        }

        public static void fUDaHU(KoujPerform koujPerform)
        {
            Console.WriteLine("夫一起大户");
        }

        public static void SonDaHU(KoujPerform koujPerform)
        {
            Console.WriteLine("两儿一起大户");
        }

        public static void EDaHU(KoujPerform koujPerform)
        {
            Console.WriteLine("饿一起大户");
        }

        public static void BQDaHU(KoujPerform koujPerform)
        {
            Console.WriteLine("百千一起大户");
        }

        public static void DogFDaHU(KoujPerform koujPerform)
        {
            Console.WriteLine("犬一起大户");
        }
    }
}
