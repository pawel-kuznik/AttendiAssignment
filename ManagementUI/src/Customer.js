class Customer extends HTMLElement {

    _customer = null;

    constructor() {
        super();

        const dom = this.attachShadow({ mode: 'open' });

        const container = document.createElement('div');

        container.style.padding = ".5em 0";

        const nameInput = document.createElement('input');
        nameInput.type = 'text';

        nameInput.style.display = "block";
        nameInput.style.width = "100%";

        container.append(nameInput);

        const apiKey = document.createElement('code');
        container.append(apiKey);

        dom.append(container);
    }

    connectedCallback() {

        const id = this.getAttribute('customerid');
        const input = this.shadowRoot.querySelector('input');

        input.addEventListener('blur', () => {
            Data.instance.renameCustomer(id, input.value);
        });

        if (id) {
            input.disabled = true;
            input.placeholder = "Loading data...";
        }

        Data.instance.getCustomer(id).then(customer => {
            
            input.placeholder = customer.name;
            input.value = customer.name;
            input.disabled = false;

            const apiKey = this.shadowRoot.querySelector('code');
            apiKey.textContent = `API key: ${customer.apiKey}`;

        }, () => {
            input.placeholder = "Can't load data. An error occured.";
        });
    }
}

customElements.define("attendi-customer", Customer);