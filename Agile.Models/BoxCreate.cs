using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Models
{
    public class BoxCreate
    {
        [Key]
        public string Category { get; set; }
    }

    public class BoxDetail
    {
        public int BoxId { get; set; }
        public string Category { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
    }
}
