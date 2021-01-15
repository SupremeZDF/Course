using System;
using System.Collections.Generic;
using System.Text;

namespace Course04.Model.IoSerzlia
{
    public class TreeNodeTool
    {
        public int Id { get; set; }

        public string NodeName { get; set; }

        public List<TreeNodeTool> Childs { get; set; }
    }
}
