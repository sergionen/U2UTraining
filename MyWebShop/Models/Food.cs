namespace MyWebShop.Models
{
    public class Food : Product
    {
        public decimal Weight { get; set; }
        public Food()
        {

        }
        public Food(string name, decimal unitPrice) : base(name, unitPrice)
        {
        }
    }
}
