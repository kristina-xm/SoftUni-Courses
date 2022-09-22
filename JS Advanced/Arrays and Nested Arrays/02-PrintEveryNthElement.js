function returnElements(array, step){

    let newArr = [];
    for(let i = 0; i < array.length; i += step){

        newArr.push(array[i]);
    }

    return newArr;

}

console.log(returnElements(['5', 
'20', 
'31', 
'4', 
'20'], 
2
))


returnElements(['dsa',
'asd', 
'test', 
'tset'], 
2
)

returnElements(['1', 
'2',
'3', 
'4', 
'5'], 
6
)