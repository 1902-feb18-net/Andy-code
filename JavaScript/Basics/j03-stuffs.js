'use strict';

// loose equality vs strict equality
// aka double equals vs triple equals

function compare(a, b) {
    // one this that ES6 added was string interpolation
    // aka template literals
    //console.log('a: ' +  a); // and etc, can shorten with backtick
    console.log("with == ")
    console.log(`a ${a}, b ${b}, a == b ${a == b}`);   
    console.log("with === see the difference")
    console.log(`a ${a}, b ${b}, a === b ${a === b}`);
}

// double equals uses type coercion to attempt to compare value
// without caring about types

compare(1, 2);
compare(1, 1);
compare(true, '1');
compare([1], 1);

// triple equals compares both types and value
let x = NaN;
if (isNaN(x)){
    console.log("Oh no, NaN!!!");
}

var y = [1, 2, 3, 5, 3, null, 6]
var sum;
for(let i = 0; i < y.length; i++){
    sum += y[i];
}
console.log("sum is ", sum);

// functional way to sum the array
console.log("using reduce ", y.reduce((prev, curr) => prev + curr, 0));

// type coercion to booleans we should know
// because it happens when we put things in an iff condition
if(x) {

}
// the rule is, everything is true, except a handful of special values are false
// we call values that convert to true "truthy"
// rest are "falsy"

// falsy values are
// undefined
// null
// o (-0)
// NaN
// ''
// false