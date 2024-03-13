namespace BookShop.Domain.Entities.Books;

public class Book : Auditable
{
    public string AuthorName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
