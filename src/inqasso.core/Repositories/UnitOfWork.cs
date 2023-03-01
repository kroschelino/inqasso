using Inqasso.Core.Context;
using Inqasso.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Inqasso.Core.Repositories;

internal class UnitOfWork : IUnitOfWork
{
    private readonly InqassoContext _context;
    private IProductRepository? _products;


    public UnitOfWork(IDbContextFactory<InqassoContext> contextFactory)
    {
        _context = contextFactory.CreateDbContext();
    }

    public IProductRepository Products
    {
        get { return _products ??= new ProductRepository(_context); }
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}