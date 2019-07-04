namespace Furniture.Work
{
    public class Area : IWork, ICanCalculate
    {
        public Area(string name, decimal percentage)
        {
            Name = name;
            Percentage = percentage;
        }

        public string Name { get; set; }
        public decimal Percentage { get; set; }
        public decimal Total { get; set; }

        public decimal Calculate(decimal input)
        {
            Total = input * Percentage;
            return Total;
        }
    }
}