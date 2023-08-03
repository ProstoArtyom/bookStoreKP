namespace BookStore.Storage.Repositories;

public class BookStoreAppRepository : IBookStoreAppRepository
{
    public UserRepository Users { get; }
    
    public ProfileRepository Profiles { get; }
    
    public BookRepository Books { get; }
    
    public CartRepository Cart { get; }
    
    public OrderRepository Orders { get; }
    
    public AccountRepository Accounts { get; }

    public BookStoreAppRepository()
    {
        Users = new UserRepository();
        Profiles = new ProfileRepository();
        Books = new BookRepository();
        Cart = new CartRepository();
        Orders = new OrderRepository();
        Accounts = new AccountRepository();
    }
}