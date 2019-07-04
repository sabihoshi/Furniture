namespace Furniture.Materials
{
    public class Wood : IMaterial
    {
        public Wood(int length, string name, decimal price, int quantity, int thickness, int width)
        {
            Length = length;
            Name = name;
            Price = price;
            Quantity = quantity;
            Thickness = thickness;
            Width = width;
        }

        public int Length { get; set; }
        public string Name { get; }
        public decimal Price { get; }
        public int Quantity { get; set; }
        public int Thickness { get; set; }
        public int Width { get; set; }
    }
}