using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAss.Services
{
    internal class ProductSearchService
    {
        private readonly List<Product> products;

        public ProductSearchService(List<Product> productList)
        {
            products = productList ?? throw new ArgumentNullException(nameof(productList), "Product list cannot be null.");
        }

        public List<Product> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Search name cannot be null or empty.", nameof(name));

            var results = products
                .Where(p => p.Name != null && p.Name.ToLower().Contains(name.ToLower()))
                .ToList();

            if (results.Count == 0)
                throw new Exception("No products found matching the name.");

            return results;
        }

        public List<Product> SearchByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Category cannot be null or empty.", nameof(category));

            var results = products
                .Where(p => p.Category != null && p.Category.ToLower() == category.ToLower())
                .ToList();

            if (results.Count == 0)
                throw new Exception("No products found in this category.");

            return results;
        }

        public List<Product> SortByPrice(bool ascending = true)
        {
            return ascending
                ? products.OrderBy(p => p.Price).ToList()
                : products.OrderByDescending(p => p.Price).ToList();
        }

        public List<Product> SortByName()
        {
            return products.OrderBy(p => p.Name).ToList();
        }
    }
}