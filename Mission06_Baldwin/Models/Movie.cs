// model for the movie table in the database

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6Assignment.Models;

public class Movie
{
    [Key]
    [Required]
    public int MovieId {get; set;}
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    public Categories? Category { get; set; }
    [Required(ErrorMessage = "Sorry, you need to enter a title.")]
    public string Title {get; set;}
    [Required]
    [Range(1888, 2027, ErrorMessage = "You must enter a valid year.")]
    public int Year {get; set;}
    public string? Director {get; set;}
    public string? Rating {get; set;}
    [Required]
    public bool Edited {get; set;}
    public string? LentTo {get; set;}
    [Required]
    public bool CopiedToPlex {get; set;}
    public string? Notes {get; set;}
}