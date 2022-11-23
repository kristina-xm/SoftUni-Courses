//First input field
let firstField = document.getElementById('firstNumber');

firstField.addEventListener('focus', (event) => {
    firstField.placeholder = "";
});

firstField.addEventListener('blur', (event) => {
    firstField.placeholder = 'Type your first number'
});

//Second input field
let secondField = document.getElementById('secondNumber');

secondField.addEventListener('focus', (event) => {
    secondField.placeholder = "";
});

secondField.addEventListener('blur', (event) => {
    secondField.placeholder = 'Type your second number'
});

//Button logic
let button = document.getElementById('calculationBtn');

function subtract() {

    let firstNum = Number(document.getElementById('firstNumber').value);
    let secondNum = Number(document.getElementById('secondNumber').value);

    let btn = document.getElementById('calculateBtn');
    let result = firstNum - secondNum;

    document.getElementById('result').innerText = result;
    
}




