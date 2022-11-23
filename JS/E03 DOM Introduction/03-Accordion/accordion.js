function toggle() {

    let btn = document.getElementsByClassName('button')[0];
    let displayText = document.getElementById('extra');
    
    if(btn.textContent === 'Less'){
        btn.textContent = 'More';
        displayText.style.display = 'none';

    }else if(btn.textContent === 'More'){
        btn.textContent = 'Less';
        displayText.style.display = 'block';
    }
}