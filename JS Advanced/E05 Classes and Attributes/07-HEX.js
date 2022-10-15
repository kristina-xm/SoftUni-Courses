class Hex{

    constructor(value){

        this.value = Number(value);
    }

    valueOf(){
     
        return this.value;
    };

    toString(){
        let hexadecimalValue = this.value.toString(16);
        return `0x${hexadecimalValue.toUpperCase()}`;
    }

    plus(number){

        let newHexObj = new Hex();

        if(typeof number === 'object'){

            newHexObj['value'] = this.value + number.valueOf();
            return newHexObj;

        }else{
            newHexObj = this.value + Number(number);
            return newHexObj;
        }
        
    }

    minus(number){
       
        let newHexObj = new Hex();

        if(typeof number === 'object'){

            newHexObj['value'] = this.value - number.valueOf();
            return newHexObj;

        }else{
            newHexObj = this.value - Number(number);
            return newHexObj;
        }
    }

    parse(string){
        return parseInt(string, 16);
    }
}

