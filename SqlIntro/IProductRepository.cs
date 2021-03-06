﻿using System.Collections.Generic;

namespace SqlIntro
{
    interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        void DeleteProduct(int id);
        void UpdateProduct(Product prod);
        void InsertProduct(Product prod);
        IEnumerable<Product> GetProductsWithReview();
        IEnumerable<Product> GetProductsAndReview();
        IEnumerable<Product> GetNewestId();
    }
}