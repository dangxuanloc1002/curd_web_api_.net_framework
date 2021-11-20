using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Repositories.interfaces;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IProductRepository _productRepository;
        private UnitOfWork unitWork;

        public ValuesController()
        {

            this.unitWork = new UnitOfWork(new DBModel());
            this._productRepository = this.unitWork.ProductRepo;
        }

        // GET api/values
        public List<product> Get()
        {

            return (List<product>)this._productRepository.GetAllProduct();
        }

        // GET api/values/5
        public product Get(int id)
        {
            return (product)this._productRepository.GetProductByID(id);
        }

        // POST api/values
        public void Post(product productModel)
        {
            this._productRepository.InsertProduct(productModel);

        }

        // PUT api/values/5
        public void Put(int id, product productModel)
        {
            this._productRepository.UpdateProduct(id, productModel);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            this._productRepository.DeleteProduct(id);
        }
    }
}
