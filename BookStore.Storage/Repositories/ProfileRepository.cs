using BookStore.Storage.Contexts;
using BookStore.Storage.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Storage.Repositories;

public class ProfileRepository
{
    public Profile GetProfileByEmail(string email)
    {
        using var context = new BookStoreAppContext();
        
        var inEmail = new SqliteParameter("@Email", email);
        List<Profile> profiles = context.Profiles.FromSqlRaw("SELECT Profiles.Id, " +
                                                             "Profiles.[Name], " +
                                                             "Profiles.Surname, " +
                                                             "Profiles.Email, " +
                                                             "Profiles.Phone, " +
                                                             "Profiles.IdUser " +
                                                             "FROM Profiles " +
                                                             "WHERE Profiles.Email = @Email",
            inEmail).ToList();
        var profile = profiles.FirstOrDefault();
        return profile;
    }
    
    public bool IsEmailUsed(string email, int idUser)
    {
        var profile = GetProfileByEmail(email);
        return profile != null && profile.IdUser != idUser;
    }

    public Profile GetProfileByID(int IdUser)
    {
        using var context = new BookStoreAppContext();
        
        var inIdUser = new SqliteParameter("@IdUser", IdUser);
        List<Profile> profiles = context.Profiles.FromSqlRaw("SELECT Profiles.ID, " +
                                                            "Profiles.[Name], " +
                                                            "Profiles.Surname, " +
                                                            "Profiles.Email, " +
                                                            "Profiles.Phone, " +
                                                            "Profiles.IdUser " +
                                                            "FROM Profiles " +
                                                            "WHERE Profiles.IdUser = @IdUser",
            inIdUser).ToList();
        var profile = profiles.FirstOrDefault();
        return profile;
    }

    public void SetProfile(Profile profile)
    {
        using var context = new BookStoreAppContext();
        
        var inId = new SqliteParameter("@Id", profile.Id);
        var inName = new SqliteParameter("@Name", profile.Name);
        var inSurname = new SqliteParameter("@Surname", profile.Surname);
        var inEmail = new SqliteParameter("@Email", profile.Email);
        var inPhone = new SqliteParameter("@Phone", profile.Phone);

        context.Database.ExecuteSqlRaw("UPDATE Profiles " +
                                       "SET Name = @Name, Surname = @Surname, Email = @Email, Phone = @Phone " +
                                       "WHERE Id = @Id",
            inName, inSurname, inEmail, inPhone, inId);
    }

    public Profile GetProfileByPhone(string phone)
    {
        using var context = new BookStoreAppContext();
        
        var inPhone = new SqliteParameter("@Phone", phone);
        List<Profile> profiles = context.Profiles.FromSqlRaw("SELECT Profiles.Id, " +
                                                             "Profiles.[Name], " +
                                                             "Profiles.Surname, " +
                                                             "Profiles.Email, " +
                                                             "Profiles.Phone, " +
                                                             "Profiles.IdUser " +
                                                             "FROM Profiles " +
                                                             "WHERE Profiles.Phone = @Phone",
            inPhone).ToList();
        var profile = profiles.FirstOrDefault();
        return profile;
    }
    
    public bool IsPhoneUsed(string phone, int idUser)
    {
        var profile = GetProfileByPhone(phone);
        
        return profile != null && profile.IdUser != idUser;
    }
}