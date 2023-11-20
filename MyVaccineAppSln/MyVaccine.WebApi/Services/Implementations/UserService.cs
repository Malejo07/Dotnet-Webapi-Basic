using Microsoft.AspNetCore.Identity;
using MyVaccine.WebApi.Dtos;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;// Este _userManager lo utilizamos con el fin de no utilizar el objeto directo de la inyección?
        private readonly IUserRepository _userRepository;
        public UserService(UserManager<IdentityUser> userManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }
        public async Task<AuthResponseDto> AddUserAsync(RegisterRequetDto request)
        {
            var response = new AuthResponseDto();
            try
            {
                var result = await _userRepository.AddUser(request);
            }
            catch (Exception ex)
            {

                throw;
            }

            return response;

        }

        public async Task<AuthResponseDto> Login(LoginRequestDto request)
        {
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)//Puedes agregar más claims segun tus necesidades; los claims son como una especie de atributos que vamos poniendole al token de manera que cuando los leamos veamos los atributos.
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable(MyVaccineLiterals.JWT_KEY)));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    //issuer: _configuration["JwtIssuer"],
                    //audience: _configuration["JwtAudience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(15),//Tiempo de vida
                    signingCredentials: creds
                );
            }
    }
}
