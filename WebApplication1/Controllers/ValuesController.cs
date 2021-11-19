using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DAL.interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IProductRepository _productRepository;

        public ValuesController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET api/values
        public List<product> Get()
        {

            return (List<product>)_productRepository.GetAllProduct();
        }

        // GET api/values/5
        public product Get(int id)
        {
            return (product)_productRepository.GetProductByID(id);
        }

        // POST api/values
        public void Post(product productModel)
        {
            _productRepository.InsertProduct(productModel);

        }

        // PUT api/values/5
        public void Put(int id, product productModel)
        {
            _productRepository.UpdateProduct(id, productModel);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _productRepository.DeleteProduct(id);
        }
    }
}
