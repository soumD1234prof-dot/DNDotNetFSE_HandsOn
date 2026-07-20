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

# React Components — Deep Dive
 
A conceptual guide covering React components: what they are, how they differ from plain JavaScript functions, the types of components, and the core building blocks like the constructor and `render()` method.
 
## 📚 Table of Contents
 
- [What are React Components?](#what-are-react-components)
- [Components vs JavaScript Functions](#components-vs-javascript-functions)
- [Types of Components](#types-of-components)
- [Class Components](#class-components)
- [Function Components](#function-components)
- [The Component Constructor](#the-component-constructor)
- [The render() Function](#the-render-function)
---
 
## What are React Components?
 
A **component** is an independent, reusable piece of UI in a React application. Each component encapsulates its own structure (markup), logic, and optionally its own state, and can be composed together to build complex user interfaces.
 
Think of components as custom, reusable building blocks — similar to how HTML has built-in elements like `<div>` or `<button>`, React lets you create your own elements like `<Home/>`, `<Navbar/>`, or `<UserCard/>`.
 
Every React application is fundamentally a **tree of components**, typically starting from a root component (often `App`) that renders other nested components.
 
---
 
## Components vs JavaScript Functions
 
At first glance, a function component looks just like a regular JavaScript function — because technically, it is one. But there are key differences in behavior and purpose:
 
| Aspect | Regular JS Function | React Component |
|---|---|---|
| **Return value** | Can return any value (number, string, object, etc.) | Must return JSX (or `null`) describing UI |
| **Naming convention** | Any casing (camelCase common) | Must start with a **capital letter** (PascalCase) so React can distinguish it from HTML tags |
| **Invocation** | Called directly: `myFunction()` | Rendered as JSX: `<MyComponent />` |
| **Re-execution** | Runs once when called | Re-runs automatically whenever its state or props change |
| **State management** | No built-in concept of "state" | Can hold and manage its own state (via `this.state` or `useState`) |
| **Lifecycle awareness** | No lifecycle concept | Can hook into mount/update/unmount phases |
 
In short: **every component is a function (or class), but not every function is a component.** A function only behaves like a React component when it returns JSX and is used within React's rendering system.
 
---
 
## Types of Components
 
React components generally fall into two categories:
 
1. **Class Components** — ES6 classes that extend `React.Component`, using `this.state` and lifecycle methods.
2. **Function Components** — plain JavaScript functions (increasingly the standard approach, especially with Hooks like `useState` and `useEffect`).
Components can also be classified by role:
- **Presentational (stateless) components** — focus purely on how things look, receiving data via `props`.
- **Container (stateful) components** — manage state and logic, often passing data down to presentational components.
---
 
## Class Components
 
A **class component** is defined using an ES6 class that extends `React.Component`. It must implement a `render()` method that returns JSX.
 
```javascript
import React, { Component } from 'react';
 
class Welcome extends Component {
  render() {
    return (
      <h1>Hello from a Class Component!</h1>
    );
  }
}
 
export default Welcome;
```
 
**Key characteristics:**
- Uses `this.state` to manage internal state.
- Uses `this.props` to access data passed from a parent.
- Requires a `render()` method to output JSX.
- Can use lifecycle methods like `componentDidMount()`, `componentDidUpdate()`, `componentWillUnmount()`.
- Was the standard way to manage state before React Hooks were introduced (React 16.8, 2019).
---
 
## Function Components
 
A **function component** is simply a JavaScript function that returns JSX.
 
```javascript
function Welcome() {
  return (
    <h1>Hello from a Function Component!</h1>
  );
}
 
export default Welcome;
```
 
**Key characteristics:**
- Simpler and more concise than class components.
- No `this` keyword needed.
- Uses **Hooks** (`useState`, `useEffect`, etc.) to manage state and side effects.
- Recommended by the React team as the modern standard for new code.
**Example with state (using Hooks):**
 
```javascript
import { useState } from 'react';
 
function Counter() {
  const [count, setCount] = useState(0);
 
  return (
    <div>
      <p>Count: {count}</p>
      <button onClick={() => setCount(count + 1)}>Increment</button>
    </div>
  );
}
 
export default Counter;
```
 
---
 
## The Component Constructor
 
The **constructor** is a special method in a class component, called automatically when an instance of the component is created — before it's rendered.
 
```javascript
class Welcome extends Component {
  constructor(props) {
    super(props);
    this.state = {
      message: "Hello, React!"
    };
  }
 
  render() {
    return <h1>{this.state.message}</h1>;
  }
}
```
 
**Purpose of the constructor:**
- **Initialize state** — set up the component's starting `this.state`.
- **Bind event handler methods** to `this`, so they work correctly when called from JSX.
- Must call `super(props)` first — this passes `props` up to the parent `React.Component` class so `this.props` works correctly inside the component.
> Note: Constructors are only used in **class components**. Function components don't need one — state initialization happens directly via `useState()`.
 
---
 
## The render() Function
 
The **`render()` function** is a required method in every class component. Its job is to describe *what* should appear on the screen by returning JSX.
 
```javascript
class Home extends Component {
  render() {
    return (
      <div>
        <h3>Welcome to the Home Page</h3>
      </div>
    );
  }
}
```
 
**Key points about `render()`:**
- It must return valid JSX (or `null` to render nothing).
- It should be a **pure function** — it should not modify component state directly; it just describes the UI based on current state/props.
- React calls `render()` automatically whenever the component's `state` or `props` change, and efficiently updates the DOM via the Virtual DOM diffing process.
- In function components, there's no explicit `render()` method — the function's own `return` statement serves the same purpose.
---
 
## 📝 Summary
 
| Concept | Class Component | Function Component |
|---|---|---|
| State | `this.state` | `useState()` Hook |
| Output | via `render()` method | via function `return` |
| `this` keyword | Required | Not used |
| Constructor | Used to initialize state | Not needed |
| Recommended for new code | ❌ Legacy | ✅ Modern standard |