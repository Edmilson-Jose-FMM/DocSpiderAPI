using DocSpider.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSpider.Domain.Entities
{
    public class PagedItens
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int TotalCount { get; set; }
        public List<DocumentDTO> Documents { get; set; } = new List<DocumentDTO>();
    }
}
