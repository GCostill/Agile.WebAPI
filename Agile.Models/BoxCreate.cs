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
        public int BoxId { get; set; }
        
        [Required]
        public string To { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string Subject { get; set; }
        
        [Required]
        public string Category { get; set; }
    }
}
