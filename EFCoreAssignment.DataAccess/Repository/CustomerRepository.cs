using EFCoreAssignment.DataAccess.Data;
using EFCoreAssignment.DataAccess.Data.Models;
using EFCoreAssignment.DataAccess.Repository.Base;

namespace EFCoreAssignment.DataAccess.Repository;

public class CustomerRepository : GenericRepository<Customer>
{
    public CustomerRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    protected override void UpdateEntity(Customer oldEntity, Customer newEntity)
    {
        oldEntity.Name = newEntity.Name;
        oldEntity.Email = newEntity.Email;
        oldEntity.PhoneNumber = newEntity.PhoneNumber;
        oldEntity.Address = newEntity.Address;
        oldEntity.DateRegistered = newEntity.DateRegistered;
    }
}