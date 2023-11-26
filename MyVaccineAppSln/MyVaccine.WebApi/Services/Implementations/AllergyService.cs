using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations
{
    public class AllergyService : IAllergyService
    {
        private readonly IBaseRepository<Allergy> _allergyRepository;
        private readonly IMapper _mapper;
        public AllergyService(IBaseRepository<Allergy> allergyRepository, IMapper mapper)
        {
            _allergyRepository = allergyRepository;
            _mapper = mapper;
        }


        public async Task<AllergyResponseDto> Add(AllergyRequestDto request)
        {
            //var allergys = await _allergyRepository.FindBy(x => x.AllergyId == id).FirstOrDefaultAsync();
            var allergys = new Allergy();
            allergys.Name = request.Name;
            allergys.UserId = request.UserId;

            await _allergyRepository.Add(allergys);
            var response = _mapper.Map<AllergyResponseDto>(allergys);
            return response;
        }

        public async Task<AllergyResponseDto> Delete(int id)
        {
            var allergys = await _allergyRepository.FindBy(x => x.AllergyId == id).FirstOrDefaultAsync();

            await _allergyRepository.Delete(allergys);
            var response = _mapper.Map<AllergyResponseDto>(allergys);
            return response;
        }

        public async Task<IEnumerable<AllergyResponseDto>> GetAll()
        {
            var allergys = await _allergyRepository.GetAll().AsNoTracking().ToListAsync();//Nota:AsNoTracking sirve para agilizar la consulta y quitar todo ese contextto que nos ofrece EF y sus funcionalidades
            var response = _mapper.Map<IEnumerable<AllergyResponseDto>>(allergys);
            return response;
        }

        public async Task<AllergyResponseDto> GetById(int id)
        {
            var allergys = await _allergyRepository.FindByAsNoTracking(x => x.AllergyId == id).FirstOrDefaultAsync();
            var response = _mapper.Map<AllergyResponseDto>(allergys);
            return response;
        }

        public async Task<AllergyResponseDto> Update(AllergyRequestDto request, int id)
        {
            var allergys = await _allergyRepository.FindBy(x => x.AllergyId == id).FirstOrDefaultAsync();
            allergys.Name = request.Name;
            allergys.UserId = request.UserId;

            await _allergyRepository.Update(allergys);
            var response = _mapper.Map<AllergyResponseDto>(allergys);
            return response;
        }
    }
}
