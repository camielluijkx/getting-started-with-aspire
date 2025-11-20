using BookStoreAspire.ApiService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("booksDb")
    ?? throw new InvalidOperationException("Connection string 'booksDb' not found.");

builder.Services.AddDbContext<BookStoreDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.AddServiceDefaults();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<BookStoreDbContext>();
    db.Database.Migrate();
}

app.MapGet("/books", async (BookStoreDbContext db) =>
    await db.Books.AsNoTracking().ToListAsync());

app.MapGet("/books/{id:guid}", async (Guid id, BookStoreDbContext db) =>
    await db.Books.FindAsync(id) is { } book ? Results.Ok(book) : Results.NotFound());

app.MapPost("/books", async (BookDto request, BookStoreDbContext db) =>
{
    var book = new Book(request.Title, request.Author, request.Price);
    db.Books.Add(book);
    await db.SaveChangesAsync();
    return Results.Created($"/books/{book.Id}", book);
});

app.MapPut("/books/{id:guid}", async (Guid id, BookDto request, BookStoreDbContext db) =>
{
    var book = await db.Books.FindAsync(id);
    if (book is null) return Results.NotFound();

    book.Update(request.Title, request.Author, request.Price);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/books/{id:guid}", async (Guid id, BookStoreDbContext db) =>
{
    var book = await db.Books.FindAsync(id);
    if (book is null) return Results.NotFound();

    db.Books.Remove(book);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDefaultEndpoints();

app.Run();

public sealed record BookDto(string Title, string Author, decimal Price);