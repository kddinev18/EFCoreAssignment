using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSON1.Domain.Entities;
using JSON1.Application.Mapping.GetDtos;
using JSON1.Application.Mapping.PutDtos;

namespace JSON1.Application.Services.Persistance
{
    public interface IUserService
    {
        Task<IEnumerable<UserGetDto>> GetAllUsersAsync();
        Task<UserGetDto> GetUserByIdAsync(int id);
        Task<UserGetDto> GetUserByEmailAsync(string email);
        Task<UserGetDto> AddUserAsync(UserPutDto userDto);
        Task<UserGetDto> UpdateUserAsync(int id,UserPutDto userDto);
        Task DeleteUserAsync(int id);
    }

}
