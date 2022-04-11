namespace Phoneshop.Business
{
    public class Phone
    {
        public int Id { get; private set; }
        public string Brand { get; private set; }
        public string Type { get; private set; }
        public string Description { get; private set; }
        public double FullPrice { get; private set; }
        public double Price { get; private set; }

        static int count = 1;

        public Phone(string brand, string type, string description, double price)
        {
            this.Id = count++;
            this.Brand = brand;
            this.Type = type;
            this.Description = description;
            this.FullPrice = price;
            this.Price = FullPrice / 119 * 100;
        }
    }
}