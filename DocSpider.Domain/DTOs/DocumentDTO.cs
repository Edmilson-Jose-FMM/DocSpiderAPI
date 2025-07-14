using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSpider.Domain.DTOs
{
    public class DocumentDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? UploadDate { get; set; }
        public string? LastEditionDate { get; set; }
        public byte[]? Doc { get; set; }
    }
}
