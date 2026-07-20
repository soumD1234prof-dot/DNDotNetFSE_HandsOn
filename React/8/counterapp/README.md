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

# React State

A guide to understanding and working with the `state` object in React — what it is, how it's used, and how to update it correctly.

## 📚 Table of Contents

- [What is React State?](#what-is-react-state)
- [Why State is Needed](#why-state-is-needed)
- [Declaring State](#declaring-state)
- [Updating State with setState()](#updating-state-with-setstate)
- [Functional Updates (prevState)](#functional-updates-prevstate)
- [State in Function Components (useState)](#state-in-function-components-usestate)
- [Hands-On Example](#hands-on-example)

---

## What is React State?

**State** is an object that holds data which belongs to, and is managed entirely by, a single component. Unlike `props`, which are passed in from a parent, state is **local and private** — only the component itself can read and update it.

Whenever a component's state changes, React automatically **re-renders** that component (and its children) to reflect the new data on screen.

Think of state as a component's own memory — it lets a component "remember" and react to things like user input, button clicks, toggles, or fetched data, across re-renders.

---

## Why State is Needed

Without state, a component could only ever display static, unchanging content — there'd be no way to reflect user interaction or changing data over time.

State is essential for:
- **Tracking user interactions** — e.g., counting how many times a button was clicked.
- **Form handling** — storing what a user has typed into an input field.
- **Toggling UI** — showing/hiding elements, switching between views.
- **Storing fetched data** — holding the result of an API call so it can be displayed.
- **Triggering re-renders** — any time state changes, React automatically updates the UI to match, without you manually touching the DOM.

---

## Declaring State

In a **class component**, state is initialized inside the `constructor()` as a plain JavaScript object, assigned to `this.state`:

```javascript
class CountPeople extends React.Component {
    constructor() {
        super();
        this.state = {
            entrycount: 0,
            exitcount: 0
        };
    }
}
```

**Key points:**
- Always call `super()` first inside the constructor — this is required before `this` can be used, since it initializes the parent `React.Component` class.
- `this.state` should only be assigned directly like this **inside the constructor**. Anywhere else in the component, you must update it using `setState()` (see below) — never reassign `this.state` directly elsewhere.

---

## Updating State with setState()

To change state after the component has mounted, use `this.setState()` — never modify `this.state` directly.

```javascript
updateEntry() {
    this.setState({ entrycount: this.state.entrycount + 1 });
}
```

### Why not modify state directly?

```javascript
// ❌ Wrong — never do this
this.state.entrycount = this.state.entrycount + 1;
```

Directly mutating `this.state` does **not** trigger a re-render — React has no way of knowing the data changed, so the UI won't update even though the underlying value technically did. `setState()` is what tells React: "state has changed, please re-render this component."

---

## Functional Updates (prevState)

`setState()` is **asynchronous** — React may batch multiple `setState()` calls together for performance. This means reading `this.state` directly inside `setState()` can sometimes use a stale value if called multiple times in quick succession.

To avoid this, use the **functional form** of `setState`, which receives the guaranteed-latest state as an argument:

```javascript
updateEntry() {
    this.setState((prevState, props) => {
        return { entrycount: prevState.entrycount + 1 };
    });
}
```

**Rule of thumb:** if your new state depends on the previous state's value (like incrementing a counter), always use the `(prevState, props) => {...}` form instead of directly referencing `this.state`.

---

## State in Function Components (useState)

Modern React code often uses **function components** with the `useState` Hook instead of class components. It achieves the same result with less boilerplate:

```javascript
import { useState } from 'react';

function CountPeople() {
    const [entrycount, setEntrycount] = useState(0);
    const [exitcount, setExitcount] = useState(0);

    const updateEntry = () => {
        setEntrycount(prev => prev + 1);
    };

    const updateExit = () => {
        setExitcount(prev => prev + 1);
    };

    return (
        <div>
            <button onClick={updateEntry}>Login</button>
            <span> {entrycount} People Entered!!! </span>

            <button onClick={updateExit}>Exit</button>
            <span> {exitcount} People Left!!! </span>
        </div>
    );
}

export default CountPeople;
```

| Class Component | Function Component |
|---|---|
| `this.state = { entrycount: 0 }` | `const [entrycount, setEntrycount] = useState(0)` |
| `this.setState({...})` | `setEntrycount(...)` |
| `(prevState, props) => {...}` | `prev => prev + 1` |

---

## Hands-On Example

A full class-component example tracking mall entry/exit counts using state — clicking each button updates only its own piece of state, independently:

```javascript
import React from 'react';

class CountPeople extends React.Component {
    constructor() {
        super();
        this.state = {
            entrycount: 0,
            exitcount: 0
        };
    }

    updateEntry() {
        this.setState((prevState, props) => {
            return { entrycount: prevState.entrycount + 1 }
        });
    }

    updateExit() {
        this.setState((prevState, props) => {
            return { exitcount: prevState.exitcount + 1 }
        });
    }

    render() {
        return (
            <div>
                <button onClick={() => this.updateEntry()}>Login</button>
                <span> {this.state.entrycount} People Entered!!! </span>

                <button onClick={() => this.updateExit()}>Exit</button>
                <span> {this.state.exitcount} People Left!!! </span>
            </div>
        );
    }
}

export default CountPeople;
```

**What's happening:**
1. `entrycount` and `exitcount` are initialized to `0` in the constructor.
2. Clicking **Login** calls `updateEntry()`, which increments `entrycount` via `setState`.
3. Clicking **Exit** calls `updateExit()`, which increments `exitcount` via `setState`.
4. Each `setState()` call triggers a re-render, so `render()` runs again and displays the updated counts — all without a page reload or manual DOM manipulation.

---

## 📝 Summary

- **State** is a component's own local, mutable data.
- Initialize it in the constructor (`this.state = {...}`) for class components, or via `useState()` for function components.
- Always update state using `setState()` (or the `useState` setter) — never mutate it directly.
- Use the functional update form (`prevState => {...}`) when the new value depends on the previous one.
- Any state change automatically triggers a re-render, keeping the UI in sync with the data.