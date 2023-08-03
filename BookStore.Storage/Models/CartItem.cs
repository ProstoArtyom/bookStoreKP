using System.ComponentModel.DataAnnotations;

namespace BookStore.Storage.Models;

public class CartItem
{
    public int IdBook { get; set; }
    
    public int IdUser { get; set; }
    
    public int Count { get; set; }

    public DateTime DateTimeAdded { get; set; }
    
    public string Title { get; set; }
    
    public decimal Price { get; set; }
    
    public string Category { get; set; }
}