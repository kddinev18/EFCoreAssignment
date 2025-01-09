using System.ComponentModel.DataAnnotations;
using EFCoreAssignment.DataAccess.Models;

namespace EFCoreAssignment.Domain.Models.Order;

public class ResponseOrder
{
    [Required]
    public int OrderId { get; set; }
    
    [Required]
    public int UserId { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }
    
    [Required]
    public float TotalAmount { get; set; }

    [Required]
    public OrderStatus Status { get; set; }
}