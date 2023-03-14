using SampleOData.Models;

namespace SampleOData.Repo
{
    public interface ICustomerRepo
    {
        public IQueryable<Customer> GetAll();

        public IQueryable<Customer> GetById(int id);

        public void Create(Customer customer);

        public void Update(Customer customer);

        public void Delete(Customer customer);
    }
}