using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.Domain.Models.OrderDetail;

public class ResponseOrderDetail : CreateOrderDetail
{
    [Required]
    public int Id { get; set; }
}
