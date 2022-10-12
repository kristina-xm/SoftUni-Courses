class List{

    constructor(arr = []){
        this.arr = arr.sort((a, b) =>  a - b);
        this.size = this.arr.length;
    }

    add(element) { 
        this.arr.push(element); 
        this.arr.sort((a, b) =>  a - b);
        this.size++;
        return;
    }

    remove(index){
        
        if(index < 0 || index >= this.arr.length){
            throw new Error('Index out of the array');
        }
        
        this.arr.splice(index, 1);
        this.size--;
        return;
    }

    get(index){ 
        if(index < 0 || index >= this.arr.length){
            throw new Error('Index out of the array');
        }
        return this.arr[index];
    }
}



