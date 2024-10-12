function attachEvents() {


    let btnSubmit = document.getElementById('submit');

    let user = document.getElementsByName('author')[0];
    let message = document.getElementsByName('content')[0];
    let textArea = document.getElementById('messages');

    let obj = {};
   
    btnSubmit.addEventListener('click', async () => {
        await postComment(obj);
        user.value = '';
        message.value = '';
    });

    document.getElementById('refresh').addEventListener('click', async () => {
        const comments = await getComments();

        let arrOfPrintedComments = [];

        for (let comment of comments) {

            let text = `${comment.author}: ${comment.content}`;
            arrOfPrintedComments.push(text);

        }

        textArea.value = arrOfPrintedComments.join('\n');

    });

    async function getComments() {
        const response = await fetch("http://localhost:3030/jsonstore/messenger");
        const data = await response.json();

        return Object.values(data);
    }

    async function postComment() {

        let obj = {
            'author': user.value,
            'content': message.value
        }

        const response = await fetch("http://localhost:3030/jsonstore/messenger", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(obj)
        });

        const data = await response.json();
        return data;

    }
}

attachEvents();
