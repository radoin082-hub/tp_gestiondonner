namespace BlazorApp1.Models
{
    public class Product
    {
        public String id { get; set; }
        public String name {  get; set; }
        public String description { get; set; }
        public String price { get; set; }
        public String category { get; set; }
        public String stock { get; set; }

        public Product(String _name , String _id,   String _description, String _price, String _category, String _stock) { 
            this.name = _name;
            this.id = _id;
            this.description = _description;
            this.price = _price;
            this.category = _category;
            this.stock = _stock;

        
        }

    }
}
