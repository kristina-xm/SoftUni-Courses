function flavors(array){

    let map = new Map();

    let bottles = new Map();

    for(let i = 0; i < array.length; i++){

        let kvp = array[i].split(' => ');
        
        let flavor = kvp[0];
        let quantity = Number(kvp[1]);

        if(!map.has(flavor)){
             
            map.set(flavor, quantity);
             
            if(map.get(flavor) >= 1000){
                
                let numOfBottles = Math.floor(quantity / 1000);

                bottles.set(flavor, numOfBottles);
            }
        }else{

            let currValue = map.get(flavor);
            currValue += quantity;
         
            map.set(flavor, currValue);

            if(map.get(flavor) >= 1000){
                
                let numOfBottles = Math.floor(currValue / 1000);

                bottles.set(flavor, numOfBottles);
            }
        }
    }

    for(let [key, value] of bottles){

        console.log(`${key} => ${value}`);
    }
}

flavors(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']
)