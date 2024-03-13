namespace BookShop.Service.Exceptions;

public class BookShopException : Exception
{
    public int Code { get; set; }
    public bool? Global { get; set; }

    public BookShopException(int code , string message, bool? global = true) : base(message)
    {
        Code = code;
        Global = global;
    }
}
