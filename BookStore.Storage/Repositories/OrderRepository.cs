using BookStore.Storage.Contexts;
using BookStore.Storage.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PAS.Storage.Models.Enums;

namespace BookStore.Storage.Repositories;

public class OrderRepository
{
    public Order[] GetOrders(int IdUser)
    {
        using var context = new BookStoreAppContext();

        var inIdUser = new SqliteParameter("@IdUser", IdUser);

        var orders = context.Orders.FromSqlRaw("SELECT Orders.Id, " + 
                                                               "Orders.Books, " +
                                                               "Orders.DateTimeCreated, " +
                                                               "Orders.Status, " +
                                                               "Orders.Price, " +
                                                               "Orders.Payment, " +
                                                               "Orders.IdUser " +
                                                               "FROM Orders " +
                                                               "WHERE Orders.IdUser = @IdUser",
            inIdUser);
        return orders.ToArray();
    }
    
    public Order[] GetOrders()
    {
        using var context = new BookStoreAppContext();
        
        var orders = context.Orders.FromSqlRaw("SELECT Orders.Id, " + 
                                               "Orders.Books, " +
                                               "Orders.DateTimeCreated, " +
                                               "Orders.Status, " +
                                               "Orders.Price, " +
                                               "Orders.Payment, " +
                                               "Orders.IdUser " +
                                               "FROM Orders ");
        return orders.ToArray();
    }

    public Order CreateOrder(CartItem[] cartItems, PaymentType payment, Profile profile)
    {
        var order = new Order
        {
            Price = cartItems.Select(x => x.Price * x.Count).Sum(),
            Status = "Создано",
            Books = string.Join(',', cartItems.Select(x => $"{x.IdBook}-{x.Count}")),
            DateTimeCreated = DateTime.Now,
            Payment = payment,
            IdUser = profile.IdUser
        };

        return order;
    }

    public void SetOrder(Order order)
    {
        using var context = new BookStoreAppContext();
        
        var inIdsBooks = new SqliteParameter("@Books", order.Books);
        var inDateTimeCreated = new SqliteParameter("@DateTimeCreated", order.DateTimeCreated);
        var inStatus = new SqliteParameter("@Status", order.Status);
        var inPrice = new SqliteParameter("@Price", order.Price);
        var inPayment = new SqliteParameter("@Payment", order.Payment);
        var inIdUser = new SqliteParameter("@IdUser", order.IdUser);

        context.Database.ExecuteSqlRaw("INSERT INTO Orders " + 
                                       "(Books, DateTimeCreated, Status, Price, Payment, IdUser) " + 
                                       "VALUES " + 
                                       "(@Books, @DateTimeCreated, @Status, @Price, @Payment, @IdUser)",
            inIdsBooks, inDateTimeCreated, inStatus, inPrice, inPayment, inIdUser);

        var books = order.Books.Split(',')
            .Select(x => x.Split('-'))
            .ToArray();
    
        foreach (var book in books)
        {
            var updateCountQuery = "UPDATE Books SET Count = Count - @Count WHERE Id = @IdBook";
            var inBookId = new SqliteParameter("@IdBook", int.Parse(book[0]));
            var inCount = new SqliteParameter("@Count", int.Parse(book[1]));
        
            context.Database.ExecuteSqlRaw(updateCountQuery, inCount, inBookId);
        }
    }
}