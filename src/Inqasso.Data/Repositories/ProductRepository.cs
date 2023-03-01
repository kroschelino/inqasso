using System.Linq.Expressions;
using Inqasso.Data.Context;
using Inqasso.Data.Repositories.Interfaces;

namespace Inqasso.Data.Repositories;

internal class ProductRepository : IProductRepository
{
    private readonly InqassoContext _context;

    public ProductRepository(InqassoContext context)
    {
        _context = context;
    }

    public IQueryable<Product> Get(Expression<Func<Product, bool>>? filter = null,
        Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null)
    {
        return _context.Products;
    }

    public Task<Product> Create(Product entity)
    {
        return Task.FromResult(_context.Set<Product>().Add(entity).Entity);
    }

    public Task<Product> Delete(Product entity)
    {
        return Task.FromResult(_context.Set<Product>().Remove(entity).Entity);
    }
}