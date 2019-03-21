'use strict';

// when we standardized ES5
// we wanted to fix some bad historical behavior
// w/o breaking backwards compatibility

// hence strict mode, opt in with string expression
// 'use strict' as first line in file or function

// x = 5;
// undeclared vars become ReferenceError

// in general, some old bad silent errors
// became thrown errors

// in js, before ES6. we had two scopes for vars
// 1. global scope
// 2. function scope

let x = 5;

function func() {
    console.log(x);
    let abc = 'abc';

    // globalvar = 'abc'; // can't make global vars like this anymore

    if (3 == 1) {
        let variable = 45;
    }
    // won't work, block scope
    // console.log(variable);
}

func();

// console.log(abc); // ReferenceError

// "let" is actually ES6
// used to only have "var"
// now let and const
// "let" was added with block scope semantics

// "var" has a behavior called "hoisting"
// where the _declarations_ are effectively moved
// to the top of the function

// ES6 also added "const"
try {
    const a = 15;
    a = 17; // TypeError, can't change const
} catch(err) {
    console.log(err);
}

function throwsSomething(x) {
    throw x;
}

try {
    throwsSomething(3);
} catch (err) {
    console.log("throw something ", err);
}

// JS is not compiled, it's interpreted

// if the JS engine wants to, it can do "JIT compilation" of some kind

// we can write ES6, ES2016 ... and then compile it down to ES5
