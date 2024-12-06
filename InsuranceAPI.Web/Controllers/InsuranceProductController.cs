using InsuranceAPI.Application.Interfaces;
using InsuranceAPI.Application.DTOs;
using InsuranceAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InsuranceAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceProductController : ControllerBase
    {
        private readonly IInsuranceProductService _productService;

        public InsuranceProductController(IInsuranceProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllInsuranceProducts()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetInsuranceProductById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInsuranceProduct([FromBody] InsuranceProductDTO productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new InsuranceProduct
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Premium = productDto.Premium,
                CoverageAmount = productDto.CoverageAmount,
                StartDate = productDto.StartDate,
                EndDate = productDto.EndDate,
                InsuredId = productDto.InsuredId
            };

            await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetInsuranceProductById), new { id = product.Id }, product);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateInsuranceProduct(int id, [FromBody] InsuranceProductDTO productDto)
        {
            var existingProduct = await _productService.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = productDto.Name;
            existingProduct.Description = productDto.Description;
            existingProduct.Premium = productDto.Premium;
            existingProduct.CoverageAmount = productDto.CoverageAmount;
            existingProduct.StartDate = productDto.StartDate;
            existingProduct.EndDate = productDto.EndDate;

            await _productService.UpdateAsync(existingProduct);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteInsuranceProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }
}
