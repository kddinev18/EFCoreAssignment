using System.ComponentModel.DataAnnotations;

namespace EFCoreAssignment.DataAccess.Data.Models;

public interface IBaseModel
{
    public int Id { get; set; }
}