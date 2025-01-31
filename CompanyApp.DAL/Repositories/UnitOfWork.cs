using CompanyApp.Core.Interfaces;
using CompanyApp.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private CustomerRepository _customerRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICustomerRepository Customers
        {
            get
            {
                return _customerRepository ?? (_customerRepository = new CustomerRepository(_context));
            }
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
