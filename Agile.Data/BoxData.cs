using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agile.Data
{
    public class BoxData
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public DateTime Time { get; set; }
    }
}