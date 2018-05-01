using System;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=localhost;Database=adventureworks;Uid=root;Pwd=password;";
            var dapperRepo = new DapperProductRepository(connectionString);
            var repo = new ProductRepository(connectionString);
            
            var newItem = new Product() { Id = 1000, Name = "testProduct" };
            var updateItem = new Product() { Id = 1000, Name = "updatedTestProduct" };

            //GetProducts
            foreach (var prod in repo.GetProducts())
            {
                Console.WriteLine("Product Name: " + prod.Name);
            }
            WaitForEnterKey();

            //GetProducts with Dapper
            foreach (var prod in dapperRepo.GetProducts())
            {
                Console.WriteLine("Product Name: " + prod.Name);
            }
            WaitForEnterKey();

            //GetProductsWithReview
            foreach (var prod in repo.GetProductsWithReview())
            {
                Console.WriteLine("Product Name: " + prod.Name + "\n\nReview: " + prod.Review + "\n\n");
            }
            WaitForEnterKey();

            //GetProductsWithReview with Dapper
            foreach (var prod in dapperRepo.GetProductsWithReview())
            {
                Console.WriteLine("Product Name: " + prod.Name + "\n\nReview: " + prod.Review + "\n\n");
            }
            WaitForEnterKey();

            //GetProductsAndReview
            foreach (var prod in repo.GetProductsAndReview())
            {
                Console.WriteLine("Product Name: " + prod.Name + "\n\nReview: " + prod.Review + "\n\n");
            }
            WaitForEnterKey();

            //GetProductsAndReview with Dapper
            foreach (var prod in dapperRepo.GetProductsAndReview())
            {
                Console.WriteLine("Product Name: " + prod.Name + "\n\nReview: " + prod.Review + "\n\n");
            }
            WaitForEnterKey();


            //InsertProduct
            repo.DeleteProduct(newItem.Id);
            Console.WriteLine("Press Enter to Add a new Product");
            Console.ReadKey();
            repo.InsertProduct(newItem);
            Console.WriteLine("\nNew Item Added");
            WaitForEnterKey();

            //UpdateProduct
            Console.WriteLine("Press Enter to Update the new Product");
            Console.ReadKey();
            repo.UpdateProduct(updateItem);
            Console.WriteLine("\nItem Updated");
            WaitForEnterKey();

            //DeleteProduct
            Console.WriteLine("Press Enter to Delete the new Product");
            Console.ReadKey();
            repo.DeleteProduct(newItem.Id);
            Console.WriteLine("\nItem Deleted");
            WaitForEnterKey();



            //InsertProduct with Dapper
            dapperRepo.DeleteProduct(newItem.Id);
            Console.WriteLine("Press Enter to Add a new Product with Dapper");
            Console.ReadKey();
            dapperRepo.InsertProduct(newItem);
            Console.WriteLine("\nNew Item Added");
            WaitForEnterKey();

            //UpdateProduct with Dapper
            Console.WriteLine("Press Enter to Update the new Product with Dapper");
            Console.ReadKey();
            dapperRepo.UpdateProduct(updateItem);
            Console.WriteLine("\nItem Updated");
            WaitForEnterKey();

            //DeleteProduct with Dapper
            Console.WriteLine("Press Enter to Delete the new Product with Dapper");
            Console.ReadKey();
            dapperRepo.DeleteProduct(newItem.Id);
            Console.WriteLine("\nItem Deleted");
            WaitForEnterKey();
        }

        public static void WaitForEnterKey()
        {
            Console.WriteLine("\nPress Enter for next statement...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
