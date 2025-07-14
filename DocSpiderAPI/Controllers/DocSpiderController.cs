using DocSpider.Application.IServices;
using DocSpider.Domain.DTOs;
using DocSpider.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DocSpider.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocSpiderController : ControllerBase
    {

            private readonly IDocsServices _docsService;
            public DocSpiderController(IDocsServices docsService)
            {
                _docsService = docsService;
            }
            [HttpGet("GetById")]
            public async Task<ActionResult<Documents>> DocsGet(long id)
            {
            try
            {
                return await _docsService.GetDocumentById(id);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            }

            [HttpGet]
            public async Task<PagedItens> DocPaginatedWithFilters(int pageNumber, int pageSize, string? title, string? name)
            {
                return await _docsService.GetMoviesPaginatedWithFilters(pageNumber, pageSize, title, name);

            }

            [HttpDelete]
            public async Task<ActionResult<bool>> DeleteDocById(long id)
            {
            try
            {
                return await _docsService.DeleteDocumentById(id);
            }catch(Exception err)
            {
                throw new Exception(err.Message);
            }
            }
            [HttpPost]
            public async Task<ActionResult<string>> InsertDoc([FromForm] DocumentsDTO doc)
            {
            try
            {
                return await _docsService.InsertDocument(doc); 
            }catch(Exception err)
            {
                throw new Exception(err.Message);
            }
            }

            [HttpPut]
            public async Task<ActionResult<string>> UpdateDoc(long id, DocumentsDTO doc)
            {
            try
            {
                return await _docsService.UpdateDocument(doc, id);
            }catch(Exception err)
            {
                throw new Exception(err.Message);
            }
            }

        [HttpGet("{id}/download")] 
        public async Task<IActionResult> DownloadDocument(long id)
        {

            var document = await _docsService.GetDocumentById(id);

            if (document == null || document.Doc == null)
            {
                return NotFound("Documento não encontrado.");
            }
            return File(document.Doc,document.ContentType,document.Name);
        }
    }
    }

