using System.Xml.Linq;
using System.IO;
using BlazorApp1.Models;
using System.Xml;
using System.Linq;
using System;
using DotNetEnv;
namespace BlazorApp1.Services
{
    public class ProductService
    {
        public ProductService()
        {
          
        }




        public List<Product> readProducts(String path)
        {
            List<Product> products=new List<Product>();
            try
            {
                XDocument xmlDoc = XDocument.Load(path);

                var productsXML = xmlDoc.Element("products")?.Elements("product");

                foreach(var product in productsXML)
                {
                   String id=  product.Element("id")?.Value;
                    String name = product.Element("name")?.Value;
                    String description = product.Element("description")?.Value;
                    String price = product.Element("price")?.Value;
                    String category = product.Element("category")?.Value;
                    String stock = product.Element("stock")?.Value; 
                    products.Add(new Product(name,id, description, price, category, stock));
                }



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            
            return products;
        }

        public void addProduct(string path,Product product)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(path);

                var productsXML = xmlDoc.Element("products");
             XElement newproducts= new XElement("product", new XElement("id", product.id),new XElement("name",product.name));
                productsXML.Add(newproducts);
                xmlDoc.Save(path);

                Console.WriteLine("hi");
                    }
            catch (Exception e)
            {

            }
        }



        public void editProduct(string path, Product product)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(path);



               /* var productsXML = xmlDoc.Descendants("product").FirstOrDefault(p => (string)p.Element("id") =="5");

                *//*   productsXML.Element("id")?.SetValue("5");*//*
                productsXML.Remove();
             */

                xmlDoc.Save(path);
                Env.Load("key.env");
                 path = Env.GetString("xmlkey");
                Console.WriteLine(path);
               
            }
            catch (Exception e)
            {

            }
        }

       


    }
}

