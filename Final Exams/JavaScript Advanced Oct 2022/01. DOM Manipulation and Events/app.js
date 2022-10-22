window.addEventListener("load", solve);

function solve() {
  
  const publishBtn = document.getElementById('form-btn');

  const mainSection = document.getElementById('main');

  const inputFirstName = document.querySelector('#first-name');
  const inputLastName = document.querySelector('#last-name');
  const inputAge = document.querySelector('#age');
  const inputTitle = document.querySelector('#story-title');
  const inputGenre = document.querySelector('#genre');
  const inputStory = document.querySelector('#story');


  publishBtn.addEventListener('click', (ev) =>{
    ev.preventDefault();
    
    if(inputFirstName.value !== '' &&
    inputLastName.value !== '' &&
    inputAge.value !== '' &&
    inputTitle.value !== '' &&
    inputGenre.value !== '' &&
    inputStory.value !== ''){

      addStory(
        ev,
        inputFirstName.value,
        inputLastName.value,
        inputAge.value,
        inputTitle.value,
        inputGenre.value,
        inputStory.value
      );
      clearInputFileds();
    }
  });


  function addStory(
    ev,
    firstName,
    lastName,
    age,
    title,
    genre,
    story
  ){

    const ul = document.querySelector('#preview-list');

    let fullName = `${firstName} ${lastName}`;
    ev.target.disabled = true;

    const li = elGenerator('li');
    li.setAttribute('class', 'story-info');

    const article = elGenerator('article');

    const heading = elGenerator('h4', `Name: ${fullName}`, article);
    const _age = elGenerator('p', `Age: ${age}`, article);
    const _title = elGenerator('p', `Title: ${title}`, article);
    const _genre = elGenerator('p', `Genre: ${genre}`, article);
    const _story = elGenerator('p', story, article);

    const saveBtn = elGenerator('button', 'Save Story');
    saveBtn.setAttribute('class', 'save-btn');
    const editBtn = elGenerator('button', 'Edit Story');
    editBtn.setAttribute('class', 'edit-btn');
    const deleteBtn = elGenerator('button', 'Delete Story');
    deleteBtn.setAttribute('class', 'delete-btn');

    li.appendChild(article);
    li.appendChild(saveBtn);
    li.appendChild(editBtn);
    li.appendChild(deleteBtn);
    ul.appendChild(li);

    editBtn.addEventListener('click', (ev) =>
    editStory(
      ev,
      firstName,
      lastName,
      age,
      title,
      genre,
      story
    ));

    saveBtn.addEventListener('click', () =>{
      saveStory(
        mainSection
      )
    });

    deleteBtn.addEventListener('click', (ev) =>{
      deleteStory(ev)
    });

  }

  function deleteStory(event){
    event.target.parentNode.remove();
    publishBtn.disabled = false;
  }

  function saveStory(mainElement){

    let childrenOfMainElement = Array.from(mainElement.children);

    mainElement.removeChild(childrenOfMainElement[0]);
    mainElement.removeChild(childrenOfMainElement[1]);

    let h1 = elGenerator('h1', 'Your scary story is saved!');
    mainElement.appendChild(h1);
  }

  function editStory(
    ev,
    _inputFirstName,
    _inputLastName,
    _inputAge,
    _inputTitle,
    _inputGenre,
    _inputStory
  ){
    ev.target.parentNode.remove();
    publishBtn.disabled = false;

    inputFirstName.value = _inputFirstName;
    inputLastName.value = _inputLastName;
    inputAge.value = _inputAge;
    inputTitle.value = _inputTitle;
    inputGenre.value = _inputGenre;
    inputStory.value = _inputStory;
  }
  
  function clearInputFileds() {
    inputFirstName.value = "";
    inputLastName.value = "";
    inputAge.value = "";
    inputTitle.value = "";
    inputGenre.value = "";
    inputStory.value = "";
  }
  
  function elGenerator(tag, content, parent){

    let el = document.createElement(tag);
    if(content){
        el.textContent = content;
    }
    if(parent){
      parent.appendChild(el);
    }

    return el;
  }
}
