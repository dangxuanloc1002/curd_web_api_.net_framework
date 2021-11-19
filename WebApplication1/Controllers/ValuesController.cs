using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<product> Get()
        {
            List<product> productList = new List<product>();
            using (DBModel dbModel = new DBModel())
            {
                productList = dbModel.products.ToList<product>();
            }
            return productList;
        }

        // GET api/values/5
        public product Get(int id)
        {
            product detail = null;
            using (DBModel dbModel = new DBModel())
            {
                detail = dbModel.products.Where(p => p.id == id).FirstOrDefault<product>();
            }
            return detail;
        }

        // POST api/values
        public void Post(product productModel)
        {
            using (DBModel dbModel = new DBModel())
            {
                dbModel.products.Add(productModel);
                dbModel.SaveChanges();
            }

        }

        // PUT api/values/5
        public void Put(int id, product productModel)
        {
            using (DBModel dbModel = new DBModel())
            {
                product pr = dbModel.products.Where(p => p.id == id).SingleOrDefault();
                pr.name = productModel.name;
                pr.unit_price = productModel.unit_price;
                pr.count = productModel.count;
                pr.category_id = productModel.category_id;
                dbModel.SaveChanges();
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
             using (DBModel dbModel = new DBModel())
            {
                product pr = dbModel.products.Where(p => p.id == id).FirstOrDefault();
                    dbModel.products.Remove(pr);
                    dbModel.SaveChanges();
            }

        }
    }
}
