using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstroTech.Models;

public class Category
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string CategoryName { get; set; }

    [Required]
    public string CategoryImage{ get; set; }

    [StringLength(500)]
    public string? CategoryDescription { get; set; }

    [ForeignKey("ParentCategoryId")]
    public int? ParentCategoryId { get; set; }

    public Category? ParentCategory { get; set; }

}
