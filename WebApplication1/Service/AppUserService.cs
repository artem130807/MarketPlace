using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Net;
using WebApplication1.Auth;
using WebApplication1.Contracts.ContractsAppUser;
using WebApplication1.DtoModels.DtoAppUser;
using WebApplication1.Models;
using WebApplication1.Provider;

namespace WebApplication1.Service
{
    public class AppUserService:IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IHasherPassword _hasherPassword;
        private readonly IJwtProvider _jwtProvider;
        private readonly IMapper _mapper;
        public AppUserService(IUserRepository userRepository, IMapper mapper, IHasherPassword hasherPassword, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _hasherPassword = hasherPassword;  
            _jwtProvider = jwtProvider;
        }
    
        
        public async Task<AuthResponseDto> CreateUser(RegisterRequestDto dtoCreateUser)
        {
            var hashedPassword = _hasherPassword.Generate(dtoCreateUser.PasswordHash);       
            var user = new AppUsers
            {Id = Guid.NewGuid(), 
             FirstName = dtoCreateUser.FirstName, 
             LastName = dtoCreateUser.LastName, 
             Email = dtoCreateUser.Email, 
             PasswordHash = hashedPassword };
            await _userRepository.CreateUser(user);
            var token = _jwtProvider.GenerateToken(user);
            return new AuthResponseDto { Token = token, Message = "Регистрация успешна"};
        }

        public async Task<string> GetUserByEmail(LoginRequestDto loginRequestDto)
        {
            var user = await _userRepository.GetUserByEmail(loginRequestDto.Email);
            var result = _hasherPassword.Verify(loginRequestDto.Password, user.PasswordHash);
            var token = _jwtProvider.GenerateToken(user);
            return token;
        }
    }
}
