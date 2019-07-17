namespace Furniture.ViewModels.Quotation
{
    public interface ICalculate
    {
        string Name { get; set; }
        decimal? Total { get; set; }
        decimal? GetTotal();
    }
}