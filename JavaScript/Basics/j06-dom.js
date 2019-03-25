'use strict';

// DOM: document object model

// HTML is the serialized format of the DOM

// (function () {
// let textPara = document.getElementById('text');
// console.log(textPara);
// })();

// really the way we do it is register event handlers.

// for right when the page starts...

// "on<events>" properties that we can assign functions to.
// when the event happens, they will run
// this is for the "load" event on the window object
window.onload = () => {
    let textPara = document.getElementById('text');
    console.log(textPara);
    console.log('this runs second')
}

console.log('this runs first');

// we have a better way to register event handlers
// better because it allows more than one at a time

window.addEventListener('load', () => {
    let textPara = document.getElementById('text');
    // change the contents of the element
    textPara.innerHTML = '<em>some text</em>';
})

// "load" event fires pretty late.. after all images and scripts/styles
// have finished downloading

// usually we can use this event instead
document.addEventListener('DOMContentLoaded', () => {
    let textPara = document.getElementById('text');
    textPara.innerHTML += 'text 2';
})

document.addEventListener('DOMContentLoaded', () => {
    let textPara = document.getElementById('text');
    // let button = document.getElementsByTagName('button')[0];
    let input = document.getElementById('input');
    let form = document.getElementById("form0")

    let list = document.getElementById("list");

    let link = document.getElementById("link");
    link.addEventListener('click', event => {
        // default for clicking an a element
        event.preventDefault();
        console.log('clicked link');
    });
    let count = 0;

    // click event on button
    // button.addEventListener('click', () => {
    form.addEventListener('submit', event => {
        // add new event item
        let item = document.createElement('li');
        item.textContent = `${input.value} ${count}`;
        item.style.fontSize = `${2*count}px`;
        list.appendChild(item);
        
        // we can prevent the browser's default 
        // event handlers
        event.preventDefault();
        count++;
        textPara.innerHTML = `text ${count}`;
        if (count === 10 || input.value === 'google'){
            location.href = "http://google.com"
            // how we nav to new pages
            // (i.e tells browser to make GET req)
        }
    });

    // can use CSS selector syntax with this function
    let table = document.querySelector('table');
    let row1 = table.tBodies[0].rows[0]
    let cellA = row1.cells[0];

    row1.addEventListener('click', event => {
        // stop the event from bubbling out any further
        // bad practice
        event.stopPropagation();
        // stops even other event listeners on this
        // same element right here
        event.stopImmediatePropagation();
        printEventDetails(event);
    }, true);
    // cellA.addEventListener('click', event => {
    //     printEventDetails(event);
    // });
    // can run cellA.addEventListener('click', printeEventDetails());
    cellA.addEventListener('click', printEventDetails, true);
    table.addEventListener('click', printEventDetails, true);
    // 3rd param true adds 
});



// in old days, some browsers propagated events in the opposite order
// these days all browsers support both, but
// default to "bubbling mode"

// bubbling mode is event runs FIRST on the most deeply
// nested element, LAST on the whole document
// capturing mode is 

function printEventDetails(event) {
    console.log(event);
    // type click, mouseover, etc.. name of event
    console.log(`type: ${event.type}`);
    // the element that the event is fired on
    console.log(`target: ${event.target}`);
    // the element whose handler is running right now
    console.log(`currentTarget: ${event.currentTarget}`);
    // this is set to currentTarget
    console.log(`this: ${this}`);

}