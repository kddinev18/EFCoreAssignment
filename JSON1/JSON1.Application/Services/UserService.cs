using JSON1.Application.Services.Persistance;
using JSON1.Domain.Entities;
using JSON1.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using JSON1.Application.Mapping.GetDtos;
using JSON1.Application.Mapping.PutDtos;

namespace JSON1.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserGetDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Adapt<IEnumerable<UserGetDto>>();
        }

        public async Task<UserGetDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return null;

            return user.Adapt<UserGetDto>();
        }

        public async Task<UserGetDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                return null;

            return user.Adapt<UserGetDto>();
        }

        public async Task<UserGetDto> AddUserAsync(UserPutDto userDto)
        {
            var user = userDto.Adapt<User>();
            await _userRepository.AddAsync(user);

            return user.Adapt<UserGetDto>();
        }


        public async Task<UserGetDto> UpdateUserAsync(int id, UserPutDto userDto)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null) return null;

            existingUser = userDto.Adapt(existingUser);
            await _userRepository.UpdateAsync(existingUser);

            return existingUser.Adapt<UserGetDto>();
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
