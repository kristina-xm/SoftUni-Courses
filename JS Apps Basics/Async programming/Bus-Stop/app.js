async function getInfo() {
    
    const stopInput = document.getElementById('stopId');
    const stopId = stopInput.value;

    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;
    const stopName = document.getElementById('stopName');
    const busUl = document.getElementById('buses');
   
    busUl.innerHTML = "";
    stopInput.value = "";

    try{
        const response = await fetch(url); //wait for result before continuing
        const data = await response.json();
    
       
        stopName.textContent = data.name;
        Object.entries(data.buses).forEach(([bus,time]) => {
            const li = document.createElement('li');
            li.textContent = `Bus ${bus} arrives in ${time} minutes`
            busUl.appendChild(li);
           
        })
    }catch (e){
        stopName.textContent = 'Error';
    }
    
  
}