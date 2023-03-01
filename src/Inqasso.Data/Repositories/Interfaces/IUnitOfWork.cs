namespace Inqasso.Data.Repositories.Interfaces;

internal interface IUnitOfWork
{
    public IProductRepository Products { get; }

    Task Commit();
}