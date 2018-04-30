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
                conn.Execute("UPDATE product SET name = @name WHERE id = @id", new { prod.Name, prod.Id });
            }
        }

        public void InsertProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("INSERT into product (name) VALUES (@name)", new { prod.Name });
            }
        }
    }
}
