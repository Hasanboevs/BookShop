namespace BookShop.Domain.Models.Response;

public class ResponseModel<T>
{
    public bool Status { get; set; }
    public string Error { get; set; }
    public T Data { get; set; }
    public bool? Global { get; set; } = null;

}
