'use strict';

// callback functions

// similar to delegate/func/etc in C#
// we can write code that accept sother code as param
// in order to either
// 1. provide some polymorphism/extensibility to code
// (gives caller some input on what will be done)
// 2. for async stuff - caller says what code to run when the 
// result is finally ready

// w/o callbacks
function add(a, b) {
    let result = a + b;
    return result;
}

// console.log(add(1, 3));


// with callback         callback function
//                          vvv
function multiply(a, b, onSuccess) {
    let result = a + b;
    return onSuccess("multiply onSuccess", result);
}
// multiply(2,3, console.log);


// func(params, result => {
//     func(result, result2 => {
//         // nested callbacks are a common occurence in JS
//     })
// });

// common thing to do e.g.
// register an event handler on some html element and its event

// JS has closure
// JS functions close over their environment

function newCounter(){
    let counter = 0;
    return () => {return counter++; }
}

function newCounter2() {
    let counter = 0;
    return function () {
        c++;
        return c;
    }
}

let c = 0;
// the language could look at that "c"
// instead of the one inside newCounter...
// especially because the one inside 
// the counter is out of scope!

// instead functions in JS 
// close over any variables from outside that
// they reference. they keep those vars alive
// as long as the func itself is alive

let counter1 = newCounter();
console.log(counter1()); // 0
console.log(counter1()); // 1
console.log(counter1()); // 2

let counter2 = newCounter();
console.log(counter2()); // 0
console.log(counter2()); // 1

// it's really a concept from CS
// .. as programmers, we are very loose about
// the meaning of closure

// in JS, all these <script> content are concatenated
// we really try to avoid putting things in
// global scope

// there is a technique called "IIFE"
// immediately invoked function expression

// we can use this to hide our variables from global scope
// and yet still run immediately
(function () {
    let work = 0;
})();

let library = (function () {
    let privateData = 0;
    function privateFunction(x) {
        return privateData;
    }
    return {
        libraryMethod() {
            return privateFunction + privateData;
        }
    }
})();

// only libraryMethod is visible to anyone
console.log(library);

// with ES6 we have modules
// a file can be a module, if it is,
// it gets its own global scope
// and only what is explicitly exported
// and then implicitly imported by other files 
// can be seen in those other files

// ES6 features...
// block scope (let const)
// arrow functions 
// method syntax

// default parameters
// function add (a =1, b = 2) {

// }

// string interpolation (template literals)
// `${}`

// classes with class inheritance (extends)
// symbol type
// many added useful builtin functions
//  like on string
// es6 modules
// Set and Map objects
// for of loop (like foreach in C#)
// get/set properties

// get name() {
//     return this._name.toUpperCase();
// }

// set name(newName) {
//     this._name = newName;   // validation could be checked here such as only allowing non numerical values
// }

// internationalization features

// spread / destructuring
// var a, b, rest;
// [a, b] = [10, 20];
// console.log(a); // 10
// console.log(b); // 20

// [a, b, ...rest] = [10, 20, 30, 40, 50];
// console.log(a); // 10
// console.log(b); // 20
// console.log(rest); // [30, 40, 50]

// ({ a, b } = { a: 10, b: 20 });
// console.log(a); // 10
// console.log(b); // 20


// // Stage 4(finished) proposal
// ({ a, b, ...rest } = { a: 10, b: 20, c: 30, d: 40 });
// console.log(a); // 10
// console.log(b); // 20
// console.log(rest); // {c: 30, d: 40}

// Promises (a way to do async stuffs)