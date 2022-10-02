function solve() {
  let text = document.getElementById('text').value;
  let convention = document.getElementById('naming-convention').value;
  let textArray = text.split(' ');

  let res = '';

  if (convention === 'Camel Case') {
    textArray.forEach((e, i) => {
      if (i === 0) {
        return res += e.toLowerCase();
      }
      return res += e[0].toUpperCase() + e.substring(1).toLowerCase();

    })
  } else if (convention === 'Pascal Case') {

    textArray.forEach((e, i) =>{
        e = e.toLowerCase();
        res += e[0].toUpperCase() + e.substring(1);
    })
  }else{
    res = 'Error!';
  }

  document.getElementById('result').textContent = res;
}