using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SqlIntro
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Reads all the products from the products table
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ProductId AS Id, Name FROM product";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    yield return new Product { Name = dr["Name"].ToString() };
                }
            }
        }

        /// <summary>
        /// Deletes a Product from the database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(int id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM product WHERE productId = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Updates the Product in the database
        /// </summary>
        /// <param name="prod"></param>
        public void UpdateProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE product SET name = @name WHERE productId = @id";
                cmd.Parameters.AddWithValue("@name", prod.Name);
                cmd.Parameters.AddWithValue("@id", prod.Id);
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Inserts a new Product into the database
        /// </summary>
        /// <param name="prod"></param>
        public void InsertProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT into product (name) VALUES (@name)";
                cmd.Parameters.AddWithValue("@name", prod.Name);
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Product> GetProductsWithReview()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT product.ProductId AS Id, Name, Comments AS Review"
                                  + " FROM product"
                                  + " INNER JOIN productReview"
                                  + " ON product.ProductId = productReview.ProductId;";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    yield return new Product { Id = (int)(dr["Id"]), Name = dr["Name"].ToString(), Review = dr["Review"].ToString() };
                }
            }
        }

        public IEnumerable<Product> GetProductsAndReview()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT product.ProductId AS Id, Name, Comments AS Review"
                                  + " FROM product"
                                  + " LEFT JOIN productReview"
                                  + " ON product.ProductId = productReview.ProductId;";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    yield return new Product { Id = (int)(dr["Id"]), Name = dr["Name"].ToString(), Review = dr["Review"].ToString() };
                }
            }
        }

        public IEnumerable<Product> GetNewestId()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ProductID AS Id FROM product ORDER BY productId DESC LIMIT 1";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    yield return new Product { Id = (int)dr["Id"] };
                }
            }
        }
    }
}
