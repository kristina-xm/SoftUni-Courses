function encodeAndDecodeMessages() {
    
    let button = document.getElementsByTagName('button')[0];

    button.addEventListener('click', sent)

    function sent(){

        let sentMessage = document.getElementsByTagName('textarea')[0].value;

        let modifiedChars = [];
       
        for(let i = 0; i < sentMessage.length; i++){

            let asciiChar = sentMessage.charCodeAt(i);

            asciiChar++;

            modifiedChars.push(asciiChar);

        }

        document.getElementsByTagName('textarea')[0].value = '';

        let decodedMessageChars = [];

        for(let value of modifiedChars){
            let char = String.fromCharCode(value);
            decodedMessageChars.push(char);
        }

        let decodedMessage = document.getElementsByTagName('textarea')[1];

        decodedMessage.innerText = decodedMessageChars.join('');
        
        let decodingButton = document.getElementsByTagName('button')[1];

        decodingButton.addEventListener('click', decode);
    
        function decode(){
    
            document.getElementsByTagName('textarea')[1].innerText = sentMessage;
        }
    }
}