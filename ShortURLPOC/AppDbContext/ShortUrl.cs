using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURLPOC.AppDbContext
{
    public class ShortLinks
    {
        [Key]
        public int Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public DateTime Date { get; set; }
    }
}
