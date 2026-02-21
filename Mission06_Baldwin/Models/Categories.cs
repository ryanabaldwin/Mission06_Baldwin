// model for the category table

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6Assignment.Models;

public class Categories
{
    [Key]
    [Required]
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
}