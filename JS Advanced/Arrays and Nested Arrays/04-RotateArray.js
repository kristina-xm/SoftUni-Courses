function rotateArray(array, num){

      for(let i = 0; i < num; i++){

        let element = array.pop();
        array.unshift(element);
      }

      console.log(array.join(' '));
}

rotateArray(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15

)