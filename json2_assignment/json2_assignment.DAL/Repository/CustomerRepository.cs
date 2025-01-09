using Microsoft.EntityFrameworkCore;
using json2_assignment.DAL.Repository.Base;
using json2_assignment.DM.Models;

namespace json2_assignment.DAL.Repository;

public class CustomerRepository : BaseRepository<Customer>
{
    public CustomerRepository(DbContext context) : base(context) { }

    protected override void UpdateEntity(Customer oldEntity, Customer newEntity)
    {
        oldEntity.Name = newEntity.Name;
        oldEntity.Email = newEntity.Email;
        oldEntity.PhoneNumber = newEntity.PhoneNumber;
        oldEntity.Address = newEntity.Address;
        oldEntity.DateRegistered = newEntity.DateRegistered;
    }
}