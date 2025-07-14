using DocSpider.Application.IServices;
using DocSpider.Infra.Context;
using System.Net;


namespace DocSpider.Application.Services
{
    public class DocsService: IDocsServices
    {
        public SpiderDbContext _spiderDbContext;
        public DocsService(SpiderDbContext spiderDbContext)
        {
            _spiderDbContext = spiderDbContext;
        }


        public async Task<string> DeleteDocOnly(int id)
        {
            var doc = await _spiderDbContext.Documents.FindAsync(id);
            if (doc == null)
                return "Movie not found to be deleted";
            
            doc.Doc = null;
            await _spiderDbContext.SaveChangesAsync();
            
            return "Document deleted";
        }
    }
}
