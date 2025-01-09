using EFCoreAssignment.Core.Interfaces;
using EFCoreAssignment.Data.Interfaces;

namespace EFCoreAssignment.Core.Services
{
    public class BaseService(IBaseRepository repository) : IBaseService
    {
        private readonly IBaseRepository _repository = repository;

        public async Task<bool> Create<T>(T entity) where T : class
        {
            return await _repository.Create(entity);
        }

        public async Task<bool> Update<T>(T entity) where T : class
        {
            return await _repository.Update(entity);
        }

        public async Task<bool> Delete<T>(T entity) where T : class
        {
            return await _repository.Delete(entity);
        }

        public async Task<T?> GetById<T>(int id) where T : class
        {
            return await _repository.GetById<T>(id);
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : class
        {
            return await _repository.GetAll<T>();
        }
    }
}
