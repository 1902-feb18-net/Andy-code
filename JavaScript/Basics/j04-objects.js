'use strict';

// JS is OO or object based
// though it lacks classes at least in ES5
// however it does have inheritance
// in js obj can inherit directly from other concrete obj
// it's called "prototype1 inheritance"

let obj = {
    a: '5',
    b: '3'
};

obj.c = 3;

// obj.sayName = () => {console.log("Bob")};
obj.sayName = function () {
    console.log("bob");
}

obj.sayName();

let studentLiteral = {
    name: 'Phil',
    age: 32,
    sayName: function () {
        console.log(this.name);
    },
    sayNameArrow: () => {
        console.log(this.name)
    }

}

// in JS "this" works in a special way
// when you call a f(n) it is set to the obj
// what was to the left of the dot when you called
// the f(n)

// there is an exception to that for ES6 arrow functions
// with this in arrow functions, it is set when the function
// is written, and does not change

studentLiteral.sayName();

let func = studentLiteral.sayName;
obj.func = func;
obj.name = 'Sue';

obj.func();

obj.arrowFunc = studentLiteral.sayNameArrow

// we can make new ob from a template using not class
// but just constructor
// and by constructor we just mean a function

function Student(name, age, gpa) {
    this.name = name;
    this.age = age;
    this.gpa = gpa;
    this.sayName = function () {
        console.log(this.name);
    }
}

let student = new Student("Joe", 44, 3.6);
student.sayName();

// like i said we have inheritance in c#
 function StudentWithBirthday(name, age, gpa, birthday) {
     this.__proto__ = new Student(name, age, gpa);
     this.birthday = birthday;
     this.checkBirthday= function(date) {
         if(date === this.birthday) {
             console.log("happy Birthday!");
         }
     }
 }

 // in js we can set prototype of an obj with the special prop
 // __proto__

 var studentB = new StudentWithBirthday('Bill', 22, 3.2, 'yesterday');
 studentB.sayName();

 console.log(studentB);

 // in js, property access falls back to looking at the prototype
 // if the property is not found on the current obj
 // and so on and so on

 // in ES6 classes were added as syntactic sugar around prototypal inheritance
