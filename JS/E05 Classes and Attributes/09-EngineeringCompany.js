function engineerCars(array){

    let brandsMap = new Map();

    let modelsMap = new Map();
    
    for(let i = 0; i < array.length; i++){

        let info = array[i].split(' | ');
        let brand = info[0];
        let model = info[1];
        let producedCars = Number(info[2]);

        if(!brandsMap.has(brand)){

            //stores information before setting it to the map
            modelsMap.set(model, producedCars);
            
            //copy the data to another map so it won`t be deleted after
            let addModelsToBrand = new Map(modelsMap); 
            
            //save the data
            brandsMap.set(brand, addModelsToBrand);

            //clear so it is ready to store entirely new data without deleting 
            //the one saved before 
            modelsMap.clear();

        }else{

            //get the value which is another map
            let models = brandsMap.get(brand);

            //check if the value-map contains the given model
            if(!models.get(model)){
                models.set(model, producedCars)
            }else{
                //increase the number of the same model
                let currentlyProduced = models.get(model);
                currentlyProduced += producedCars;
                models.set(model, currentlyProduced);
            }
        }
    }

    for(let [key, value] of brandsMap){

        console.log(key);
        for(let [key2, value2] of value){
            console.log(`###${key2} -> ${value2}`);
        }
    }
}

engineerCars(['Mercedes-Benz | 50PS | 123',
   ' Mini | Clubman | 20000',
    'Mini | Convertible | 1000',
   ' Mercedes-Benz | 60PS | 3000',
    'Hyunday | Elantra GT | 20000',
   ' Mini | Countryman | 100',
    'Mercedes-Benz | W210 | 100',
   ' Mini | Clubman | 1000',
   ' Mercedes-Benz | W163 | 200']);