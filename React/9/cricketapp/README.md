# Getting Started with Create React App

This project was bootstrapped with [Create React App](https://github.com/facebook/create-react-app).

## Available Scripts

In the project directory, you can run:

### `npm start`

Runs the app in the development mode.\
Open [http://localhost:3000](http://localhost:3000) to view it in your browser.

The page will reload when you make changes.\
You may also see any lint errors in the console.

### `npm test`

Launches the test runner in the interactive watch mode.\
See the section about [running tests](https://facebook.github.io/create-react-app/docs/running-tests) for more information.

### `npm run build`

Builds the app for production to the `build` folder.\
It correctly bundles React in production mode and optimizes the build for the best performance.

The build is minified and the filenames include the hashes.\
Your app is ready to be deployed!

See the section about [deployment](https://facebook.github.io/create-react-app/docs/deployment) for more information.

### `npm run eject`

**Note: this is a one-way operation. Once you `eject`, you can't go back!**

If you aren't satisfied with the build tool and configuration choices, you can `eject` at any time. This command will remove the single build dependency from your project.

Instead, it will copy all the configuration files and the transitive dependencies (webpack, Babel, ESLint, etc) right into your project so you have full control over them. All of the commands except `eject` will still work, but they will point to the copied scripts so you can tweak them. At this point you're on your own.

You don't have to ever use `eject`. The curated feature set is suitable for small and middle deployments, and you shouldn't feel obligated to use this feature. However we understand that this tool wouldn't be useful if you couldn't customize it when you are ready for it.

## Learn More

You can learn more in the [Create React App documentation](https://facebook.github.io/create-react-app/docs/getting-started).

To learn React, check out the [React documentation](https://reactjs.org/).

### Code Splitting

This section has moved here: [https://facebook.github.io/create-react-app/docs/code-splitting](https://facebook.github.io/create-react-app/docs/code-splitting)

### Analyzing the Bundle Size

This section has moved here: [https://facebook.github.io/create-react-app/docs/analyzing-the-bundle-size](https://facebook.github.io/create-react-app/docs/analyzing-the-bundle-size)

### Making a Progressive Web App

This section has moved here: [https://facebook.github.io/create-react-app/docs/making-a-progressive-web-app](https://facebook.github.io/create-react-app/docs/making-a-progressive-web-app)

### Advanced Configuration

This section has moved here: [https://facebook.github.io/create-react-app/docs/advanced-configuration](https://facebook.github.io/create-react-app/docs/advanced-configuration)

### Deployment

This section has moved here: [https://facebook.github.io/create-react-app/docs/deployment](https://facebook.github.io/create-react-app/docs/deployment)

### `npm run build` fails to minify

This section has moved here: [https://facebook.github.io/create-react-app/docs/troubleshooting#npm-run-build-fails-to-minify](https://facebook.github.io/create-react-app/docs/troubleshooting#npm-run-build-fails-to-minify)

======================
ES6+ JavaScript Essentials for React
======================

------------------------------------------------------------------------
OBJECTIVES
------------------------------------------------------------------------

By exploring this repository, you will be able to:
[x] List the key features of ES6
[x] Explain JavaScript let
[x] Identify the differences between var and let
[x] Explain JavaScript const
[x] Explain ES6 class fundamentals
[x] Explain ES6 class inheritance
[x] Define ES6 arrow functions
[x] Identify and use Map() and Set()

------------------------------------------------------------------------
KEY CONCEPTS & EXAMPLES
------------------------------------------------------------------------

1. Overview of Key ES6 Features
-------------------------------
ES6 modernized JavaScript by introducing:
* Block-Scoped Variables: let and const
* Arrow Functions: Shorter syntax and lexical this
* Classes: Cleaner syntax for object-oriented programming
* Data Structures: Built-in Map and Set
* Template Literals: String interpolation using backticks (`)
* Destructuring: Easy unpacking of arrays and objects
* Modules: import and export statements

2. Variable Declarations (let, const, vs var)
--------------------------------------------
LET
- Block-Scoped: Variable exists only inside the enclosing {} block.
- Re-assignable: You can change its value later.
- No Re-declaration: Cannot re-declare the same variable in the same scope.

Example:
let count = 1;
count = 2; // Allowed

if (true) {
  let insideIf = "I am isolated";
}
// console.log(insideIf); // ReferenceError

CONST
- Block-Scoped: Same scoping rules as let.
- Immutable Binding: Cannot be reassigned after declaration.
- Note on Objects/Arrays: The reference is fixed, but internal properties or elements can still be mutated.

Example:
const maxSpeed = 100;
// maxSpeed = 120; // TypeError: Assignment to constant variable.

const user = { name: "Alex" };
user.name = "Sam"; // Allowed: mutating property, not reassigning variable

KEY DIFFERENCES: VAR vs LET
Feature        | var                                 | let
---------------|-------------------------------------|-----------------------------------
Scope          | Function Scope                      | Block Scope
Hoisting       | Hoisted & initialized as undefined  | Hoisted into Temporal Dead Zone
Re-declaration | Allowed in same scope               | Throws SyntaxError in same scope

3. ES6 Classes & Inheritance
----------------------------
ES6 classes provide a cleaner, syntactical wrapper over JavaScript's prototype-based inheritance.

CLASS FUNDAMENTALS:
class Person {
  constructor(name, age) {
    this.name = name;
    this.age = age;
  }

  greet() {
    return `Hi, I'm ${this.name} and I am ${this.age} years old.`;
  }
}

const user1 = new Person("Priya", 22);
console.log(user1.greet());

CLASS INHERITANCE (extends and super):
Inheritance allows one class to inherit methods and properties from a parent class.

class Student extends Person {
  constructor(name, age, major) {
    super(name, age); // Calls parent constructor
    this.major = major;
  }

  study() {
    return `${this.name} is studying ${this.major}.`;
  }
}

const student1 = new Student("Rahul", 20, "Computer Science");
console.log(student1.greet()); // Inherited method
console.log(student1.study()); // Student-specific method

4. Arrow Functions
------------------
Arrow functions offer a shorter syntax and don't create their own 'this' context (they inherit 'this' lexically from their surrounding scope).

// Traditional Function
function add(a, b) {
  return a + b;
}

// ES6 Arrow Function
const addArrow = (a, b) => a + b; // Implicit return for single-line expressions

// Arrow function in React callbacks
const numbers = [1, 2, 3, 4];
const doubled = numbers.map(num => num * 2);

5. Map and Set Data Structures
------------------------------
MAP()
A collection of key-value pairs where keys can be of any data type (objects, functions, primitives). Maintains insertion order.

const userRoles = new Map();
const userObj = { id: 1 };
userRoles.set(userObj, "Admin");

console.log(userRoles.get(userObj)); // Output: "Admin"
console.log(userRoles.has(userObj)); // Output: true

SET()
A collection of unique values. Duplicate entries are automatically ignored.

const uniqueIds = new Set();
uniqueIds.add(101);
uniqueIds.add(102);
uniqueIds.add(101); // Duplicate ignored

console.log(uniqueIds.size); // Output: 2
console.log(uniqueIds.has(101)); // Output: true

// Common trick: Removing duplicates from an array
const arrayWithDuplicates = [1, 2, 2, 3, 4, 4];
const cleanArray = [...new Set(arrayWithDuplicates)]; // [1, 2, 3, 4]