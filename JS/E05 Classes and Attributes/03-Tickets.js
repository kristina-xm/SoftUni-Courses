function sortTickets(array, criterion){

    let objArr = [];

    class Ticket{

        constructor(destination, price, status){
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    for(let i = 0; i < array.length; i++){

        let info = array[i].split('|');

        const ticket = new Ticket(info[0], info[1], info[2]);

        objArr.push(ticket);

    }

    let sorted;
    if (criterion === "destination") {
      sorted = objArr.sort((curr, next) =>
        curr.destination.localeCompare(next.destination)
      );
    } else if (criterion === "price") {
      sorted = objArr.sort((curr, next) => curr.price - next.price);
    } else {
      sorted = objArr.sort((curr, next) =>
        curr.status.localeCompare(next.status)
      );
    }
    
    return sorted;
}

console.log(sortTickets(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
));