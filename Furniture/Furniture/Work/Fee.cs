namespace Furniture.Work
{
    public class Fee : IWork
    {
        public Fee(string name, decimal total)
        {
            Name = name;
            Total = total;
        }

        public string Name { get; set; }
        public decimal Total { get; set; }
    }
}