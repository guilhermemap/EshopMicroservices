namespace Catalog.API.Exceptions;

public class ProductNotFoundExpeption : Exception
{
    public ProductNotFoundExpeption() : base("Product not found!") { }
}
