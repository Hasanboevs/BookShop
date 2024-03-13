namespace BookShop.Domain.Entities;

public class Auditable
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;   
    public DateTime UpdatedDate { get; set;}
}
