using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Data
{
    public class EmailData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public string Subject { get; set; }

        public string Body { get; set; }

        public bool HasAttachment { get; set; }

        public DateTime Time { get; set; }

        public string Category { get; set; }
    }
}