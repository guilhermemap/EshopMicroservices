using Catalog.API.Exceptions;

namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryQuery(Guid Id) : IQuery<GetProductByCategoryResult>;
public record GetProductByCategoryResult(Product Product);

internal class GetProductByCategoryQueryHandler
    (IDocumentSession session, ILogger<GetProductByCategoryQueryHandler> logger)
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query,
                                                         CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByIdQueryHandler.Handle called with {@query}", query);

        var product = await session.LoadAsync<Product>(query.Id, cancellationToken)
            ?? throw new ProductNotFoundExpeption();

        return new GetProductByCategoryResult(product);
    }
}