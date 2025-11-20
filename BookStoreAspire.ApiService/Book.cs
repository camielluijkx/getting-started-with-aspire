namespace BookStoreAspire.ApiService;

public sealed class Book
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; } = default!;
    public string Author { get; private set; } = default!;
    public decimal Price { get; private set; }

    public Book(string title, string author, decimal price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    public void Update(string title, string author, decimal price)
    {
        Title = title;
        Author = author;
        Price = price;
    }
}