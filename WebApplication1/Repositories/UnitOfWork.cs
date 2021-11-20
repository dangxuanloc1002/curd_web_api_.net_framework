using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UnitOfWork
    {
        private DBModel entities = new DBModel();
        private ProductRepository productRepo;

        public UnitOfWork(DBModel entities)
        {
            this.entities = entities;
        }

        public ProductRepository ProductRepo
        {
            get
            {
                if (productRepo == null)
                {
                    this.productRepo = new ProductRepository(this.entities);
                }
                return this.productRepo;
            }
        }
    }
}