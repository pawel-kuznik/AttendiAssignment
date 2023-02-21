using System.Security.Cryptography;
using System.Text;

namespace AttendiRestAPI.DataModel
{
    /**
     *  This is a class that represents the data root for the whole application.
     *  The requirements didn't mention anything about any database or any other
     *  storage solution, so the root stores the data in memory. However, if needed
     *  it would be quire easy to reimplement it to use a database or store the data
     *  to disk.
     */
    public class DataRoot
    {
        static private DataRoot _instance = null;

        static public DataRoot Instance
        {
            get
            {
                if (_instance == null) { _instance = new DataRoot(); }

                return _instance;
            }
        }

        static public DataRoot instance() { return new DataRoot(); }

        private List<Customer> _customers = new List<Customer>();

        /**
         *  A helper function for the DataRoot to create hashes when needed. It works
         *  on a simple premise of mashing an id and a name strings together, salting
         *  it and then using SHA256 to has it into a string.
         */
        static private string Hash(string id, string name, string salt = "SuperSecretSalt")
        {
            using (HashAlgorithm alg = SHA256.Create()) {

                byte[] inputInBytes = Encoding.UTF8.GetBytes(salt + id + salt + name + salt);

                byte[] outputInBytes = alg.ComputeHash(inputInBytes);

                StringBuilder stingBuilder = new StringBuilder();
                
                foreach(byte b in outputInBytes)
                {
                    stingBuilder.Append(b.ToString("X2"));
                }

                return stingBuilder.ToString();
            }
        }

        public Customer CreateCustomer(string name)
        {
            string uuidString = Guid.NewGuid().ToString();

            Customer customer = new Customer(uuidString, name, Hash(uuidString, name));
            _customers.Add(customer);

            return customer;
        }

        public Customer GetCustomer(string id)
        {
            foreach(Customer customer in _customers) {

                if (customer.id == id) return customer;
            }

            // if we don't have a customer at this point, we need to throw
            throw new Exception("Customer not found");
        }

        public List<Customer> GetCustomers()
        {
            return new List<Customer>(this._customers);
        }
    }
}
