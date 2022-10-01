function magicMatrix(matrix) {

    const reducer = (accumolator,currentValue) => accumolator + currentValue;

    let rowSums = [];
    let colSums = [];
    
    for(let i = 0; i < matrix.length; i++){

        const currRow = matrix[i];
        let sum = currRow.reduce(reducer);
        rowSums.push(sum);
    }

    for(let i = 0; i < matrix.length; i++){

        const currCol = matrix.map(function (value, index) { return value[i]; });
        let sum = currCol.reduce(reducer);
        colSums.push(sum);
    }
 
    let isEqual = true;

    for(let i = 0; i < rowSums.length; i++){

        for(let j = 0; j < colSums.length; j++){

            if(rowSums[i] === colSums[j]){
                isEqual = true;
            }else{
                isEqual = false;
                break;
            }
        }
        break;
    }

    if(isEqual){
        console.log(`true`);
    }else{
        console.log(`false`)
    }
}


   magicMatrix([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 4]]
   
   )
     