const { assert } = require("chai");
const {chooseYourCar} = require("../chooseYourCar");

describe('choosingType', () =>{

    it('should retrun an error if year is invalid', () =>{

        assert.throw(() => chooseYourCar.choosingType('Sedan', 'black', 1899), 'Invalid Year!');
        assert.throw(() => chooseYourCar.choosingType('Sedan', 'black', 2023), 'Invalid Year!');
    });

    it('should return proper message when Sedan is chosen', () =>{
        
        assert.equal(
            chooseYourCar.choosingType('Sedan', 'black', 2010), `This black Sedan meets the requirements, that you have.`
        );
        assert.equal(
            chooseYourCar.choosingType('Sedan', 'black', 2012), `This black Sedan meets the requirements, that you have.`
        );

        assert.equal(
            chooseYourCar.choosingType('Sedan', 'black', 2009), `This Sedan is too old for you, especially with that black color.`
        );
        
        
    });

    it('should return proper message when Sedan is not chosen', () =>{
       
        assert.throw(() => chooseYourCar.choosingType('Toyota', 'black', 2009),
        `This type of car is not what you are looking for.`);
        
    })
});

describe ('brandName', () =>{

    it('should return errors when inputs are not correct type', () =>{

        assert.throw(() => chooseYourCar.brandName('not array', '4'), `Invalid Information!`)
        assert.throw(() => chooseYourCar.brandName(['Brand1', 'Brand2'], '1'), `Invalid Information!`)
    });

    it('should return errors when inputs are not correct values', () =>{

        assert.throw(() => chooseYourCar.brandName(['Brand1', 'Brand2'], -1), `Invalid Information!`)
        assert.throw(() => chooseYourCar.brandName(['Brand1', 'Brand2'], 3), `Invalid Information!`)
    });

    it('should return correct string result', () =>{

        assert.equal(
            chooseYourCar.brandName(['BMW', 'Toyota', 'Renault'], 2), 'BMW, Toyota'
        )

        assert.equal(
            chooseYourCar.brandName(['BMW', 'Toyota', 'Renault', 'Peugot'], 2), 'BMW, Toyota, Peugot'
        )
    });

});

describe ('carFuelConsumption', () =>{

    it('should return error if invalid inputs', () =>{

        assert.throw(() => chooseYourCar.carFuelConsumption('45', '67'));
    });

    it('should return error if invalid input values', () =>{

        assert.throw(() => chooseYourCar.carFuelConsumption(0, 0));
        assert.throw(() => chooseYourCar.carFuelConsumption(-1, -45));
    });

    it('should return correct message for liters per km', () =>{

        assert.equal(chooseYourCar.carFuelConsumption(16,256), `The car burns too much fuel - 1600.00 liters!`)
        assert.equal(chooseYourCar.carFuelConsumption(100,7), `The car is efficient enough, it burns 7.00 liters/100 km.`)
        assert.equal(chooseYourCar.carFuelConsumption(100,5), `The car is efficient enough, it burns 5.00 liters/100 km.`)
    });
});