using System;
using System.Linq;
using SqlIntro;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=localhost;Database=adventureworks;Uid=root;Pwd=password;";
            var dapperRepo = new DapperProductRepository(connectionString);
            var repo = new ProductRepository(connectionString);

            var newItem = new Product() { Name = "testProduct" };
            var updateItem = new Product() { Name = "updatedTestProduct" };

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
            Console.WriteLine("Press Enter to Add a new Product");
            Console.ReadKey();
            repo.InsertProduct(newItem);
            var newestId = repo.GetNewestId().Last().Id;
            Console.WriteLine($"\nNew Item Added\nID: {newestId}\nName: {newItem.Name}");
            WaitForEnterKey();

            //UpdateProduct
            updateItem.Id = newestId;
            Console.WriteLine("Press Enter to Update the new Product");
            Console.ReadKey();
            repo.UpdateProduct(updateItem);
            Console.WriteLine($"\nItem Updated\nID: {newestId}\nName: {updateItem.Name}");
            WaitForEnterKey();

            //DeleteProduct
            Console.WriteLine("Press Enter to Delete the new Product");
            Console.ReadKey();
            repo.DeleteProduct(updateItem.Id);
            Console.WriteLine($"\nItem with ID: {newestId} Deleted");
            WaitForEnterKey();



            //InsertProduct with Dapper
            Console.WriteLine("Press Enter to Add a new Product with Dapper");
            Console.ReadKey();
            dapperRepo.InsertProduct(newItem);
            newestId = dapperRepo.GetNewestId().Last().Id;
            Console.WriteLine($"\nNew Item Added\nID: {newestId}\nName: {newItem.Name}");
            WaitForEnterKey();

            //UpdateProduct with Dapper
            updateItem.Id = dapperRepo.GetNewestId().Last().Id;
            Console.WriteLine("Press Enter to Update the new Product with Dapper");
            Console.ReadKey();
            dapperRepo.UpdateProduct(updateItem);
            Console.WriteLine($"\nItem Updated\nID: {newestId}\nName: {updateItem.Name}");
            WaitForEnterKey();

            //DeleteProduct with Dapper
            Console.WriteLine("Press Enter to Delete the new Product with Dapper");
            Console.ReadKey();
            dapperRepo.DeleteProduct(updateItem.Id);
            Console.WriteLine($"\nItem with ID: {newestId} Deleted");
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
