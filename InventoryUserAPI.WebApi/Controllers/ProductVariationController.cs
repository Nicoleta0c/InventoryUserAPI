using InventoryUserAPI.Application.Interfaces.IProducts;
using InventoryUserAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryUserAPI.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductVariationController : ControllerBase
    {
        private readonly IProductVariationService _variationService;

        public ProductVariationController(IProductVariationService variationService)
        {
            _variationService = variationService;
        }

        [HttpGet("Color/{colorName}")]
        public async Task<ActionResult<IEnumerable<ProductVariationDto>>> GetByColorName(string colorName)
        {
            var result = await _variationService.GetByColorNameAsync(colorName);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVariationDto>>> GetAll()
        {
            var variations = await _variationService.GetAllAsync();
            return Ok(variations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVariationDto>> GetById(int id)
        {
            var variation = await _variationService.GetByIdAsync(id);
            if (variation == null) return NotFound();
            return Ok(variation);
        }

        [HttpGet("display")]
        public async Task<ActionResult> GetDisplayByColor(int? colorId, int pageNumber = 1, int pageSize = 10)
        {
            var (variationsDisplay, totalPages) = await _variationService.GetDisplayByColorAsync(colorId, pageNumber, pageSize);

            return Ok(new
            {
                totalPages,
                variations = variationsDisplay
            });
        }

        [HttpPost]
        public async Task<ActionResult<ProductVariationDto>> Create(ProductVariation variation)
        {
            var created = await _variationService.CreateAsync(variation);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductVariation variation)
        {
            if (id != variation.Id) return BadRequest();
            var updated = await _variationService.UpdateAsync(variation);
            return updated ? NoContent() : StatusCode(500);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _variationService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }

        [HttpGet("dtos")]
        public async Task<ActionResult<IEnumerable<ProductVariationDto>>> GetAllDtos()
        {
            var dtos = await _variationService.GetAllDtoAsync();
            return Ok(dtos);
        }
    }
}
