namespace Catalog.API.Products.GetProductsByCategory
{

    public record GetProductsByCategoryQuery(string CategoryId) : IQuery<GetProductsByCategoryResult>;

    public record GetProductsByCategoryResult(IEnumerable<Product> Products);

    internal class GetProductsByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductsByCategoryQueryHandler> logger) : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
    {
        public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsByCategoryHandler.Handle called with {@query}", query);

            var products = await session.Query<Product>().Where(p => p.Category.Contains(query.CategoryId)).ToListAsync(cancellationToken);

            return new GetProductsByCategoryResult(products);
        }
    }
}
