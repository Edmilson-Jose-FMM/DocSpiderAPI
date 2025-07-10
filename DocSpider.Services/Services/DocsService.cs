using DocSpider.Application.IServices;
using DocSpider.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSpider.Application.Services
{
    public class DocsService: IDocsServices
    {
        public SpiderDbContext _spiderDbContext;
        public DocsService(SpiderDbContext spiderDbContext)
        {
            _spiderDbContext = spiderDbContext;
        }

    }
}
