using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.ExperssionExercise
{
    public class TwoModelToolr
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ExpressGenericFuncAttrbuteTool("Age")]
        public int Ages { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string RuM;

        [ExpressGenericFuncAttrbuteTool("xn")]
        public int xns;
    }
}
