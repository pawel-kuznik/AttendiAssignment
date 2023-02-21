using AttendiRestAPI.DataModel;
using AttendiRestAPI.JSONConverters;
using Microsoft.AspNetCore.Mvc;

namespace AttendiRestAPI.Controllers
{
    /**
     *  This is a controller responsible for exposing a REST API for the customer object.
     *  
     *  The requirements state:
     *  "Use Docker to build and launch a small backend application that consists of
     *  an API interface for creating and updating customers. The input to create or
     *  update a customer should be a name. The response should have an ID, the given
     *  name and a generated API key."
     *  
     *  This requirement is not clear on how the update should function. How the identification
     *  of the target should work? I don't really know. I assumed that when with body an
     *  `id` param is passed it's meant to be an update call and allow for rename of
     *  the object. Is it correct? I don't know.
     */
    [ApiController]
    [Route("[controller]")]
    public class CustomerController
    {
        [HttpGet(Name = "Customer")]
        public ActionResult<CustomerJSON> Get(string id)
        {
            try
            {
                Customer existingCustomer = DataRoot.Instance.GetCustomer(id);
                return new CustomerJSON(existingCustomer);
            }
            
            catch (Exception ex)
            {
                return new NotFoundResult();
            }
        }

        [HttpPost(Name = "Customer")]
        public ActionResult<CustomerJSON> Post([FromBody] CustomerInput input)
        {
            if (input.id == null)
            {
                Customer newCustomer = DataRoot.Instance.CreateCustomer(input.name);
                return new CustomerJSON(newCustomer);
            }

            try
            {
                Customer existingCustomer = DataRoot.Instance.GetCustomer(input.id);
                existingCustomer.Rename(input.name);
                return new CustomerJSON(existingCustomer);
            }

            catch(Exception ex)
            {
                return new NotFoundResult();
            }
        }
    }
}
