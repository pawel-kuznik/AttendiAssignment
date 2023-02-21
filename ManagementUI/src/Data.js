/**
 *  This is a class that allows access to the data via the REST API.
 *  This class however has an additional functionality: it caches the
 *  responses so they can be shared between different components and
 *  potentially allow different components to get updates when data
 *  changes.
 */
class Data {

    static instance = new Data();

    _observers = new Set();

    constructor() {

        this.reload();
    }

    async getCustomers() {

        return this._promise;
    }

    async getCustomer(id) {

        return this._promise.then(data => {

            for(let customer of data) {
                if (customer.id == id) return customer;
            }

            throw Error("Customer not found");
        });
    }

    async createCustomer(name) {

        return fetch("https://localhost:49157/Customer", {
            method: "POST",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ name })
        }).then(customer => {

            this.reload();
            return customer;
        });
    }

    async renameCustomer(id, name) {

        return this.getCustomer(id).then(customer => {

            if (customer.name == name) return customer;

            return fetch("https://localhost:49157/Customer", {
                method: "POST",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ id, name })
            }).then(customer => {
    
                this.reload();
                return customer;
            });
        });
    }

    async reload() {

        this._promise = fetch("https://localhost:49157/Customers").then(response => response.json()).then(body => {
            
            for(let observer of this._observers) observer(body);

            return body;

        }).then(data => {

            if (data.status) throw Error('API request failed');

            return data;
        });
    }

    observe(callback) {
        this._observers.add(callback);

        return () => {
            this._observers.delete(callback);
        };
    }
};