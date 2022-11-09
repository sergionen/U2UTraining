namespace MyWebShop.Models
{
    public class Product
    {
        public string? Name { get; set; }
        public decimal UnitPrice { get; set; }  

        public Product()
        {

        }

        public Product(string name, decimal unitPrice)
        {
            this.Name = name;
            this.UnitPrice = unitPrice; 
        }            
    }
}
