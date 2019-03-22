'use strict';

// converting our constructors into classes

// we can make new ob from a template using not class
// but just constructor
// and by constructor we just mean a function
class Student {
    constructor(name, age, gpa) {
        this.name = name;
        this.age = age;
        this.gpa = gpa;
        this.sayName = function () {
            console.log(this.name);
        };
    }
}

let student = new Student("Joe", 44, 3.6);
student.sayName();


// like i said we have inheritance in c#
class StudentWithBirthday {
    constructor(name, age, gpa, birthday) {
        this.__proto__ = new Student(name, age, gpa);
        this.birthday = birthday;
        this.checkBirthday = function (date) {
            if (date === birthday) {
                console.log();
            }
        };
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

 // in ES6 classes were added as syntactic sugar around prototypal inheritanceclass StudentWithBirthday {
    


