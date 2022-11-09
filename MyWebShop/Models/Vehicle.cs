namespace MyWebShop.Models
{
    public class Vehicle : Product
    {
        public decimal Speed { get; set; }

        public Vehicle()
        {
            
        }

        public Vehicle(string name, decimal unitPrice, decimal speed) : base(name, unitPrice)
        {
            Speed = speed;
        }
    }
}
