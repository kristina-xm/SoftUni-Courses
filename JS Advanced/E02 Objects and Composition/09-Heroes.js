function solve() {

    let obj = {
        mage,
        fighter
    }
    return obj;

    function mage(inputName) {
        
        let mage = {
            'name': inputName,
            'health': 100,
            'mana': 100,
            cast
        }

        function cast(spell) {
            mage.mana--;
            console.log(`${mage.name} cast ${spell}`);
        }
        return mage;
    }

    function fighter(inputName){
        let fighter = {
            'name': inputName,
            'health': 100,
            'stamina': 100,
            fight
        }
    
        function fight() {
            fighter.stamina--;
            console.log(`${fighter.name} slashes at the foe!`);
        }
        return fighter
    }
}

let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);
