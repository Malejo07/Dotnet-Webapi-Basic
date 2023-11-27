using AutoMapper;
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


        public Task<FamilyGroupResponseDto> Add(FamilyGroupRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<FamilyGroupResponseDto> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FamilyGroupResponseDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<FamilyGroupResponseDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FamilyGroupResponseDto> Update(FamilyGroupRequestDto request, int id)
        {
            throw new NotImplementedException();
        }
    }
}
