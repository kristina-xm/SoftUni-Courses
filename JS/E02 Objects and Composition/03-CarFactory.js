function carFactory(input){

    let infoPower = input.power;

    let smallEngine = { 'power': 90, 'volume': 1800 };
    let normalEngine = { 'power': 120, 'volume': 2400 };
    let monsterEngine = { 'power': 200, 'volume': 3500 };

    if(infoPower <= 90){
        
        input['engine'] = smallEngine;
    }else if(infoPower > 90 && infoPower <= 120){
        
        input['engine'] = normalEngine;

    }else if(infoPower > 120 && infoPower < 200){
        
        input['engine'] = normalEngine;

    }else if(infoPower >= 200){
        input['engine'] = monsterEngine;
    }

    delete input.power;

    let hatchback = {type: 'hatchback'}
    let coupe = { type: 'coupe'}

    if(input.carriage === 'hatchback'){

        hatchback['color'] = input.color;
        input['carriage'] = hatchback;

    }else if(input.carriage === 'coupe'){
        coupe['color'] = input.color;
        input['carriage'] = coupe;
    }

    delete input.color;

    let wheels = [];

    if(input.wheelsize % 2 === 0){
      let newSize = input.wheelsize - 1;

        for(let i = 0; i < 4; i++){
            wheels.push(newSize);
        }
        
        input['wheels'] = wheels;
    }
    else{

        for(let i = 0; i < 4; i++){
            wheels.push(input.wheelsize);
        }
       
        input['wheels'] = wheels;
    }
    delete input.wheelsize;

    return input;
}


console.log(carFactory({
    model: 'Ferrari',
    power: 200,
    color: 'red',
    carriage: 'coupe',
    wheelsize: 18
}
))