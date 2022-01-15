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
    public class PersonController : ControllerBase
    {
        private readonly IMyPersonService _myPersonService;
        public PersonController(IMyPersonService myPersonService)
        {
            _myPersonService = myPersonService;
        }

        [HttpGet]
        public async Task<IEnumerable<PersonModel>> GetAllPerson()
        {

            try
            {
                return await _myPersonService.GetAllAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpGet("{id}")]
        public async Task<PersonModel> GetPersonById(int id)
        {
            try
            {
                return await _myPersonService.GetByIdAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonModel personModel)
        {
            if (personModel == null)
            {
                return BadRequest();
            }

            try
            {
                await _myPersonService.AddAsync(personModel);
                return new JsonResult("Added Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson([FromBody] PersonModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            try
            {
                await _myPersonService.UpdateAsync(model);
                return new JsonResult("Updated Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonById(int id)
        {
            try
            {
                await _myPersonService.DeleteByIdAsync(id);
                return new JsonResult("Deleted Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
