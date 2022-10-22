class footballTeam {

    constructor(clubName, country) {
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }

    newAdditions(footballPlayers) {

        for (let i = 0; i < footballPlayers.length; i++) {

            let infoArr = footballPlayers[i].split('/');

            let footballer = {};
            footballer.name = infoArr[0];
            footballer.age = infoArr[1];
            footballer.value = infoArr[2];

            if (this.invitedPlayers.some(x => x.name === infoArr[0])) {

                let res = this.invitedPlayers.filter(p => p.name === infoArr[0])


                if (infoArr[2] > res[0].value) {
                    res[0].value = infoArr[2];
                }

            } else {
                this.invitedPlayers.push(footballer);
            }
        }
        let returnArr = [];

        for(let player of this.invitedPlayers){

            returnArr.push(player.name);
        }
        return `You successfully invite ${returnArr.join(', ')}.`;

    }

    signContract(selectedPlayer){

        let splittedInfo = selectedPlayer.split('/');

        let name = splittedInfo[0];
        let offer = splittedInfo[1];

        let res = this.invitedPlayers.filter(p => p.name === name);

        if(res.length === 0){
            throw Error(`${name} is not invited to the selection list!`);

        }else if(res[0].value > offer){
            let priceDifference = res[0].value - offer;
            throw Error(`The manager's offer is not enough to sign a contract with ${name}, ${priceDifference} million more are needed to sign the contract!`)
        }else{
            res[0].value = 'Bought';
            return `Congratulations! You sign a contract with ${res[0].name} for ${offer} million dollars.`;
        }
    }

    ageLimit(name, age){

        let res = this.invitedPlayers.filter(p => p.name === name);

        if(res.length === 0){
            throw Error(`${name} is not invited to the selection list!`);

        }else if(res[0].age < age){

            let ageDifference = age - res[0].age;
            
            if(ageDifference < 5){

                return `${name} will sign a contract for ${ageDifference} years with ${this.clubName} in ${this.country}!`;
            }else{
                return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
            }
        }else if(res[0].age >= age){
            return `${name} is above age limit!`;
        }
    }

    transferWindowResult(){

        let printArr = [];

        function sortByName(a,b){

            return a.name.localeCompare(b.name);
        }
        let sorted = this.invitedPlayers.sort(sortByName);

        printArr.push("Players list:");

        for(let player of sorted){
            printArr.push(`Player ${player.name}-${player.value}`);
        }

        return printArr.join('\n');

    }

}
let fTeam = new footballTeam("Barcelona", "Spain");
console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
console.log(fTeam.signContract("Kylian Mbappé/240"));
console.log(fTeam.ageLimit("Kylian Mbappé", 30));
console.log(fTeam.transferWindowResult());




