using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSpider.Domain.DTOs
{
    public class DocumentsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime LastEditionDate { get; set; }
        public byte[] Doc { get; set; }
    }
}
