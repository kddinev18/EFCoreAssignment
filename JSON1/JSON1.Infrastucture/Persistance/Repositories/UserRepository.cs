using JSON1.Domain.Entities;
using JSON1.Domain.Interfaces;
using JSON1.Infrastucture.Persistance.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JSON1.Infrastucture.Persistance.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}
