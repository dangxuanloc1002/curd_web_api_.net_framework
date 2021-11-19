using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DAL.interfaces
{
    interface IProductRepository : IDisposable
    {
        IEnumerable<product> GetAllProduct();
        product GetProductByID(int id);
        void InsertProduct(product productModel);
        void DeleteProduct(int id);
        void UpdateProduct(int id, product productModel);
        void Save();
    }
}
