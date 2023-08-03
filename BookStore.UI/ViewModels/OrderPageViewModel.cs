using System;
using System.Linq;
using BookStore.Storage.Models;
using BookStore.Storage.Repositories;
using PAS.Storage.Models.Enums;

namespace BookStore.UI.ViewModels;

public class OrderPageViewModel
{
    private IBookStoreAppRepository DataStore { get; } = new BookStoreAppRepository();

    private readonly Order _order;

    private readonly Book[] _books;

    public Book[] Books => _books;
    
    public int Id => _order.Id;

    public string Status => _order.Status;

    public PaymentType Payment => _order.Payment;

    public DateTime DateTimeCreated => _order.DateTimeCreated;
    
    public decimal Price => _order.Price;

    public OrderPageViewModel(Order order)
    {
        _order = order;

        _books = order.Books
            .Split(',')
            .Select(x => x.Split('-'))
            .Select(x => int.Parse(x[0]))
            .Select(x => DataStore.Books.GetBookByID(x))
            .ToArray();
    }
}