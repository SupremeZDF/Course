using Course04.Model.Model;
using Course04.Model.sqlLin1Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.LinqModel
{
    [SqlTableName(TableName = "T_User")]
    public class T_userModelTable : BaseModel
    {
        [SqlTableColumnNameAttrbute(Identity =true,isPrikey =true)]
        public Int32 id { get; set; }

        public string Account_Number { get; set; }

        public string User_Name { get; set; }

        public string Gender { get; set; }

        public string Password { get; set; }

        public string IntroDuce { get; set; }

        public string Place_Of_Abode { get; set; }

        public string InduStry { get; set; }

        public string ProFessionAl { get; set; }

        public string Education_Experieuce { get; set; }

        public string Indirdual { get; set; }

        [SqlTableColumnNameAttrbute(ColumnName = "Image")]
        public string Imageadsasdasd { get; set; }

        public int User_Mode { get; set; }
    }
}
