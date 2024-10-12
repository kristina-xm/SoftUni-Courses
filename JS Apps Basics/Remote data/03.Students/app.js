let table = document.getElementsByTagName('tbody')[0];

let submitBtn = document.getElementById('submit');
//submitBtn.addEventListener('click', loadStudents);
submitBtn.addEventListener('click', loadCreatedStudents);

async function loadCreatedStudents(e) {

    e.preventDefault();

    let firstNameInput = document.querySelector('[name="firstName"]');
    //firstNameInput.setAttribute('required', '');

    let lastNameInput = document.querySelector('[name="lastName"]');
    //lastNameInput.setAttribute('required', '');

    let facultyInput = document.querySelector('[name="facultyNumber"]');
    //facultyInput.setAttribute('required', '');

    let gradeInput = document.querySelector('[name="grade"]');
    //gradeInput.setAttribute('required', '');
    
    if (firstNameInput.value === '' || lastNameInput.value === '' || facultyInput.value === '' || gradeInput.value == '') {

        alert('Fill the fields!');
        
    } else {

        await postStudents(firstNameInput.value, lastNameInput.value, facultyInput.value, gradeInput.value);

        firstNameInput.value = ' ';
        lastNameInput.value = ' ';
        facultyInput.value = ' ';
        gradeInput.value = ' ';

        await loadStudents();

    }


}

async function loadStudents() {

    table.innerHTML = '';
    let students = await getStudents();


    for (let s of students) {

        let tr = document.createElement('tr');
        let arrInfo = [];
        arrInfo.push(s.firstName);
        arrInfo.push(s.lastName);
        arrInfo.push(s.facultyNumber);
        arrInfo.push(s.grade);

        for (let i = 0; i < 4; i++) {
            let td = document.createElement('td');
            td.textContent = arrInfo[i];
            tr.appendChild(td);
        }
        table.appendChild(tr);
    }
}


async function getStudents() {

    const response = await fetch("http://localhost:3030/jsonstore/collections/students");
    const data = await response.json();

    return Object.values(data);

}

async function postStudents(firstN, lastN, factNum, grade) {

    let obj = {
        'firstName': firstN,
        'lastName': lastN,
        'facultyNumber': factNum,
        'grade': grade
    }

    const response = await fetch("http://localhost:3030/jsonstore/collections/students", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(obj)
    });

     const data = await response.json();
    return data;

}