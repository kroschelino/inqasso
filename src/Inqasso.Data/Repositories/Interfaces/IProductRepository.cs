using System.Linq.Expressions;

namespace Inqasso.Data.Repositories.Interfaces;

internal interface IProductRepository
{
    IQueryable<Product> Get(Expression<Func<Product, bool>> filter = null,
        Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null);

    Task<Product> Create(Product entity);

    Task<Product> Delete(Product entity);
}