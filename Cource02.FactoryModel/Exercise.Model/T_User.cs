using Cource02.FactoryModel.Exercise.Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cource02.FactoryModel.Exercise.Model
{
    [ORMTableTool(TableName = "T_User")]
    public class T_User : ExerciseBaseModel
    {
        [ORMTableTool(Identity = true)]
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

        public string Image { get; set; }

        public int User_Mode { get; set; }

        public string N;

        public static string W { get; set; }
    }

    public class T_Admin : ExerciseBaseModel 
    {
    
    }
}
