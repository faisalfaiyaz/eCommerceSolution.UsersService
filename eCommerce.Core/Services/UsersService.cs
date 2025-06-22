using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoriesContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services
{
    internal class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersService(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return null;
            }

            //return new AuthenticationResponse(
            //    UserId: user.UserId,
            //    Email: user.Email,
            //    PersonName: user.PersonName,
            //    Gender: user.Gender,
            //    Token: "Token",
            //    Success: true
            //    );

            return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token" };

        }

        public async Task<AuthenticationResponse> Register(RegisterRequest registerRequest)
        {
            ApplicationUser user = new()
            {
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                PersonName = registerRequest.PersonName,
                Gender = registerRequest.Gender.ToString()
            };

            ApplicationUser? registeredUser = await _usersRepository.AddUser(user);

            if (registeredUser is null)
            {
                return null;
            }

            //return new AuthenticationResponse(
            //    UserId: registeredUser.UserId,
            //    Email: registeredUser.Email,
            //    PersonName: registeredUser.PersonName,
            //    Gender: registeredUser.Gender,
            //    Token: "Token",
            //    Success: true
            //    );

            return _mapper.Map<AuthenticationResponse>(registeredUser) with { Success = true, Token = "token" };
        }
    }
}
