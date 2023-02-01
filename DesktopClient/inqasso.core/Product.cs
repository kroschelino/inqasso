using Inqasso.Core.Context;
using Inqasso.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Inqasso.Core;

public class Product : IProduct
{
    private readonly Core _core;
    private readonly ILogger<IProduct> _logger;

    private readonly int _id = 0;

    public Product(Core core, string name, string? flavor, ILogger<IProduct>? logger = null) : this(core, 0, logger)
    {
        var flavor1 = flavor ?? string.Empty;

        var model = new Models.Product
        {
            Name = name,
            Flavor = flavor1
        };

        using var context = core.CreateContext();
        context.Products.Add(model);
        context.SaveChanges();
        _id = model.Id;
    }

    public Product(Core core, int id, ILogger<IProduct>? logger = null)
    {
        _logger = logger ?? NullLogger<IProduct>.Instance;
        _core = core;
        _id = id;
        TotalSold = 0;
        TotalBought = 0;
        TotalEarnings = 0;
    }

    private Models.Product? GetReadonlyModel()
    {
        using var context = _core.CreateContext();
        return context.Products.AsNoTracking().SingleOrDefault(_ => _.Id == _id);
    }

    private Models.Product GetModel(InqassoContext context)
    {
        return context.Products.Single(_ => _.Id == _id); 
    }

    #region IProduct

    public string Name
    {
        get => GetReadonlyModel()?.Name ?? string.Empty;
        set
        {
            using var context = _core.CreateContext();
            GetModel(context).Name = value;
            context.SaveChanges();
        }
    }

    public string Flavor
    {
        get => GetReadonlyModel()?.Flavor ?? string.Empty;
        set
        {
            using var context = _core.CreateContext();
            GetModel(context).Flavor = value;
            context.SaveChanges();
        }
    }

    public int TotalSold { get; }
    public int TotalBought { get; }
    public decimal TotalEarnings { get; }

    public IEnumerable<int> TypicalSizes => GetReadonlyModel()?.TypicalSizes ?? new List<int>();

    public void AddTypicalSize(IEnumerable<int> sizes)
    {
        using var context = _core.CreateContext();
        var model = GetModel(context);
        var typicalSizesList = model.TypicalSizes.ToHashSet();
        foreach (var size in sizes)
        {
            typicalSizesList.Add(size);
        }
        model.TypicalSizes = typicalSizesList;
        context.SaveChanges();
    }

    public void RemoveTypicalSize(int size)
    {
        using var context = _core.CreateContext();
        var model = GetModel(context);
        var typicalSizesList = model.TypicalSizes.ToHashSet();
        typicalSizesList.Remove(size);
        model.TypicalSizes = typicalSizesList;
        context.SaveChanges();
    }


    #endregion


}