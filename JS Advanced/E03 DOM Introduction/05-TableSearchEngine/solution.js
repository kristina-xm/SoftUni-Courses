function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {

      let input = document.getElementById('searchField').value;

      let tableRows = document.getElementsByTagName('tbody')[0];

      let tableData = Array.from(tableRows.children);

      for (let data of tableData) {

         let arrData = Array.from(data.children);

         for (let values of arrData) {

            if (values.textContent.includes(input)) {
               data.classList.add('select');
               break;
            } else {
               data.classList.remove('select');
            }
         }
      }

      document.getElementById('searchField').value = '';
   }
}