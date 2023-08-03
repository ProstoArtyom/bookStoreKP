using BookStore.Storage.Contexts;
using BookStore.Storage.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Storage.Repositories;

public class BookRepository
{
    public Book[] GetBooks()
    {
        using var context = new BookStoreAppContext();

        var books = context.Books.FromSqlRaw("SELECT Books.Id, " +
                                             "Books.Title, " +
                                             "Books.Author, " +
                                             "Books.Isbn, " +
                                             "Books.Description, " +
                                             "Books.Price, " +
                                             "Books.Category, " +
                                             "Books.Count, " +
                                             "Books.Image " +
                                             "FROM Books").ToList();
        return books.ToArray();
    }

    public Book[] GetBooksByCategory(string category)
    {
        using var context = new BookStoreAppContext();

        var inCategory = new SqliteParameter("@Category", category);

        var books = context.Books.FromSqlRaw("SELECT Books.Id, " +
                                                   "Books.Title, " +
                                                   "Books.Author, " +
                                                   "Books.Isbn, " +
                                                   "Books.Description, " +
                                                   "Books.Price, " +
                                                   "Books.Category, " +
                                                   "Books.Count, " +
                                                   "Books.Image " +
                                                   "FROM Books " +
                                                   "WHERE Books.Category = @Category",
            inCategory).ToList();
        return books.ToArray();
    }

    public Book GetBookByID(int idBook)
    {
        using var context = new BookStoreAppContext();
        
        var inIdBook = new SqliteParameter("@IdBook", idBook);

        var books = context.Books.FromSqlRaw("SELECT Books.Id, " + 
                                                "Books.Title, " +
                                                "Books.Author, " +
                                                "Books.Isbn, " +
                                                "Books.Description, " +
                                                "Books.Price, " +
                                                "Books.Category, " +
                                                "Books.Count, " +
                                                "Books.Image " + 
                                                "FROM Books " +
                                                "WHERE Books.Id = @IdBook",
            inIdBook).ToList();
        return books.FirstOrDefault();
    }
    
    public void UpdateBook(Book book)
    {
        using var context = new BookStoreAppContext();
        
        var inId = new SqliteParameter("@Id", book.Id);
        var inTitle = new SqliteParameter("@Title", book.Title);
        var inAuthor = new SqliteParameter("@Author", book.Author);
        var inIsbn = new SqliteParameter("@Isbn", book.Isbn);
        var inDescription = new SqliteParameter("@Description", book.Description);
        var inPrice = new SqliteParameter("@Price", book.Price);
        var inCategory = new SqliteParameter("@Category", book.Category);
        var inCount = new SqliteParameter("@Count", book.Count);
        var inImage = new SqliteParameter("@Image", book.Image);

        context.Database.ExecuteSqlRaw("UPDATE Books " +
                                       "SET Title = @Title, Author = @Author, Isbn = @Isbn, Description = @Description, " +
                                       "Price = @Price, Category = @Category, Count = @Count, Image = @Image " +
                                       "WHERE Id = @Id",
            inId, inTitle, inAuthor, inIsbn, inDescription, inPrice, inCategory, inCount, inImage);
    }

    public void AddBook(Book book)
    {
        using var context = new BookStoreAppContext();
    
        context.Books.Add(book);
        context.SaveChanges();
    }

    public void DeleteBookById(int bookId)
    {
        using var context = new BookStoreAppContext();
    
        var inBookId = new SqliteParameter("@BookId", bookId);

        context.Database.ExecuteSqlRaw("DELETE FROM Books " +
                                       "WHERE Id = @BookId",
            inBookId);
    }
}