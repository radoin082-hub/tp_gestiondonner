using System.Xml.Linq;

using BlazorApp1.Models;


namespace BlazorApp1.Services
{
    public class ProductService
    {
     

        public List<Product> ReadProducts(string path)
        {
            List<Product> products = new List<Product>();
            try
            {
                
                XDocument xmlDoc = XDocument.Load(path);
                var productsXML = xmlDoc.Element("products")?.Elements("product");

              
                if (productsXML != null)
                {
                    foreach (var product in productsXML)
                    {
                
                        string id = product.Element("id")?.Value;
                        string name = product.Element("name")?.Value;
                        string description = product.Element("description")?.Value;
                        string price = product.Element("price")?.Value;
                        string category = product.Element("category")?.Value;
                        string stock = product.Element("stock")?.Value;

               
                        products.Add(new Product(name, id, description, price, category, stock));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return products;
        }

        public void AddProduct(string path, Product product)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(path);
                var productsXML = xmlDoc.Element("products");

                XElement newProduct = new XElement("product",
                    new XElement("id", product.id),
                    new XElement("name", product.name),
                    new XElement("description", product.description),
                    new XElement("price", product.price),
                    new XElement("category", product.category),
                    new XElement("stock", product.stock));

                
                productsXML?.Add(newProduct);
                xmlDoc.Save(path);
                     }
            catch (Exception e)
            {
                 }
        }

        public void UpdateProduct(string path, Product updatedProduct)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(path);
                var productToUpdate = xmlDoc.Descendants("product")
                    .FirstOrDefault(p => (string)p.Element("id") == updatedProduct.id);

              
                if (productToUpdate != null)
                {
   
                    productToUpdate.Element("name").Value = updatedProduct.name;
                    productToUpdate.Element("description").Value = updatedProduct.description;
                    productToUpdate.Element("price").Value = updatedProduct.price;
                    productToUpdate.Element("category").Value = updatedProduct.category;
                    productToUpdate.Element("stock").Value = updatedProduct.stock;

                    xmlDoc.Save(path);
                       }
                else
                {
                    Console.WriteLine("null");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteProduct(string path, Product product)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(path);
                var productsXML = xmlDoc.Descendants("product")
                    .FirstOrDefault(p => (string)p.Element("id") == product.id);

               
                if (productsXML != null)
                {
                    productsXML.Remove();
                    xmlDoc.Save(path);
                   
                }
                else
                {
                    Console.WriteLine("null");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
