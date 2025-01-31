using CompanyApp.DAL.Data;
using CompanyApp.DAL.Repositories;
using CompanyApp.Domain.Entities;

namespace CompanyApp.Utilities
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            using (var unitOfWork = new UnitOfWork(new ApplicationDbContext()))
            {
                // Example operation - Adding a new customer
                var newCustomer = new Customer { Name = "John Doe", Email = "john@doe.com" };
                unitOfWork.Customers.AddAsync(newCustomer);

                await unitOfWork.CommitAsync(); // Commit transaction
            }
        }
    }
}
