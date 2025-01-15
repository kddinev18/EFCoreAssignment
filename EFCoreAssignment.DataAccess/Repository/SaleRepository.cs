using EFCoreAssignment.DataAccess.Data;
using EFCoreAssignment.DataAccess.Data.Models;
using EFCoreAssignment.DataAccess.Repository.Base;

namespace EFCoreAssignment.DataAccess.Repository;

public class SaleRepository : GenericRepository<Sale>
{
    public SaleRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    protected override void UpdateEntity(Sale oldEntity, Sale newEntity)
    {
        oldEntity.Quantity = newEntity.Quantity;
        oldEntity.SaleDate = newEntity.SaleDate;
        oldEntity.TotalPrice = newEntity.TotalPrice;
        oldEntity.CustomerId = newEntity.CustomerId;
        oldEntity.Customer = newEntity.Customer;
        oldEntity.ProductId = newEntity.ProductId;
        oldEntity.Product = newEntity.Product;
    }
}