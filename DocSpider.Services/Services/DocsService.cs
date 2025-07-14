using DocSpider.Application.IServices;
using DocSpider.Domain.DTOs;
using DocSpider.Domain.Entities;
using DocSpider.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mime;
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

        public async Task<PagedItens> GetMoviesPaginatedWithFilters(int pageNumber, int pageSize, string? title, string? name)
        {
             PagedItens pagedItens = new PagedItens();
            var result = _spiderDbContext.Documents.AsQueryable();

            if (title != null)
            {
                result = result.Where(p => EF.Functions.ILike(p.Title, $"{title}%"));
            }
            if (name != null)
            {
                result = result.Where(p =>
                                           EF.Functions.ILike(p.Name, $"%{name},%"));
            }
     
            if (pageNumber == 0 && pageSize == 0)
            {
                pageNumber = 1;
                pageSize = 5;
            }

            result = result.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            var docsAux = await result.AsNoTracking().ToListAsync();
            
            foreach(var doc in docsAux)
            {
                DocumentDTO documentDTO = new DocumentDTO();
                documentDTO.Id = doc.Id;
                documentDTO.Name = doc.Name;
                documentDTO.Doc = doc.Doc;
                documentDTO.LastEditionDate = doc.LastEditionDate.ToString("dd/MM/yyyy HH:mm");
                documentDTO.UploadDate = doc.Upload_Date.ToString("dd/MM/yyyy HH:mm");
                documentDTO.Description = doc.Description;
                documentDTO.Title = doc.Title;
                pagedItens.Documents.Add(documentDTO);
            }

            pagedItens.Page = pageNumber;
            pagedItens.PerPage = pageSize;
            pagedItens.TotalCount =  _spiderDbContext.Documents.ToList().Count();
           
            return pagedItens;

        }
        public async Task<string> DeleteDocOnly(long id)
        {
            var doc = await _spiderDbContext.Documents.FindAsync(id);
            if (doc == null)
                return "Document not found to be deleted";
            
            doc.Doc = null;
            await _spiderDbContext.SaveChangesAsync();
            
            return "Document deleted";
        }
        public async Task<Documents> GetDocumentById(long id)
        {
            var doc = await _spiderDbContext.Documents.FindAsync(id);

            if (doc == null)
                throw new Exception($"Document not found by ID: {id}");

            return doc;
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
        public async Task<string> InsertDocument(DocumentsDTO doc)
        {
            if (doc.Doc == null || doc.Doc.Length == 0)
            {
                return ("Nenhum arquivo foi enviado.");
            }
            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                await doc.Doc.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }
            if (doc.Title == null)
                throw new Exception("Title field cannot be empty");

            var document = new Documents
            {
                Title = doc.Title,
                Description = doc.Description,
                Name = doc.Doc.FileName,
                Upload_Date = DateTime.UtcNow, 
                LastEditionDate= DateTime.UtcNow,
                Doc = fileBytes,
                ContentType = doc.Doc.ContentType
            };

            await _spiderDbContext.Documents.AddAsync(document);
            _spiderDbContext.SaveChanges();

            return $"Doc added!";

        }
        public async Task<string> UpdateDocument(DocumentsDTO doc, long id)
        {
            try
            {
                var UpdatedDoc = await _spiderDbContext.Documents.FindAsync(id);

                if (UpdatedDoc == null)
                    throw new Exception("Document not found to be Updated");

                if (doc.Title == null)
                    throw new Exception("Title field cannot be empty");
                if (doc.Doc != null)
                {
                    byte[] fileBytes;
                    using (var memoryStream = new MemoryStream())
                    {
                        await doc.Doc.CopyToAsync(memoryStream);
                        fileBytes = memoryStream.ToArray();
                    }
                    UpdatedDoc.Doc = fileBytes;
                    UpdatedDoc.ContentType = doc.Doc.ContentType;
                }

                UpdatedDoc.Title = doc.Title;
                UpdatedDoc.LastEditionDate = DateTime.UtcNow;
                UpdatedDoc.Description = doc.Description;


                _spiderDbContext.SaveChanges();

                return $"Doc Updated!";
            }catch(Exception err)
            {
                throw new Exception(err.Message);
            }

        }
    }
}
