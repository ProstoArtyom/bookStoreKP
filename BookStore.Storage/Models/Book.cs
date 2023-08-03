using System.ComponentModel.DataAnnotations;

namespace BookStore.Storage.Models;

public class Book
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; }
    
    public string Author { get; set; }
    
    public string Isbn { get; set; }
    
    public string Description { get; set; }
    
    public decimal Price { get; set; }
    
    public string Category { get; set; }
    
    public int Count { get; set; }

    public byte[] Image { get; set; }
}