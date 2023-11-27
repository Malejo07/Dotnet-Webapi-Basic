using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Dtos.FamilyGroup;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations
{
    public class FamilyGroupService : IFamilyGroupService
    {
        private readonly IBaseRepository<FamilyGroup> _familyGroupRepository;
        private readonly IMapper _mapper;

        public FamilyGroupService(IBaseRepository<FamilyGroup> familyGroupRepository, IMapper mapper)
        {
            _familyGroupRepository = familyGroupRepository;
            _mapper = mapper;            
        }


        public async Task<FamilyGroupResponseDto> Add(FamilyGroupRequestDto request)
        {
            var familysgroups = new FamilyGroup();
            familysgroups.Name = request.Name;
            familysgroups.UserId = request.UserId;

            await _familyGroupRepository.Add(familysgroups);
            var response = _mapper.Map<FamilyGroupResponseDto>(familysgroups);
            return response;

        }

        public async Task<FamilyGroupResponseDto> Delete(int id)
        {
            var familysgroups = await _familyGroupRepository.FindBy(x => x.FamilyGroupId == id).FirstOrDefaultAsync();

            await _familyGroupRepository.Delete(familysgroups);
            var response = _mapper.Map<FamilyGroupResponseDto>(familysgroups);
            return response;
        }

        public async Task<IEnumerable<FamilyGroupResponseDto>> GetAll()
        {
            var familysgroups = await _familyGroupRepository.GetAll().AsNoTracking().ToListAsync();
            var response = _mapper.Map<IEnumerable<FamilyGroupResponseDto>>(familysgroups);
            return response;
        }

        public async Task<FamilyGroupResponseDto> GetById(int id)
        {
            var familysgroups = await _familyGroupRepository.FindByAsNoTracking(x => x.FamilyGroupId == id).FirstOrDefaultAsync();
            var response = _mapper.Map<FamilyGroupResponseDto>(familysgroups);
            return response;
        }

        public async Task<FamilyGroupResponseDto> Update(FamilyGroupRequestDto request, int id)
        {
            var familysgroups = await _familyGroupRepository.FindBy(x => x.FamilyGroupId == id).FirstOrDefaultAsync();
            familysgroups.Name = request.Name;
            familysgroups.UserId = request.UserId;

            await _familyGroupRepository.Update(familysgroups);
            var response = _mapper.Map<FamilyGroupResponseDto>(familysgroups);
            return response;
        }
    }
}
