using InventoryUserAPI.Application.Interfaces;
using InventoryUserAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryUserAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceController : ControllerBase
    {
        private readonly IPriceService _priceService;

        public PriceController(IPriceService priceService)
        {
            _priceService = priceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Price>>> GetAll()
        {
            var prices = await _priceService.GetAllAsync();
            return Ok(prices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Price>> GetById(int id)
        {
            var price = await _priceService.GetByIdAsync(id);
            if (price == null)
                return NotFound();

            return Ok(price);
        }

        [HttpPost]
        public async Task<ActionResult<Price>> Create(Price price)
        {
            var createdPrice = await _priceService.CreateAsync(price);
            return CreatedAtAction(nameof(GetById), new { id = createdPrice.Id }, createdPrice);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Price price)
        {
            if (id != price.Id)
                return BadRequest();

            var exists = await _priceService.GetByIdAsync(id);
            if (exists == null)
                return NotFound();

            var updated = await _priceService.UpdateAsync(price);
            if (!updated)
                return StatusCode(500, "Error updating the price");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _priceService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
