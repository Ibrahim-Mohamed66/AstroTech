using System.ComponentModel.DataAnnotations;
namespace AstroTech.DAL.Models;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

}
