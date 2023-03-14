using SampleOData.Models;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SampleOData.Repo
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly SampleApiContext _context;

        public CustomerRepo(SampleApiContext context)
        {
            _context = context;
        }

        public IQueryable<Customer> GetAll()
        {
            return _context.Customers
            //.Include(a => a.Products)
              .AsQueryable();
        }

        public IQueryable<Customer> GetById(int id)
        {
            return _context.Customers
                //.Include(a => a.Products)
                .AsQueryable()
                .Where(c => c.Id == id);
        }

        public void Create(Customer customer)
        {
            _context.Customers
                .Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Customers
                .Update(customer);
            _context.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _context.Customers
                .Remove(customer);
            _context.SaveChanges();
        }
    }
}