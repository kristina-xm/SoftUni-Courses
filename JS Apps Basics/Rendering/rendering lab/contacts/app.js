import { html, nothing, render  } from '../node_modules/lit-html/lit-html.js';
import { contacts as data } from '../contacts/contacts.js';

const contacts = data.map(c => Object.assign({}, c, { active: false }));

const root = document.getElementById('contacts');

const contactCard = (contact) => html`<div class="contact card">
            <div>
                <i class="far fa-user-circle gravatar"></i>
            </div>
            <div class="info">
                <h2>Name: ${contact.name}</h2>
                <button  id=${contact.id} class="detailsBtn">Details</button>
                
                ${contact.active ? html`<div class="details">
                <p>Phone number: ${contact.phoneNumber}</p>
                <p>Email: ${contact.email}</p>
            </div>` : nothing}
                
            </div>
    </div>`;
    
root.addEventListener('click', toggleDetails);

render(contacts.map(contactCard), root);

function toggleDetails(event) {

    if (event.target.classList.contains('detailsBtn')) {

        const idBtn = event.target.id;
        const contact = contacts.find(c => c.id == idBtn);
        
        //with edit in the style.css file!!! Last lines
        contact.active = !contact.active;

        render(contacts.map(contactCard), root);
    }
}


/*
        const parent = event.target.parentElement;
        const details = parent.querySelector('.details');

        if(details.style.display == 'block'){

            details.style.display = 'none';
        }else{
            details.style.display = 'block';
        }
        */
