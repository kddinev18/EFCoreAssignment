using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssignment.DataAccess.Models;

public enum OrderStatus
{
    Pending,
    Cancelled,
    Completed
}

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }
    
    [Required]
    public int UserId { get; set; }

    [Required]
    public DateTime OrderDate { get; set; } = DateTime.Now;
    
    [Required]
    public float TotalAmount { get; set; }

    [Required]
    public OrderStatus Status { get; set; }

    [Required]
    [ForeignKey(nameof(UserId))]
    private User User { get; set; } = null!;
}