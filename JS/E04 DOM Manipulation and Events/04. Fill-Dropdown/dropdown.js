function addItem() {
    
    let inputField = document.getElementById('newItemText');
    let inputValue = document.getElementById('newItemValue');

    let sectionMenu = document.getElementById('menu');

    let option = document.createElement('option');

    option.setAttribute('value', inputValue.value);
    option.textContent = inputField.value
    
    sectionMenu.appendChild(option);

    inputField.value = '';
    inputValue.value = '';

}