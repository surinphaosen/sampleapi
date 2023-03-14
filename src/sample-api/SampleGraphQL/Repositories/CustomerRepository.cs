using SampleGraphQL.Interfaces;
using SampleGraphQL.Models;

namespace SampleGraphQL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SampleApiContext _context;

        public CustomerRepository(SampleApiContext context)
        {
            _context = context;
        }
    }
}