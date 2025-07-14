using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSpider.Domain.Entities
{
    public class Documents
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Upload_Date { get; set; }
        public DateTime LastEditionDate { get; set; }
        public byte[]? Doc { get; set; }
        public string? ContentType { get; set; }
    }
}
