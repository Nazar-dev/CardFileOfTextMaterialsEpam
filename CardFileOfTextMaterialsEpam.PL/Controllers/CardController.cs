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
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public async Task<IEnumerable<CardModel>> GetAllCards()
        {

            try
            {
                return await _cardService.GetAllAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpGet("{id}")]
        public async Task<CardModel> GetCardById(int id)
        {
            try
            {
                return await _cardService.GetByIdAsync(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] CardModel cardModel)
        {
            if (cardModel == null)
            {
                return BadRequest();
            }

            try
            {
                await _cardService.AddAsync(cardModel);
                return new JsonResult("Added Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCard([FromBody] CardModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            try
            {
                await _cardService.UpdateAsync(model);
                return new JsonResult("Updated Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardById(int id)
        {
            try
            {
                await _cardService.DeleteByIdAsync(id);
                return new JsonResult("Deleted Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
