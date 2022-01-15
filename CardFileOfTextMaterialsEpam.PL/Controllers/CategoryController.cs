using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CardFileOfTextMaterialsEpam.BL.Interfaces;
using CardFileOfTextMaterialsEpam.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardFileOfTextMaterialsEpam.PL.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryModel>> GetAllCategories()
        {
            
            try
            {
                return await _categoryService.GetAllAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpGet("{id}")]
        public async Task<CategoryModel> GetCategoryById(int id)
        {
            try
            {
                return await _categoryService.GetByIdAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryModel categoryModel)
        {
            if (categoryModel == null)
            {
                return BadRequest();
            }

            try
            {
                await _categoryService.AddAsync(categoryModel);
                return new JsonResult("Added Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            try
            {
                await _categoryService.UpdateAsync(model);
                return new JsonResult("Updated Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            try
            {
                await _categoryService.DeleteByIdAsync(id);
                return new JsonResult("Deleted Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
