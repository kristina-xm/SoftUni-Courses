let loadBtn = document.getElementById('loadBooks');

loadBtn.addEventListener('click', loadBooks);

let tableBody = document.getElementsByTagName('tbody')[0];

let form = document.getElementById('form');


async function loadBooks() {

    tableBody.innerHTML = "";

    let books = await getBooks();

    for (let book of books) {

        let tableRow = document.createElement('tr');

        let arrInfo = [];

        arrInfo.push(book[1].title);
        arrInfo.push(book[1].author);
      

        for (let i = 0; i < 3; i++) {
            let td = document.createElement('td');

            if (i == 2) {
                  //for the last iteration when we need two buttons
                  let editBtn = document.createElement('button');
                  let deleteBtn = document.createElement('button');

                  editBtn.id = book[0];
                  deleteBtn.id = book[0];

                  editBtn.textContent = 'Edit';
                  deleteBtn.textContent = 'Delete';

                  editBtn.addEventListener('click', editFn);
                  deleteBtn.addEventListener('click', deleteFn);
  
                  td.appendChild(editBtn);
                  td.appendChild(deleteBtn);
            } else {
                
                td.textContent = arrInfo[i];
            }

            tableRow.appendChild(td);
        }

        tableBody.appendChild(tableRow);
       
    }
}

function editFn(){

   let el = document.getElementsByTagName('h3')[0];

    el.textContent = 'Edit FORM';

    
    
}

function deleteFn(){

}


async function getBooks() {

    const response = await fetch('http://localhost:3030/jsonstore/collections/books');
    const data = await response.json();

    return Object.entries(data);
}