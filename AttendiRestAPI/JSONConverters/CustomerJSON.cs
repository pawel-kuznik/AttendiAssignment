using AttendiRestAPI.DataModel;

namespace AttendiRestAPI.JSONConverters
{
    /**
     *  This is a special class that allows converting a Customer instance into
     *  a JSON friendly instance that can be exposed via the API.
     */
    public class CustomerJSON
    {
        private Customer _customer;

        public string id
        {
            get { return this._customer.id;  }
        }

        public string name
        {
            get { return this._customer.name; }
        }

        public string apiKey
        {
            get { return this._customer.apiKey; }
        }

        public CustomerJSON(Customer input)
        {
            _customer = input;
        }
    }
}
