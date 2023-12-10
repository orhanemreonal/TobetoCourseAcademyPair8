using Business.Abstracts;
using Business.DTOs.Requests;
using Core.Business.Requests;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryRequest createCategoryRequest) 
        {
            var result = await _categoryService.Add(createCategoryRequest); 
            return Ok(result);
            // [FromBody]: Bu öznitelik, category parametresinin değerinin istek gövdesinden alınması gerektiğini belirtir.
            // İstemci bir JSON yükü içeren bir istek gönderdiğinde,
            // ASP.NET Core otomatik olarak JSON'u bir Category nesnesine çözümleyecek ve bunu category parametresine bağlayacaktır.
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]PageRequest pageRequest)
        {
            var result = await _categoryService.GetListAsync(pageRequest); 
            return Ok(result);
        }
    }
}
