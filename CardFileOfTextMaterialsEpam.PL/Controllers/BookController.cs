using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CardFileOfTextMaterialsEpam.BL.Interfaces;
using CardFileOfTextMaterialsEpam.BL.Models;
using CardFileOfTextMaterialsEpam.BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardFileOfTextMaterialsEpam.PL.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IEnumerable<BookModel>> GetAllBooks()
        {
            
            try
            {
                return await _bookService.GetAllAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpGet("{id}")]
        public async Task<BookModel> GetBookById(int id)
        {
            try
            {
                return await _bookService.GetByIdAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody]BookModel bookModel)
        {
            if (bookModel == null)
            {
                return BadRequest();
            }

            try
            {
                await _bookService.AddAsync(bookModel);
                return new JsonResult("Added Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody]BookModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
        
            try
            {
                await _bookService.UpdateAsync(model);
                return new JsonResult("Updated Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookById(int id)
        {
            try
            {
                await _bookService.DeleteByIdAsync(id);
                return new JsonResult("Deleted Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
