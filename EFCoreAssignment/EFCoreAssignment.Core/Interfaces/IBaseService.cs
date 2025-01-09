namespace EFCoreAssignment.Core.Interfaces
{
    public interface IBaseService
    {
        public Task<bool> Create<T>(T entity) where T : class;
        public Task<bool> Update<T>(T entity) where T : class;
        public Task<bool> Delete<T>(T entity) where T : class;
        public Task<T?> GetById<T>(int id) where T : class;
        public Task<IEnumerable<T>> GetAll<T>() where T : class;
    }
}
