function attachEvents() {
    
    
  
    document.getElementById('btnLoad').addEventListener('click', loadPhoneBook);
    document.getElementById('btnCreate').addEventListener('click', postNewRecord);

}

async function loadPhoneBook(){ 

    let ul = document.getElementById('phonebook');

    ul.innerHTML = '';

    let phones = await getPhones();
   
    for(let phone of phones){

        let li = document.createElement('li');

        let deleteBtn = createButton();
        deleteBtn.addEventListener('click', deleteRecording);
        deleteBtn.id = phone._id;
        let span = document.createElement('span');
        span.textContent = `${phone.person}: ${phone.phone}`;
        li.appendChild(span);
        li.appendChild(deleteBtn);
        ul.appendChild(li);
       
    }
}

async function deleteRecording(event){

    // let parent = event.target.parentElement;
    // let info = parent.firstChild.textContent.split(': ');

    event.target.parentElement.remove();
    await deletePhone(`http://localhost:3030/jsonstore/phonebook/${event.target.id}`);
}


async function postNewRecord(){

    let personField = document.getElementById('person');
    let phoneField = document.getElementById('phone');

    await postPhone(personField.value, phoneField.value);

    personField.value = '';
    phoneField.value = '';

    await loadPhoneBook();
}

function createButton(){
    
    let deleteBtn = document.createElement('button');
    deleteBtn.innerHTML = "Delete";
  
    deleteBtn.style.display = 'inline-block';
    

    return deleteBtn;
}

async function getPhones(){

    const response = await fetch("http://localhost:3030/jsonstore/phonebook");
    const data = await response.json();

    return Object.values(data);

}

async function deletePhone(url){
    
    const response = await fetch(url, {
        method: 'DELETE',
        headers: {
            'Content-type': 'application/json'
        }
    });

    const data = await response.json;

    return data;
}

async function postPhone(user, phone){
    
    let obj = {
        'person': user,
        'phone': phone
    }

    const response = await fetch("http://localhost:3030/jsonstore/phonebook", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(obj)
    });

    // const data = await response.json();
    // return data;
}

attachEvents();