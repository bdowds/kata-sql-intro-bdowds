using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;

namespace SqlIntro
{
    class DapperProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public DapperProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<Product>("SELECT ProductId AS Id, Name FROM product;");
            }
        }

        public void DeleteProduct(int id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("DELETE from Product WHERE ProductId = @id", new { id });
            }
        }

        public void UpdateProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("UPDATE product SET name = @name WHERE id = @id", new { name = prod.Name, id = prod.Id });
            }
        }

        public void InsertProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("INSERT into product (name) VALUES (@name)", new {name = prod.Name });
            }
        }

        public IEnumerable<Product> GetProductsWithReview()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<Product>("SELECT product.ProductId AS Id, Name, Comments AS Review"
                                           + " FROM product"
                                           + " INNER JOIN productReview"
                                           + " ON product.ProductId = productReview.ProductId;");
            }
        }

        public IEnumerable<Product> GetProductsAndReview()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<Product>("SELECT product.ProductId AS Id, Name, Comments AS Review"
                                           + " FROM product"
                                           + " LEFT JOIN productReview"
                                           + " ON product.ProductId = productReview.ProductId;");
            }
        }
    }
}
