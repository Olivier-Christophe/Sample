using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.API.DTO;
using Sample.DAL.Entities;
using Sample.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _cService;
        public CategoryController(CategoryService cService)
        {
            _cService = cService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Category> liste = _cService.Get();
                List<CategoryDTO> result = liste.Select(c => new CategoryDTO
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name,
                    
                }).ToList();
                return Ok(result);
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(CategoryAddDTO dto) 
        {
            Category c = new Category
            {
                Name = dto.Name
            };
            _cService.Add(c);
            return NoContent();
        }
   
    }
}
