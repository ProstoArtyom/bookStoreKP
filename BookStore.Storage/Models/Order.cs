using System.ComponentModel.DataAnnotations;
using PAS.Storage.Models.Enums;

namespace BookStore.Storage.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    
    public string Books { get; set; }
    
    public DateTime DateTimeCreated { get; set; }
    
    public string Status { get; set; }
    
    public decimal Price { get; set; }
    
    public PaymentType Payment { get; set; }

    public int IdUser { get; set; }
}