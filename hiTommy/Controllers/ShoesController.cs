using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace hiTommy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoesController : ControllerBase
    {
        public ShoeServices _shoesService;

        public ShoesController(ShoeServices shoesService)
        {
            _shoesService = shoesService;
        }

        [HttpGet("get-all-shoes")]
        public IActionResult GetAllShoes()
        {
            var allShoes = _shoesService.GetAllShoes();
            return Ok(allShoes);
        }

        [HttpGet("get-shoe-by-id/{id}")]
        public IActionResult GetShoeById(int id)
        {
            var shoe = _shoesService.GetShoeById(id);
            return Ok(shoe);
        }

        [HttpPost("add-shoe")]
        public IActionResult AddShoe([FromBody] ShoeVm shoe)
        {
            _shoesService.AddShoe(shoe);
            return Ok();
        }

        [HttpPut("update-shoe-by-id/{id}")]
        public IActionResult UpdateShoeById(int id, [FromBody] ShoeVm shoe)
        {
            var updatedShoe = _shoesService.UpdateShoeById(id, shoe);
            return Ok(updatedShoe);
        }

        [HttpPut("set-shoe-on-sale-by-id/{id}")]
        public IActionResult SetShoeOnSaleByID(int id, [FromBody] ShoeVmSale shoe)
        {
            var updatedShoe = _shoesService.SetShoeOnSaleById(id, shoe);
            return Ok(updatedShoe);
        }

        [HttpDelete("delete-shoe-by-id/{id}")]
        public IActionResult DeleteShoeById(int id)
        {
            _shoesService.DeleteShoeById(id);
            return Ok();
        }
        
    }
}