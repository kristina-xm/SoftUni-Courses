function sortNumbers(numbers){

    numbers.sort((a,b) => a - b);

    let newArr = [];

    let iterations = numbers.length;

    for(let i = 0; i < iterations / 2; i++){

        let smallNum = numbers.shift();
        let bigNum = numbers.pop();
        newArr.push(smallNum);
        newArr.push(bigNum);  
    }

    return newArr;
}


console.log(sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]))