using EFCoreAssignment.DataAccess.Data;
using EFCoreAssignment.DataAccess.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.DataAccess.Repository.Base;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseModel
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    
    public IQueryable<T> GetById(int id)
    {
        return GetAll().Where(x => x.Id == id);
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet;
    }

    public bool Add(T entity)
    {
        _dbSet.Add(entity);
        return _context.SaveChanges() > 0;
    }

    public bool Update(T entity)
    {
        var oldEntity = GetById(entity.Id).FirstOrDefault();
        if (oldEntity is null) return false;

        UpdateEntity(oldEntity, entity);
        return _context.SaveChanges() > 0;
    }

    public bool Delete(int id)
    {
        var entity = GetById(id).FirstOrDefault();
        if (entity is null) return false;

        _dbSet.Remove(entity);
        return _context.SaveChanges() > 0;
    }
    
    protected abstract void UpdateEntity(T oldEntity, T newEntity);
}