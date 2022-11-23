function sortFunc(array){

    let sortedArray = array.sort((a,b) =>{
        if(a.length !== b.length){
            return a.length - b.length
        }else{
            return a.localeCompare(b);
        }
    })

      console.log(sortedArray.join('\n'));
}

sortFunc(['test', 
'Deny', 
'omen', 
'Default']
)