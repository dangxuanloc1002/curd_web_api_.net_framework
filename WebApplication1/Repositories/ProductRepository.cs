using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Repositories.interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private DBModel entities;
        public ProductRepository(DBModel entities)
        {
            this.entities = entities;
        }

        public void DeleteProduct(int id)



        {
            product pr = this.entities.products.Where(p => p.id == id).FirstOrDefault();
            this.entities.products.Remove(pr);
            this.Save();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<product> GetAllProduct()
        {
            List<product> productList = new List<product>();
            productList = this.entities.products.ToList<product>();
            return productList;
        }

        public product GetProductByID(int id)
        {
            product detail = null;
            detail = this.entities.products.Where(p => p.id == id).FirstOrDefault<product>();
            return detail;
        }

        public void InsertProduct(product productModel)
        {
            this.entities.products.Add(productModel);
            this.Save();
        }

        public void Save()
        {
            this.entities.SaveChanges();
        }

        public void UpdateProduct(int id, product productModel)
        {
            product pr = this.entities.products.Where(p => p.id == id).SingleOrDefault();
            pr.name = productModel.name;
            pr.unit_price = productModel.unit_price;
            pr.count = productModel.count;
            pr.category_id = productModel.category_id;
            this.Save();
        }
    }
}