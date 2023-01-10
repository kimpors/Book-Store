using System.ComponentModel.DataAnnotations;

namespace Book_Store.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    [RegularExpression(@"\w* \w*")]
    public string Author { get; set; }
    public string Description { get; set; }
    public DateTime Published { get; set; } = DateTime.Now;
}