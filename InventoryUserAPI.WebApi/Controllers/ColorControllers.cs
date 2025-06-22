using InventoryUserAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryUserAPI.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var color = await _colorService.GetByIdAsync(id);
            if (color == null)
                return NotFound($"Color con id {id} no encontrado");

            return Ok(color);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            var (colors, totalPages) = await _colorService.GetAllAsync(pageNumber, pageSize);
            return Ok(new
            {
                totalPages,
                colors
            });
        }
    }
}
