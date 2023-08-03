using BookStore.Storage.Contexts;
using BookStore.Storage.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Storage.Repositories;

public class CartRepository
{
    public void AddCartItemToCart(CartItem cartItem)
    {
        using var context = new BookStoreAppContext();
        
        var inIdBook = new SqliteParameter("@IdBook", cartItem.IdBook);
        var inIdUser = new SqliteParameter("@IdUser", cartItem.IdUser);
        var inCount = new SqliteParameter("@Count", cartItem.Count);
        var inDateTimeAdded = new SqliteParameter("@DateTimeAdded", cartItem.DateTimeAdded);

        context.Database.ExecuteSqlRaw("INSERT INTO Cart " + 
                                       "(IdBook, Count, IdUser, DateTimeAdded) " + 
                                       "VALUES " + 
                                       "(@IdBook, @Count, @IdUser, @DateTimeAdded) " +
                                       "ON CONFLICT(IdBook, IdUser) DO UPDATE SET " + 
                                       "Count = @Count, DateTimeAdded = @DateTimeAdded",
            inIdBook, inIdUser, inCount, inDateTimeAdded);
    }

    public void DeleteCartItemFromCart(CartItem cartItem)
    {
        using var context = new BookStoreAppContext();
        
        var inIdBook = new SqliteParameter("@IdBook", cartItem.IdBook);

        context.Database.ExecuteSqlRaw("DELETE FROM Cart " +
                                       "WHERE Cart.IdBook = @IdBook", inIdBook);
    }
    
    public void DeleteCartItemsFromCart(CartItem[] cartItems)
    {
        foreach (var cartItem in cartItems)
            DeleteCartItemFromCart(cartItem);
    }
    
    public void DeleteCartItemsFromCart(int IdUser)
    {
        using var context = new BookStoreAppContext();
        
        var inIdUser = new SqliteParameter("@IdUser", IdUser);

        
        context.Database.ExecuteSqlRaw("DELETE FROM Cart " +
                                       "WHERE Cart.IdUser = @IdUser", inIdUser);
    }

    public CartItem[] GetCartItemsFromCart(int IdUser)
    {
        using var context = new BookStoreAppContext();
        
        var inIdUser = new SqliteParameter("@IdUser", IdUser);
        
        var cartItems = context.Cart.FromSqlRaw("SELECT Cart.IdUser, " +
                                                "Cart.Count, " +
                                                "Cart.DateTimeAdded, " +
                                                "Cart.IdBook, " +
                                                "Books.Title, " +
                                                "Books.Price, " +
                                                "Books.Category " +
                                                "FROM Cart INNER JOIN " +
                                                "Books ON Books.Id = Cart.IdBook " +
                                                "WHERE Cart.IdUser = @IdUser",
            inIdUser).ToList();
        return cartItems.ToArray();
    }

    public CartItem[] GetCartItems()
    {
        using var context = new BookStoreAppContext();

        var cartItems = context.Cart.FromSqlRaw("SELECT Cart.IdUser, " +
                                                "Cart.Count, " +
                                                "Cart.DateTimeAdded, " +
                                                "Cart.IdBook, " +
                                                "Books.Title, " +
                                                "Books.Price, " +
                                                "Books.Category " +
                                                "FROM Cart INNER JOIN " +
                                                "Books ON Books.Id = Cart.IdBook");
        return cartItems.ToArray();
    }
}