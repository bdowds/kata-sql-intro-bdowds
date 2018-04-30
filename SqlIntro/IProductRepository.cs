using System;
using System.Collections.Generic;
using System.Text;

namespace SqlIntro
{
    interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        void DeleteProduct(int id);
        void UpdateProduct(Product prod);
        void InsertProduct(Product prod);
    }
}
