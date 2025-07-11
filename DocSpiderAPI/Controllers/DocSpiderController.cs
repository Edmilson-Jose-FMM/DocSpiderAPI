using DocSpider.Application.IServices;
using DocSpider.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DocSpider.API.Controllers
{
    public class DocSpiderController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class MoviesController : ControllerBase
        {
            private readonly IDocsServices _docsService;
            public MoviesController(IDocsServices docsService)
            {
                _docsService = docsService;
            }
            [HttpGet("GetById")]
            public async Task<ActionResult<Documents>> MoviesGet(int id)
            {
                return null;

            }

            [HttpGet("GetPaginatedWithFilters")]
            public async Task<Documents> MoviesPaginatedWithFilters(string? genrer, string? status, bool adult, int page, int perPage, string? title)
            {
                return null;

            }

            [HttpDelete]
            public async Task<ActionResult> DeleteMoviesById(int id)
            {
                return null;

            }
            [HttpPost]
            public async Task<ActionResult> InsertMovie(Documents movie)
            {
                return null;

            }

            [HttpPut]
            public async Task<ActionResult> UpdateMovie(int id, Documents movie)
            {
                return null;

            }
        }
    }
}
