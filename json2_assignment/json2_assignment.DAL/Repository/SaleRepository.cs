using Microsoft.EntityFrameworkCore;
using json2_assignment.DAL.Repository.Base;
using json2_assignment.DM.Models;

namespace json2_assignment.DAL.Repository;

public class SaleRepository : BaseRepository<Sale>
{
    public SaleRepository(DbContext context) : base(context) { }

    protected override void UpdateEntity(Sale oldEntity, Sale newEntity)
    {
        oldEntity.CustomerId = newEntity.CustomerId;
        oldEntity.ProductId = newEntity.ProductId;
        oldEntity.Quantity = newEntity.Quantity;
        oldEntity.SaleDate = newEntity.SaleDate;
        oldEntity.TotalPrice = newEntity.TotalPrice;
    }
}