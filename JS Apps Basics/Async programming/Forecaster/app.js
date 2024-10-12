const enumIcon = {
    'Sunny': '&#x2600',
    'Partly sunny': '&#x26C5',
    'Overcast': '&#x2601',
    'Rain': '&#x2614',
    'Degrees': '&#176'

}

function attachEvents() {
    
    document.getElementById('submit').addEventListener('click', getWeather);
}

async function getWeather(){

    try{

        const response = await fetch('http://localhost:3030/jsonstore/forecaster/locations');
    
        const data = await response.json();
        
        const townName = document.getElementById('location').value;
        const info = data.find(x => x.name === townName);
    
        createForecaster(info.code);
    }catch{
        
        const forecastEl = document.getElementById('forecast');
        forecastEl.style.display = 'block';

        forecastEl.removeChild(document.getElementById('upcoming'));

        document.getElementById('current').textContent = "Error";
    }
   
}

async function createForecaster(code){

    const urlToday = `http://localhost:3030/jsonstore/forecaster/today/${code}`;
    const responseToday = await fetch(urlToday);
    const dataToday = await responseToday.json();

    const urlUpcomig = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;
    const responseUpcoming = await fetch(urlUpcomig);
    const dataUpcoming = await responseUpcoming.json();

    createToday(dataToday);
    createUpcoming(dataUpcoming);
};

function createToday(data){

    const forecastEl = document.getElementById('forecast');
    forecastEl.style.display = 'block';
    const current = document.getElementById('current');
    
    const {condition, high, low} = data.forecast; 
    
    const weatherContainer = createElements('div', 'forecasts');

    const conditionSymbol = createElements('span', 'symbol');
    conditionSymbol.innerHTML = enumIcon[data.forecast.condition];
    weatherContainer.appendChild(conditionSymbol);

    const conditionInfo = createElements('span', 'condition');

    //city
    const conditionCity = createElements('span', 'forecast-data');
    conditionCity.textContent = data.name;

    //degree
    const conditionDegree = createElements('span', 'forecast-data');
    conditionDegree.innerHTML = `${low}${enumIcon["Degrees"]}/${high}${enumIcon["Degrees"]}`;
    
    //weather type
    const conditionWeather = createElements('span', 'forecast-data');
    conditionWeather.textContent = condition;

    conditionInfo.appendChild(conditionCity);
    conditionInfo.appendChild(conditionDegree);
    conditionInfo.appendChild(conditionWeather);

    weatherContainer.appendChild(conditionInfo);

    current.appendChild(weatherContainer);

  
}

function createUpcoming(data){
    
    const upcoming = document.getElementById('upcoming');

    const forecastInformation = createElements('div', 'forecast-info');


    for(let i = 0; i < data.forecast.length; i++){
        
        const currUpcoming = createElements('span', 'upcoming');

        const currSymbol = createElements('span', 'symbol');
        currSymbol.innerHTML = enumIcon[data.forecast[i]['condition']];

        const currDegrees = createElements('span', 'forecast-data');
        currDegrees.innerHTML = `${data.forecast[i]["low"]}${enumIcon["Degrees"]}/${data.forecast[i]['high']}${enumIcon["Degrees"]}`;

        const currWeatherType = createElements('span', 'forecast-data');
        currWeatherType.textContent = data.forecast[i]['condition'];

        currUpcoming.appendChild(currSymbol);
        currUpcoming.appendChild(currDegrees);
        currUpcoming.appendChild(currWeatherType);

        forecastInformation.appendChild(currUpcoming);
    }

    upcoming.appendChild(forecastInformation);
 
}

function createElements(tagName, classProperty){

    let el = document.createElement(tagName);
    el.classList.add(classProperty);

    return el;

}

attachEvents();