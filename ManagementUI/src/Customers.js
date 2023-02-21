class Customers extends HTMLElement {

    _observerCleanup;

    constructor() {

        super();

        const dom = this.attachShadow({ mode: 'open' });
        
        const container = document.createElement('div');
        dom.append(container);
    }

    connectedCallback() {

        const buildList = list => {

            console.trace(list);

            const container = this.shadowRoot.querySelector('div');

            container.innerHTML = '';

            for(let customer of list) {

                const customerEl = document.createElement('attendi-customer');
                customerEl.setAttribute('customerid', customer.id);
                container.append(customerEl);
            }
        };

        Data.instance.getCustomers().then(buildList);

        this._observerCleanup = Data.instance.observe(buildList);
    }
};

customElements.define("attendi-customers", Customers);