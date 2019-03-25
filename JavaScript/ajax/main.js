'use strict';

// AJAX or Ajax
// asynchronous JS and XML
// a set of tools/techniques to send http requests from
// JS and process the results w/o the browser 
// reloading the page

// the traditional tool for the job is XMLHttpRequest Object

document.addEventListener('DOMContentLoaded', () => {
    let jokeBtn = document.getElementById('jokeBtn');
    let jokePara = document.getElementById('jokePara');
    let jokeBtnFetch = document.getElementById('jokeBtnFetch');

    jokeBtn.addEventListener('click', () => {
        let xhr = new XMLHttpRequest();
        xhr.addEventListener('readystatechange', () => {
            console.log(`ready state: ${xhr.readyState}`);
            if (xhr.readyState === 4) {
                // response is here
                if(xhr.status >= 200 && xhr.status < 300) {
                    // if successful....
                    let text = xhr.responseText;
                    // browser gives us 2 functions
                    // to help with JSON
                    // parse (deserialize)
                    // stringify (serialize)
                    let obj = JSON.parse(text);
                    console.log(obj);
                    let joke = obj.value.joke;
                    jokePara.textContent = joke;
                    console.log("success");
                } else {
                    jokePara.textContent = (xhr.statusText === undefined)
                        ? 'error': xhr.statusText;
                    
                }
            }
        })
        console.log('added listener')
        xhr.open('get', 'https://api.icndb.com/jokes/random?escape=javascript');
        console.log('set up req');
        xhr.send();
        console.log('sent req');
    })

    jokeBtnFetch.addEventListener('click', () => {
        // a promise is an obj which represents
        // some val that we will eventually get or fail to get
        // so a promise can "resolve" to success or failure

        // no pyramid of doom with promises

        // defaults to get
        // console.log(fetch('https://api.icndb.com/jokes/random?escape=javascript'));
        fetch('https://api.icndb.com/jokes/random?escape=javascript')
            .then(response => response.json())
            .then(obj => {
                jokePara.textContent = obj.value.joke;
            })
            .catch(error => console.log(error));
    })
})

// He said JSON.stringify() and JSON.parse() is easy enough for us