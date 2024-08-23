using dotnet_registration_api.Data.Entities;
using dotnet_registration_api.Data.Models;
using dotnet_registration_api.Data.Repositories;
using dotnet_registration_api.Helpers;
using Mapster;
using System.Reflection;

namespace dotnet_registration_api.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAll()
        {
            return await this._userRepository.GetAllUsers();
        }

        public async Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Login(LoginRequest login)
        {
            if(string.IsNullOrWhiteSpace(login.Username) || 
               string.IsNullOrWhiteSpace(login.Password))
                throw new AppException();

            var user = await this._userRepository.GetUserByUsernameAndPassword(login.Username, HashHelper.HashPassword(login.Password));

            if (user == null)
                throw new NotFoundException();

            return user;
        }

        public async Task<User> Register(RegisterRequest register)
        {
            if (string.IsNullOrWhiteSpace(register.Password))
                throw new AppException();

            var userByName = await this._userRepository.GetUserByUsername(register.Username);

            if (userByName != null)
                throw new AppException();

            return await this._userRepository
                .CreateUser(new User { FirstName = register.FirstName, LastName = register.LastName, Username = register.Username, PasswordHash = HashHelper.HashPassword(register.Password) });
        }

        public async Task<User> Update(int id, UpdateRequest updateRequest)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
