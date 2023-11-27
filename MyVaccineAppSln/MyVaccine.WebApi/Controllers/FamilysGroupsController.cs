using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.FamilyGroup;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilysGroupsController : ControllerBase
    {
        private readonly IFamilyGroupService _familyGroupService;
        private readonly IValidator<FamilyGroupRequestDto> _validator;
        public FamilysGroupsController(IFamilyGroupService familyGroupService, IValidator<FamilyGroupRequestDto> validator)
        {
            _familyGroupService = familyGroupService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var familysgroups = await _familyGroupService.GetAll();
            return Ok(familysgroups);
        }

        //[AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var familysgroups = await _familyGroupService.GetById(id);
            return Ok(familysgroups);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FamilyGroupRequestDto familyGroupsDto)
        {
            var validationResult = await _validator.ValidateAsync(familyGroupsDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var familysgroups = await _familyGroupService.Add(familyGroupsDto);
            return Ok(familysgroups);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FamilyGroupRequestDto familyGroupsDto)
        {
            var familysgroups = await _familyGroupService.Update(familyGroupsDto, id);
            if (familysgroups == null)
            {
                return NotFound();
            }

            return Ok(familysgroups);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var familysgroups = await _familyGroupService.Delete(id);
            if (familysgroups == null)
            {
                return NotFound();
            }

            return Ok(familysgroups);
        }
    }
}
