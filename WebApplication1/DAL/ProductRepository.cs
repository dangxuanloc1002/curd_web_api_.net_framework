using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAL.interfaces;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        DBModel dbModel = new DBModel();

        public void DeleteProduct(int id)
        {
            product pr = dbModel.products.Where(p => p.id == id).FirstOrDefault();
            dbModel.products.Remove(pr);
            this.Save();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<product> GetAllProduct()
        {
            List<product> productList = new List<product>();
            productList = dbModel.products.ToList<product>();
            return productList;
        }

        public product GetProductByID(int id)
        {
            product detail = null;
            detail = dbModel.products.Where(p => p.id == id).FirstOrDefault<product>();
            return detail;
        }

        public void InsertProduct(product productModel)
        {
            dbModel.products.Add(productModel);
            this.Save();
        }

        public void Save()
        {
            dbModel.SaveChanges();
        }

        public void UpdateProduct(int id, product productModel)
        {
            product pr = dbModel.products.Where(p => p.id == id).SingleOrDefault();
            pr.name = productModel.name;
            pr.unit_price = productModel.unit_price;
            pr.count = productModel.count;
            pr.category_id = productModel.category_id;
            this.Save();
        }
    }
}