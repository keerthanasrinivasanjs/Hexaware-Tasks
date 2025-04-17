using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionAss;

namespace techshop_app
{
    internal class ProductManager
    {
      
        
            private List<Product> products = new List<Product>();

            public void AddProduct(string name, decimal price, string sku, int stock)
            {
                if (products.Any(p => p.SKU == sku))
                    throw new Exception("Duplicate product SKU.");

                int id = products.Count + 1;
                Product newProduct = new Product { Id = id, Name = name, Price = price, SKU = sku, Stock = stock };
                products.Add(newProduct);
                Inventory.AddStock(id, stock);
                Console.WriteLine("Product added successfully!");
            }

            public void UpdateProduct(int id, string name, decimal price, int stock)
            {
                Product p = products.FirstOrDefault(x => x.Id == id);
                if (p == null) throw new Exception("Product not found.");

                p.Name = name;
                p.Price = price;
                p.Stock = stock;
                Inventory.AddStock(id, stock);
                Console.WriteLine("Product updated.");
            }

            public void RemoveProduct(int id)
            {
                Product p = products.FirstOrDefault(x => x.Id == id);
                if (p == null) throw new Exception("Product not found.");
                products.Remove(p);
                Inventory.RemoveStock(id, p.Stock);
                Console.WriteLine("Product removed.");
            }

            public List<Product> SearchProduct(string keyword)
            {
                return products.Where(p => p.Name.ToLower().Contains(keyword.ToLower())).ToList();
            }

            public List<Product> GetAllProducts()
            {
                return products;
            }
        }
    }