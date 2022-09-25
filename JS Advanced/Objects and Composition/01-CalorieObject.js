function objectsMaker(input) {

    let caloriesObject = {};

    for (let i = 0; i < input.length; i+=2) {

        caloriesObject[input[i]] = Number(input[i + 1]);

    }

    console.log(caloriesObject);
}

objectsMaker(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);

objectsMaker(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);