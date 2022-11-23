function notify(message) {

      let content = document.getElementById('notification');

      content.innerText = message;

      content.style.display = "block";

      content.addEventListener("click", toggleDisplayStyle)

      function toggleDisplayStyle(event){

        event.target.style.display = "none" 
      }
}