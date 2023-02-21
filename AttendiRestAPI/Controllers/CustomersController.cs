
using AttendiRestAPI.DataModel;
using AttendiRestAPI.JSONConverters;
using Microsoft.AspNetCore.Mvc;

namespace AttendiRestAPI.Controllers
{
    /**
     *  This is a controller to manage a whole list of customers. 
     *  
     *  @todo A better practice would be to have also ability to create a new
     *  customer via this endpoint.
     */
    [ApiController]
    [Route("[controller]")]
    public class CustomersController
    {
        [HttpGet(Name = "Customers")]
        public CustomerJSON[] Get()
        {
            List<Customer> customers = DataRoot.Instance.GetCustomers();
            List<CustomerJSON> result = new List<CustomerJSON>();

            foreach (Customer customer in customers)
            {
                result.Add(new CustomerJSON(customer));
            }

            return result.ToArray();
        }
    }
}
