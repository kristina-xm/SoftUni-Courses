function rectangle(widthInput, heightInput, colorInput){

    let color = capitalizeFirstLetter(colorInput);

    let rect = {
        'width': widthInput,
        'height': heightInput,
        'color': color,
        calcArea
    };

    function calcArea(){
        return this.width * this.height;
    }
    
    function capitalizeFirstLetter(string) {
        return string.charAt(0).toUpperCase() + string.slice(1);
    }

    return rect;
}

let rect = rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);

