using BookStore.Storage.Contexts;
using BookStore.Storage.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Storage.Repositories;

public class UserRepository
{
    public static ProfileRepository ProfileRepository { get; } = new();
    
    public User GetUserByID(int ID)
    {
        using var context = new BookStoreAppContext();
        
        var inId = new SqliteParameter("@Id", ID);
        List<User> users = context.Users.FromSqlRaw("SELECT Users.Id, " +
                                                    "Users.Login, " +
                                                    "Users.Password " +
                                                    "FROM Users " +
                                                    "WHERE Users.Id = @Id",
            inId).ToList();
        var user = users.FirstOrDefault();
        return user;
    }
    
    public User GetUserByLogin(string login)
    {
        using var context = new BookStoreAppContext();
        
        var inLogin = new SqliteParameter("@Login", login);
        List<User> users = context.Users.FromSqlRaw("SELECT Users.Id, " +
                                                    "Users.Login, " +
                                                    "Users.Password " +
                                                    "FROM Users " +
                                                    "WHERE Users.Login = @Login",
            inLogin).ToList();
        var user = users.FirstOrDefault();
        return user;
    }

    public void CreateUser(string login, string password, string email)
    {
        using var context = new BookStoreAppContext();
        
        var inEmail = new SqliteParameter("@Email", email);

        context.Database.ExecuteSqlRaw("INSERT INTO Profiles (Name, Surname, Email, Phone, IdUser) " +
                                       "VALUES ('', '', @Email, '', 0)", inEmail);

        var profile = ProfileRepository.GetProfileByEmail(email);
        var idProfile = profile.Id;
        
        var inLogin = new SqliteParameter("@Login", login);
        var inPassword = new SqliteParameter("@Password", password);
        var inIdProfile = new SqliteParameter("@IdProfile", idProfile);

        context.Database.ExecuteSqlRaw("INSERT INTO Users (Login, Password, IdProfile) " +
                                       "VALUES (@Login, @Password, @IdProfile)",
            inLogin, inPassword, inIdProfile);

        var user = GetUserByLogin(login);
        var inIdUser = new SqliteParameter("@IdUser", user.Id);

        context.Database.ExecuteSqlRaw("UPDATE Profiles " +
                                       "SET IdUser = @IdUser " +
                                       "WHERE Id = @IdProfile",
            inIdUser, inIdProfile);
    }
    
    public bool IsLoginExists(string login)
    {
        var user = GetUserByLogin(login);
        return user != null;
    }

    public User[] GetUsers()
    {
        using var context = new BookStoreAppContext();
        
        var users = context.Users.FromSqlRaw("SELECT Users.Id, " +
                                                    "Users.Login, " +
                                                    "Users.Password " +
                                                    "FROM Users");
        return users.ToArray();
    }
}