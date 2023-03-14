using Microsoft.EntityFrameworkCore;
using SampleSoap.Models;
using System.Xml.Linq;

namespace SampleSoap
{
    public class SampleService : ISampleService
    {
        private readonly SampleApiContext _context;

        public SampleService(SampleApiContext context)
        {
            _context = context;
        }

        public string Ping(string s)
        {
            Console.WriteLine("Exec ping method");
            return s;
        }

        public ComplexModelResponse PingComplexModel(ComplexModelInput inputModel)
        {
            Console.WriteLine("Input data. IntProperty: {0}, StringProperty: {1}", inputModel.IntProperty, inputModel.StringProperty);

            return new ComplexModelResponse
            {
                FloatProperty = float.MaxValue / 2,
                StringProperty = inputModel.StringProperty,
                ListProperty = inputModel.ListProperty,
                DateTimeOffsetProperty = inputModel.DateTimeOffsetProperty
            };
        }

        public int[] IntArray()
        {
            return new int[]
            {
                123,
                456,
                789
            };
        }

        public void VoidMethod(out string s)
        {
            s = "Value from server";
        }

        public Task<int> AsyncMethod()
        {
            return Task.Run(() => 42);
        }

        public int? NullableMethod(bool? arg)
        {
            return null;
        }

        public void XmlMethod(XElement xml)
        {
            Console.WriteLine(xml.ToString());
        }

        public ComplexReturnModel[] ComplexReturnModel()
        {
            return new ComplexReturnModel[]
            {
                new ComplexReturnModel
                {
                    Id = 1,
                    Name = "Item 1"
                },
                new ComplexReturnModel
                {
                    Id = 2,
                    Name = "Item 2"
                }
            };
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer? GetCustomer(int id)
        {
            return _context.Customers.SingleOrDefault(x => x.Id == id);
        }

        public Customer CreateCustomer(Customer customer)
        {
            if (customer.Id.HasValue)
            {
                customer.Id = null;
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        public void UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                throw new("Id is invalid.");
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    throw new("Not found.");
                }
                else
                {
                    throw;
                }
            }
        }

        public void DeleteCustomer(int id)
        {
            Customer? customer = _context.Customers.Find(id);
            if (customer == null)
            {
                throw new("Not found.");
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}