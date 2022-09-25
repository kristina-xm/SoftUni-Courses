function storeCatalogue(input) {

    let products = [];

    for (let i = 0; i < input.length; i++) {

        let [product, price] = input[i].split(" : ");

        let object = {};

        object['name'] = product;
        object['price'] = price;

        products.push(object);
    }

    function sortArray(a, b) {
        if (a.name < b.name) { return -1; }
        if (a.name > b.name) { return 1; }
        return 0;
    }

    products.sort(sortArray);

    let counterForWords = 0;

    for (let i = 0; i < products.length; i++) {

        let letter = products[i]['name'][0];

        let res = products.filter(x => x['name'][0] === letter);

        console.log(letter);

        res.forEach(function (product) {
            console.log(`  ${product.name}: ${product.price}`);
        });

        i += res.length - 1;
    }

}

storeCatalogue(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']);