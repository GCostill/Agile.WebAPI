using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Models
{
    public class EmailRecieve
    {
        [Required]
        public string From { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field, limit to 50 characters!")]
        public string Subject { get; set; }

        [MaxLength(8000)]
        public string Body { get; set; }

        public bool HasAttachment { get; set; }
    }
}
