using EFCoreAssignment.DataAccess.Data.Models;

namespace EFCoreAssignment.DataAccess.Repository.Base;

public interface IGenericRepository<T> where T : IBaseModel
{
    public IQueryable<T> GetById(int id);
    public  IQueryable<T> GetAll();
    public bool Add(T entity);
    public bool Update(T entity);
    public bool Delete(int id);
}