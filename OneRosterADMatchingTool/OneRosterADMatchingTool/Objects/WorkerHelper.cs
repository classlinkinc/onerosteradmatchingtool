using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneRosterMatchingTool.Objects
{
    internal class WorkerHelper : BackgroundWorker
    {
        public List<OneUser> oneUserList { get; set; }
        public List<OneUser> missingUsers { get; set; }
        public List<OneUser> foundUsers { get; set; }
    }
}
