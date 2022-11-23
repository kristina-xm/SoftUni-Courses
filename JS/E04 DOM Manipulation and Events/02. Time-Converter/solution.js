function attachEventsListeners() {

        let convertButton = document.querySelectorAll('input[type="button"]');

        let allButtons = Array.from(convertButton);
   

        for(let button of allButtons){

            button.addEventListener('click', convert);
        }

        let inputs = document.querySelectorAll('input[type="text"]');
        let arrOfInputs = Array.from(inputs);
   
        function convert(){

        let valueToConvert = '';
        let idOfValue = '';

        for(let i = 0; i < arrOfInputs.length; i++){

            if(arrOfInputs[i].value !== ''){

                valueToConvert += arrOfInputs[i].value;
                idOfValue = arrOfInputs[i].id;
                arrOfInputs.splice(i, 1);
                break;
            }
        }

        //For the rest of the input fields
        for(let field of arrOfInputs){

            if(idOfValue === 'days'){

                if(field.id === 'hours'){
                    field.value = valueToConvert * 24;
                }else if(field.id === 'minutes'){
                    field.value = valueToConvert * 1440;
                }else if(field.id === 'seconds'){
                    field.value = valueToConvert * 86400;
                }

            }else if(idOfValue === 'hours'){
                
                if(field.id === 'days'){
                    field.value = valueToConvert / 24;
                }else if(field.id === 'minutes'){
                    field.value = valueToConvert * 60;
                }else if(field.id === 'seconds'){
                    field.value = valueToConvert * 3600;
                }

            }else if(idOfValue === 'minutes'){

                if(field.id === 'days'){
                    field.value = valueToConvert / 1440;
                }else if(field.id === 'hours'){
                    field.value = valueToConvert / 60;
                }else if(field.id === 'seconds'){
                    field.value = valueToConvert * 60;
                }

            }else if(idOfValue === 'seconds'){

                if(field.id === 'days'){
                    field.value = valueToConvert / 86400;
                }else if(field.id === 'hours'){
                    field.value = valueToConvert / 3600;
                }else if(field.id === 'minutes'){
                    field.value = valueToConvert / 60;
                }
            }

        }
    }
}