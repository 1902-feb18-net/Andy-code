'use strict';

document.addEventListener('DOMContentLoaded', () => {
    let btn = document.getElementById('submit');
    let input = document.getElementById('input');
    let pokePara = document.getElementById('pokePara');
    let pokePara2 = document.getElementById('pokePara2');
    let pokePara3 = document.getElementById('pokePara3');

    btn.addEventListener('click', () => {
        let userInput = input.value;
        fetch(`https://pokeapi.co/api/v2/pokemon/${userInput}`)
            .then(response => response.json())
            .then(obj => {
                pokePara.textContent = obj.name;
                pokePara2.textContent = obj.species.url;
                pokePara3.textContent = obj.id;
            })
            .catch(error => console.log(error));
    })

});