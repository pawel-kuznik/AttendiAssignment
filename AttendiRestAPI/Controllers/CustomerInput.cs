
namespace AttendiRestAPI.Controllers
{
    /**
     *  A small class to describe possible input for a POST /customer endpoint.
     *  It's useful to declare it as a separete object from the Customer cause
     *  it will be automatically integrated into API requirements checking mechanism.
     *  In this example: we can't pass apiKey and the id param is optional and 
     *  the name is required.
     */
    public class CustomerInput
    {
        public string? id { get; set; }
        public string name {  get; set; }
    }
}
