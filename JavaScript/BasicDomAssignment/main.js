'use strict';

document.addEventListener('DOMContentLoaded', () => {
    let usernameInput = document.getElementById('username');
    let passwordInput = document.getElementById('password');
    let button = document.getElementsByTagName('button')[0];
    // let welcomeMessage = document.getElementById('text');

    // click event on button
    button.addEventListener('click', () => {
        let username = usernameInput.value;
        let password = passwordInput.value;
        if (username === 'un1' && password === 'pw1') {
           
            location.href = "index.html";
            // let welcomeMessage = document.getElementById('text');
            // welcomeMessage.innerHTML = `welcome un1`;
            // how we nav to new pages
            // (i.e tells browser to make GET req)
        } else {
            alert('pw or input is bad');
            
        }
    })
})
