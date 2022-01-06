using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURLAPI.AppDbContext
{
    public class ShortLink
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(4000)]
        public string LongUrl { get; set; }
        
        [MaxLength(400)]
        public string ShortUrl { get; set; }
        public DateTime Date { get; set; }
    }
}
