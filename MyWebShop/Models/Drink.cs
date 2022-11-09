namespace MyWebShop.Models
{
    public class Drink : Product
    {
        public bool ContainsAlcohol { get; set; }

        public Drink()
        {

        }

        public Drink(string name, decimal unitPrice) : base(name, unitPrice)
        {
        }
    }
}
