namespace BookStore.Storage.Repositories;

public interface IBookStoreAppRepository
{
    UserRepository Users { get; }

    ProfileRepository Profiles { get; }

    BookRepository Books { get; }

    CartRepository Cart { get; }
    
    OrderRepository Orders { get; }
    
    AccountRepository Accounts { get; }
}