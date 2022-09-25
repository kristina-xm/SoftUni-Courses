function parser(input){

    let arrObj = [];

    for(let i = 1; i < input.length; i++){

        let info = input[i]
        .split("|")
        .filter(x => x !== "");

        let [town, latitude, longitude] = info;
        
        let currObj = {};

        currObj["Town"] = town.trim();
        currObj["Latitude"] = Number(Number(latitude).toFixed(2));
        currObj["Longitude"] = Number(Number(longitude).toFixed(2));

        arrObj.push(currObj);

    }

    console.log(JSON.stringify(arrObj));

}

parser(['| Town | Latitude | Longitude |',
'| Veliko Turnovo | 43.0757 | 25.6172 |',
'| Monatevideo | 34.50 | 56.11 |']
);