using AutoMapper;
using EFCoreAssignment.BusinessLogic.Contracts.Generic;
using EFCoreAssignment.DataAccess.Data;
using EFCoreAssignment.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.BusinessLogic.Implementations.Base;

public class BaseCrudService<TEntity, TCreateEntity, TResponseEntity, TUpdateEntity>
    : IGenericCrudService<TCreateEntity, TResponseEntity, TUpdateEntity>
    where TCreateEntity : class
    where TResponseEntity : class
    where TUpdateEntity : class
    where TEntity : BaseEntity
{
    protected readonly ApplicationDbContext _dbContext;
    protected readonly DbSet<TEntity> _entities;
    protected readonly IMapper _mapper;
    
    public BaseCrudService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _entities = _dbContext.Set<TEntity>();
    }
    
    // required mappings:
    // TCreateEntity -> TEntity
    // TEntity -> TResponseEntity
    public TResponseEntity Create(TCreateEntity createEntity)
    {
        var entity = _entities.Add(_mapper.Map<TEntity>(createEntity));

        _dbContext.SaveChanges();

        return _mapper.Map<TResponseEntity>(entity.Entity);
    }

    // required mappings:
    // TEntity -> TResponseEntity
    public TResponseEntity? GetById(int id)
    {
        var entity = _entities.FirstOrDefault(e => e.Id == id);

        return entity == null ? null : _mapper.Map<TResponseEntity>(entity);
    }

    public IQueryable<TResponseEntity> GetAll()
    {
        return _entities.Select(e => _mapper.Map<TResponseEntity>(e));
    }
    
    protected TResponseEntity? UpdateEntityById(int id, Func<TEntity, TEntity> pred,
        CancellationToken cf = default)
    {
        var entity = _entities.FirstOrDefault(e => e.Id == id);

        if (entity == null)
            return null;

        entity = pred(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();

        return _mapper.Map<TResponseEntity>(entity);
    }

    public TResponseEntity? Update(int id, TUpdateEntity updateEntity)
    {
        return UpdateEntityById(id, entity =>
        {
            _mapper.Map(updateEntity, entity);
            return entity;
        }); 
    }

    public int DeleteById(int id)
    {
        return _entities.Where(e => e.Id == id).ExecuteDelete();
    }
}
