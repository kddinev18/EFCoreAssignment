using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.DataAccess.Data.Models;

public interface IBaseModel
{
    [Key]
    public Guid Id { get; set; }
}