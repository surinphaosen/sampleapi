namespace SampleGraphQL.Models
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Customer> GetCustomers([Service] SampleApiContext context) =>
            context.Customers;
    }
}