using System;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=localhost;Database=adventureworks;Uid=root;Pwd=password;";
            var repo = new DapperProductRepository(connectionString);

            /*
            foreach (var prod in repo.GetProducts())
            {
                Console.WriteLine("Product Name:" + prod.Name);
            }
            */
            foreach (var prod in repo.GetProductsWithReview())
            {
                Console.WriteLine("Product Name:" + prod.Name + "\n\nReview: " + prod.Review + "\n\n");
            }
            Console.ReadLine();
        }
    }
}
