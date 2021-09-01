using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Models
{
    public class EmailReply
    {
        public int EmailId { get; set; }

        [MaxLength(8000)]
        public string Body { get; set; }

        public bool HasAttachment { get; set; }
    }
}
