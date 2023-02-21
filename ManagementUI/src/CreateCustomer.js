class CreateCustomer extends HTMLElement {

    constructor() {
        super();

        const dom = this.attachShadow({ mode: 'open' });

        const form = document.createElement('form');

        const nameInput = document.createElement('input');
        nameInput.placeholder = 'Enter name for a new customer';
        nameInput.type = 'text';
        form.append(nameInput);

        const button = document.createElement('button');
        button.textContent = 'Create';
        form.append(button);

        dom.append(form);

        form.addEventListener('submit', e => {

            e.preventDefault();

            Data.instance.createCustomer(nameInput.value);
        });
    }
}

customElements.define("attendi-createcustomer", CreateCustomer);