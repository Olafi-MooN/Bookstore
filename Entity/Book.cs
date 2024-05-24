using Bookstore.DataStore;
using Bookstore.Entity.Enums;

namespace Bookstore.Entity;

public class Book : DataStoreDefaultProps
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public BookGenreEnum Genre { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
