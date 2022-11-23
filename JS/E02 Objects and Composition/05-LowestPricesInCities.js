function lowestPrice(input){

    let productData = {};

    for(i = 0; i < input.length; i ++){

        let [town, product, price] = input[i].split(" | ");

        if(productData[product] === undefined){

            let productInfo = {};
            productInfo["town"] = town;
            productInfo["price"] = Number(price);
    
            productData[product] = productInfo;

        }else{

            if(price < productData[product].price){

                productData[product].price = price;
                productData[product].town = town;
                
            }else if(price === productData[product].price){

               continue;

            }
        }
    }
  
    for (const product in productData){

        console.log(`${product} -> ${productData[product].price} (${productData[product].town})`)
    }
}

lowestPrice(['Sofia City | Audi | 100000',
    'Sofia City | BMW | 100000',
    'Sofia City | Mitsubishi | 10000',
    'Sofia City | Mercedes | 10000',
    'Sofia City | NoOffenseToCarLovers | 0',
    'Mexico City | Audi | 1000',
    'Mexico City | BMW | 99999',
    'Mexico City | Mitsubishi | 10000',
    'New York City | Mitsubishi | 1000',
    'Washington City | Mercedes | 1000']

);
