using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Models
{
    public class EmailList
    {
        public int EmailID { get; set; }

        public string To { get; set; }

        public string From { get; set; }

        public string Subject { get; set; }

        public bool HasAttachment { get; set; }

        public DateTime Time { get; set; }

        public string Category { get; set; }
    }
}
