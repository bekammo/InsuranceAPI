using InsuranceAPI.Application.Interfaces;
using InsuranceAPI.Application.DTOs;
using InsuranceAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InsuranceAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuredController : ControllerBase
    {
        private readonly IInsuredService _insuredService;

        public InsuredController(IInsuredService insuredService)
        {
            _insuredService = insuredService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllInsureds()
        {
            var insureds = await _insuredService.GetAllAsync();
            return Ok(insureds);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetInsuredById(int id)
        {
            var insured = await _insuredService.GetByIdAsync(id);
            if (insured == null)
            {
                return NotFound();
            }
            return Ok(insured);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInsured([FromBody] InsuredDTO insuredDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var insured = new Insured
            {
                FirstName = insuredDto.FirstName,
                LastName = insuredDto.LastName,
                DateOfBirth = insuredDto.DateOfBirth,
                PersonalNumber = insuredDto.PersonalNumber,
                Phone = insuredDto.Phone,
                Email = insuredDto.Email
            };

            await _insuredService.AddAsync(insured);
            return CreatedAtAction(nameof(GetInsuredById), new { id = insured.Id }, insured);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateInsured(int id, [FromBody] InsuredDTO insuredDto)
        {
            var existingInsured = await _insuredService.GetByIdAsync(id);
            if (existingInsured == null)
            {
                return NotFound();
            }

            existingInsured.FirstName = insuredDto.FirstName;
            existingInsured.LastName = insuredDto.LastName;
            existingInsured.DateOfBirth = insuredDto.DateOfBirth;
            existingInsured.PersonalNumber = insuredDto.PersonalNumber;
            existingInsured.Phone = insuredDto.Phone;
            existingInsured.Email = insuredDto.Email;

            await _insuredService.UpdateAsync(existingInsured);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteInsured(int id)
        {
            var insured = await _insuredService.GetByIdAsync(id);
            if (insured == null)
            {
                return NotFound();
            }

            await _insuredService.DeleteAsync(id);
            return NoContent();
        }
    }
}
