using Course04.Model.Model;
using Course04.Model.sqlLin1Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.LinqModel
{
    [SqlTableName(TableName = "T_Question")]
    public class T_QuestionTable : BaseModel
    {
        [SqlTableColumnNameAttrbute(Identity = true, isPrikey = true)]
        public int? id { get; set; }

        public string Image { get; set; }

        public string Headline { get; set; }

        public string Content { get; set; }

        public int? IssuestateID { get; set; }

        public int? UserID { get; set; }

        public int? IssusClassifYid { get; set; }

        public DateTime? DataTime { get; set; }
    }
}
