using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Course03.Model.Model
{
    public class OneModel
    {
        //定义两个字段信息
        private string name;
        private string password;

        //定义一个 Name 属性来操作 name 字段
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        //定义一个 Password 属性来操作 password 字段
        public string Password
        {
            set { password = value; }
            get { return password; }
        }

        public string this[string index] 
        {
            get {
                if (index == "Name") { return Name; } else if (index == "Password") { return Password; } else return "";
            }
            set
            {
                if (index == "Name") {Name=value; } else if (index == "Password") { Password=value; } 
            }
        }
    }

    public class TwoMdodel 
    {
        private string _name;
        private int _courseid;
        private int _score;
        public TwoMdodel(string _name, int _courseid, int _score)
        {
            this._name = _name;
            this._courseid = _courseid;
            this._score = _score;
        }
        public string Name
        {
            get { return _name; }
            set { this._name = value; }
        }
        public int CourseID
        {
            get { return _courseid; }
            set { this._courseid = value; }
        }
        public int Score
        {
            get { return _score; }
            set { this._score = value; }
        }
    }

    public class ThreeModel 
    {
        private ArrayList arr;
        public ThreeModel()
        {
            arr = new ArrayList();
        }
        public int this[string _name, int _courseid]
        {
            get
            {
                foreach (TwoMdodel a in arr)
                {
                    if (a.Name == _name && a.CourseID == _courseid)
                    {
                        return a.Score;
                    }
                }
                return -1;
            }
            set
            {
                arr.Add(new TwoMdodel(_name, _courseid, value)); //arr["张三",1]=90
            }
        }
        //重载索引器
        public ArrayList this[string _name]
        {
            get
            {
                ArrayList temp = new ArrayList();
                foreach (TwoMdodel b in arr)
                {
                    if (b.Name == _name)
                    {
                        temp.Add(b);
                    }
                }
                return temp;
            }
        }
    }
}
