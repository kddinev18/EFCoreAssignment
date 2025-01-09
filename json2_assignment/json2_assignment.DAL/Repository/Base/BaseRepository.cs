using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using json2_assignment.DM.Models;

namespace json2_assignment.DAL.Repository.Base;

public abstract class BaseRepository<T> where T : class, IBaseModel
{
    protected readonly DbContext _context;

    protected BaseRepository(DbContext context)
    {
        _context = context;
    }

    public T? GetById(int id)
    {
        return _context.Set<T>().FirstOrDefault(x => x.Id == id);
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public bool Add(T entity)
    {
        _context.Set<T>().Add(entity);
        return _context.SaveChanges() > 0;
    }

    public bool Update(T entity)
    {
        var oldEntity = GetById(entity.Id);
        if (oldEntity is null) return false;

        UpdateEntity(oldEntity, entity);
        return _context.SaveChanges() > 0;
    }

    protected abstract void UpdateEntity(T oldEntity, T newEntity);

    public bool Delete(int id)
    {
        var entity = GetById(id);
        if (entity is null) return false;

        _context.Set<T>().Remove(entity);
        return _context.SaveChanges() > 0;
    }
}