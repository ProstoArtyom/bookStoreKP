using System.ComponentModel.DataAnnotations;

namespace BookStore.Storage.Models;

public class Profile
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }
    
    public int IdUser { get; set; }
}