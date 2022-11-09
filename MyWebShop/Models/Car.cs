namespace MyWebShop.Models
{
    public class Car : Vehicle
    {
        public Car()
        {

        }

        public Car(string name, decimal unitPrice, decimal speed) : base(name, unitPrice, speed)
        {
        }
    }
}
