using MyVaccine.WebApi.Dtos;

namespace MyVaccine.WebApi.Services.Contracts
{
    public interface IUserService
    {
        Task<AuthResponseDto> AddUserAsync(RegisterRequetDto request);
        Task<AuthResponseDto> Login(LoginRequestDto request);
    }
}
