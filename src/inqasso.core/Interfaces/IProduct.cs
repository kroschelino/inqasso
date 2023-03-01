namespace Inqasso.Core.Interfaces;

public interface IProduct
{
    public string Name { get; set; }
    public string Flavor { get; set; }


    #region Statistics

    public int TotalSold { get; }
    public int TotalBought { get; }
    public decimal TotalEarnings { get; }

    #endregion


    #region Product Sizes

    public IEnumerable<int> TypicalSizes { get; }
    public void AddTypicalSize(int size) => AddTypicalSize(new List<int>() { size });
    public void AddTypicalSize(IEnumerable<int> sizes);
    public void RemoveTypicalSize(int size);

    #endregion
}