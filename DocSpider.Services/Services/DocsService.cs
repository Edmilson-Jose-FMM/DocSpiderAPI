using DocSpider.Application.IServices;
using DocSpider.Domain.Entities;
using DocSpider.Infra.Context;
using System.Net;
using System.Reflection.Metadata;


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
        public async Task<Documents> GetDocumentById(long id)
        {
            var movie = await _spiderDbContext.Documents.FindAsync(id);

            if (movie == null)
                throw new Exception($"Movie not found by ID: {id}");

            return movie;
        }
        public async Task<bool> DeleteDocumentById(long id)
        {
            var movie = await _spiderDbContext.Documents.FindAsync(id);

            if (movie == null)
                throw new Exception("Document not found to be deleted");
            _spiderDbContext.Documents.Remove(movie);
            await _spiderDbContext.SaveChangesAsync();

            return true;
        }
        public async Task<string> InsertDocument(Documents doc)
        {

            if (doc.Title == null)
                throw new Exception("Title field cannot be empty");
            await _spiderDbContext.Documents.AddAsync(doc);
            _spiderDbContext.SaveChanges();

            return $"Doc added!";

        }
    }
}
