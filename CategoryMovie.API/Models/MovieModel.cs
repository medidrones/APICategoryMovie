using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CategoryMovie.API.Models;

public class MovieModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Year { get; set; }
    public string? Title { get; set; }
    public string? Studios { get; set; }
    public string? Producers { get; set; }
    public bool Winner { get; set; }
}
