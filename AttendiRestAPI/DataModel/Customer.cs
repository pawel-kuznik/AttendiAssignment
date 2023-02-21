namespace AttendiRestAPI.DataModel
{
    /**
     *  This is a class representing a customer inside our data model.
     */
    public class Customer
    {
        public string id { get; }
        public string name { get { return this._name; } }
        public string apiKey { get; }

        private string _name = "";

        public Customer(string id, string name, string apiKey)
        {
            this.id = id;
            this._name = name;
            this.apiKey = apiKey;
        }

        public Boolean Rename(string newName)
        {
            this._name = newName;
            return true;
        }
    }
}
