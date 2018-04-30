using System;
using System.Collections.Generic;
using System.Text;

namespace SqlIntro
{
    class DapperProductRepository
    {
        private readonly string _connectionString;

        public DapperProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Product> GetProducts()
        {

        }

        public void DeleteProduct(int id)
        {

        }

        public void UpdateProduct(Product prod)
        {

        }

        public void InsertProduct(Product prod)
        {

        }
    }
}
