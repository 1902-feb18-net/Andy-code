'use strict';

console.log("hello console");

// undefined type (with one possible value)
let x
x = 2
let y
y = undefined;

// number
// same type in JS for whole nums and decimals
// internally it is basically c# double
// 64 bit IEEE floating point number
x = 0;
x = -1;
x = 1.5;
y = Infinity;
y = -Infinity;
y = 4/0 //infinity
y = NaN;
// this is NaN
y = "abc" / 4; 
y = NaN + 5; //NaN

// string
x = 'abc';
x = "abc"; // double quotes or single are the same thing or use escapes with \

// bool
x = true;
x = false;
x = (1 == 2);

// object (reference semantics)
// JS has obj that are not necessarily based on classes
// I can make an obj with braces
x = {}; // obj literal
x = console;

x.Name = "Joe";

x = {
    "name": "Bob",
    age: 25,
    birthday: "march"
};

x.color = "gray";
console.log("shouldn't exist ", x.doesntExist);
// like "dynamic" in c#

// null type
// one valid value, null
x = null;
// for historical reasons, "typeof null" is "object"
// similar to C#, we use null to indicate absence of a value

// function
// similar to C# delegate/lambda/func/action
x = function (x) { return x*x; }
console.log("let's run this function to square ",x(5))


// console logging
console.log(x);
console.log(typeof x);
console.log(typeof x, x, "apples");
console.log(`apples typeof ${x} is ${typeof x} apples ${x}`)

// ES6 added a new type called symbol
// used for globally unique identifier


// 7 types
// string, number, boolean
// null, undefined
// object
// (symbol)

// function declaration
function printName(name) {
    console.log(name);
}
// because js is dynamically typed, we don't declare param types or return type

// instead of "void return"
// just undefined return
console.log(printName("Bob"));

// another way to do the same thing
// "function expression"
let printName2 = function (name) {
    console.log(name);
}

// with ES6 we also have lambda function or "arrow function"
let printName3 = (x) => {x * x};
let printName4 = name => {
    console.log(name);
};

let condition = true;
const length = 4;

// most familliar C-style control structure
// if (condition) {

// } else if (condition) {

// } else {

// }

// for (let i = 0; i < length; i ++) {

// }

// while (condition) {

// }

// switch (key) {
//     case value:
//         break;
//     default:
//         break;
// }

// we have operators
3 == 3;
3 != 3;
3 <= 3;
3 && 3;
3 || 3;


let z = 5;

// this is a breakpoint
// debugger;

z += 1;


function addTwo(a,b) {
    console.log(a);
    console.log(b);
    return a + b;
}

console.log("Adding two ", addTwo(2,3));
// extra args are silently discarded
console.log("Adding two ", addTwo(2, 3, 4));
// not provided args become undefined
console.log(addTwo(1));

// ternary operators
function getFee(isMember) {
    return (isMember ? "$2.00" : "$10.00");
}

console.log(getFee(true));
// expected output: "$2.00"

console.log(getFee(false));
// expected output: "$10.00"