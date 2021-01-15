using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Course04.Model.IoSerzlia
{
    public class DirectoryToolModel
    {
        public DirectoryInfo Directorys { get; set; }

        public List<DirectoryToolModel> Childs { get; set; }
    }
}
