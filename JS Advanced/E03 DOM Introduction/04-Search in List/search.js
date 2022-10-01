function search() {

let inputValue = document.getElementById('searchText').value;

let list = document.getElementById('towns');

let townsArray = Array.from(list.children);

let counter = 0;

for(let town of townsArray){
   
   if(town.textContent.includes(inputValue)){
     town.style.textDecoration = 'underline';
     town.style.fontWeight = 'bold';

     counter++;
   }else{
      town.style.textDecoration = 'none';
      town.style.fontWeight = 'normal';
   }
}

let resultsFound = document.getElementById('result');
resultsFound.textContent = `${counter} matches found`;
   
}

