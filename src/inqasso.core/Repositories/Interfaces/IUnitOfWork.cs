namespace Inqasso.Core.Repositories.Interfaces;

internal interface IUnitOfWork
{
    public IProductRepository Products { get; }

    Task Commit();
}