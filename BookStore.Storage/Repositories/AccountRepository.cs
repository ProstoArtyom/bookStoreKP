using BookStore.Storage.Contexts;
using BookStore.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Storage.Repositories;

public class AccountRepository
{
    public Account[] GetAccounts()
    {
        using var context = new BookStoreAppContext();

        var accounts = context.Accounts.FromSqlRaw("SELECT Profiles.Id, " +
                                                   "Profiles.[Name], " +
                                                   "Profiles.Surname, " +
                                                   "Profiles.Email, " +
                                                   "Profiles.Phone, " +
                                                   "Profiles.IdUser, " +
                                                   "Users.Login, " +
                                                   "Users.Password " +
                                                   "FROM Profiles " +
                                                   "JOIN Users ON Profiles.IdUser = Users.Id");
        return accounts.ToArray();
    }

    public void UpdateAccount(Account account)
    {
        using var context = new BookStoreAppContext();

        context.Database.ExecuteSqlRaw("UPDATE Profiles " +
                                       "SET [Name] = {0}, " +
                                       "Surname = {1}, " +
                                       "Email = {2}, " +
                                       "Phone = {3} " +
                                       "WHERE Id = {4}",
            account.Name,
            account.Surname,
            account.Email,
            account.Phone,
            account.IdUser);

        context.Database.ExecuteSqlRaw("UPDATE Users " +
                                       "SET Login = {0}, " +
                                       "Password = {1} " +
                                       "WHERE Id = {2}",
            account.Login, account.Password, account.IdUser);

        context.SaveChanges();
    }

    public void DeleteAccount(Account account)
    {
        using var context = new BookStoreAppContext();

        context.Database.ExecuteSqlRaw("DELETE FROM Profiles " +
                                       "WHERE IdUser = {0}",
            account.IdUser);

        context.Database.ExecuteSqlRaw("DELETE FROM Users " +
                                       "WHERE Id = {0}",
            account.IdUser);

        context.Database.ExecuteSqlRaw("DELETE FROM Cart " +
                                       "WHERE IdUser = {0}",
            account.IdUser);

        context.Database.ExecuteSqlRaw("DELETE FROM Orders " +
                                       "WHERE IdUser = {0}",
            account.IdUser);

        context.SaveChanges();
    }
}