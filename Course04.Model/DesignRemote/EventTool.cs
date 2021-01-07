using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Course04.Model.DesignRemote
{
    public class EventTool
    {
        public static void OnRun<T>(T t) where T : KoujPerform,ICharge
        {
            if (t == null) return;
            var obj = t.GetType();
            foreach (PropertyInfo info in obj.GetProperties())
            {
                if (info.IsDefined(typeof(AttrbutePatamete), true)) 
                {
                    AttrbutePatamete attrbutePatamete = (AttrbutePatamete)info.GetCustomAttributes(typeof(AttrbutePatamete), true)[0];
                    Console.WriteLine(attrbutePatamete.propertyOrparameterName + ":" + info.GetValue(t));
                    continue;
                }
                Console.WriteLine(info.Name + ":" + info.GetValue(t));
            }

            foreach (FieldInfo info in obj.GetFields())
            {
                if (info.IsDefined(typeof(AttrbutePatamete), true))
                {
                    AttrbutePatamete attrbutePatamete = (AttrbutePatamete)info.GetCustomAttributes(typeof(AttrbutePatamete), true)[0];
                    Console.WriteLine(attrbutePatamete.propertyOrparameterName + ":" + info.GetValue(t));
                    continue;
                }
                Console.WriteLine(info.Name + ":" + info.GetValue(t));
            }

            t.Start();
            t.ShowTime();
            t.DogVoice();
            t.PersonVoice();
            t.WindVoidc();
            t.ShowEnd();
            //收费
            t.PersonCharge();
        }


        public static void TwoRun<T>(T t) where T : KoujPerform, ICharge, IJueHuo
        {
            t.JHShowTime();
            t.JHShowContent();
            t.JHShowEnd();
        }

        /// <summary>
        /// 东方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OneEvent(object? sender, EventArgs e)
        {
            var _object = sender;
            var _e = e;
        }

        /// <summary>
        /// 南方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TwoEvent(KoujPerform? sender, EventArgs e)
        {
            var _object = sender;
            var _e = e;
        }

        /// <summary>
        /// 西方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ThreeEvent(object? sender, EventArgs e)
        {
            var _object = sender;
            var _e = e;
        }

        /// <summary>
        /// 北方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FourEvent(KoujPerform? sender, EventArgs e)
        {
            var _object = sender;
            var _e = e;
        }
    }

}
