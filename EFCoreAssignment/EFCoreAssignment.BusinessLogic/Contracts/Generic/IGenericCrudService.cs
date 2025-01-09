using EFCoreAssignment.DataAccess.Models;

namespace EFCoreAssignment.BusinessLogic.Contracts.Generic;

public interface IGenericCrudService<in TCreateEntity, out TResponseEntity, in TUpdateEntity>
    where TCreateEntity : class
    where TResponseEntity : class
    where TUpdateEntity : class
{
    public TResponseEntity? GetById(int id);

    public IQueryable<TResponseEntity> GetAll();

    public TResponseEntity? Update(int id, TUpdateEntity updateEntity);

    public TResponseEntity Create(TCreateEntity createEntity);

    public int DeleteById(int id);
}