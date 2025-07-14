using DocSpider.Domain.DTOs;
using DocSpider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSpider.Application.IServices
{
    public interface IDocsServices
    {
        Task<string> InsertDocument(DocumentsDTO doc);
        Task<Documents> GetDocumentById(long id);
        Task<bool> DeleteDocumentById(long id);
        Task<string> DeleteDocOnly(long id);
        Task<PagedItens> GetMoviesPaginatedWithFilters(int pageNumber, int pageSize, string? title, string? name);
        Task<string> UpdateDocument(DocumentsDTO doc, long id);
    }
}
