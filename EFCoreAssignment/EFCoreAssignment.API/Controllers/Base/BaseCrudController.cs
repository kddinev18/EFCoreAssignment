using EFCoreAssignment.BusinessLogic.Contracts.Generic;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment.API.Controllers.Base;

public class BaseCrudController<TCrudService, TCreateEntity, TResponseEntity, TUpdateEntity>(TCrudService orderDetailService) : Controller
    where TCreateEntity : class
    where TResponseEntity : class
    where TUpdateEntity : class
    where TCrudService : IGenericCrudService<TCreateEntity, TResponseEntity, TUpdateEntity>
{
    private TCrudService _orderDetailService = orderDetailService;

    [HttpGet]
    public ActionResult<IEnumerable<TResponseEntity>> GetOrderDetails()
    {
        return Ok(_orderDetailService.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<TResponseEntity> GetOrderDetail([FromRoute] int id)
    {
        return Ok(_orderDetailService.GetById(id));
    }

    [HttpPost]
    public ActionResult<TResponseEntity> PostOrderDetail([FromBody] TCreateEntity createEntity)
    {
        return Ok(_orderDetailService.Create(createEntity));
    }

    [HttpPut("{id:int}")]
    public ActionResult<TResponseEntity> PutOrderDetail([FromRoute] int id, [FromBody] TUpdateEntity updateEntity)
    {
        return Ok(_orderDetailService.Update(id, updateEntity));
    }

    [HttpDelete("{id:int}")]
    public ActionResult<TResponseEntity> DeleteOrderDetail([FromRoute] int id)
    {
        return Ok(_orderDetailService.DeleteById(id));
    }
}
