
namespace Catalog.API.Products.GetProductByCategory;

//public record GetProductByCategoryRequest();
public record GetProductByCategoryResponse(Product Product);

public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByCategoryQuery(id));

            var response = result.Adapt<GetProductByCategoryResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProductByCategory")
        .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Category")
        .WithDescription("Get Product By Category.");
    }
}