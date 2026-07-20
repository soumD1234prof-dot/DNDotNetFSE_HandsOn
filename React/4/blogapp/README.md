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

# React Component Lifecycle
 
A conceptual guide to the React component lifecycle — why it exists, the key hook methods available at each stage, and the sequence of events that occurs when a component renders.
 
## 📚 Table of Contents
 
- [What is the Component Lifecycle?](#what-is-the-component-lifecycle)
- [Need & Benefits of the Component Lifecycle](#need--benefits-of-the-component-lifecycle)
- [Lifecycle Hook Methods](#lifecycle-hook-methods)
- [Rendering Sequence](#rendering-sequence)
- [Class vs Function Component Lifecycle](#class-vs-function-component-lifecycle)
---
 
## What is the Component Lifecycle?
 
Every React component goes through a series of phases from the moment it's created, through updates, to when it's finally removed from the DOM. This journey is called the **component lifecycle**.
 
React provides special methods — **lifecycle hooks** — that let you "hook into" specific moments in this journey to run custom logic, such as fetching data, updating the DOM, or cleaning up resources.
 
The lifecycle is generally divided into three main phases:
1. **Mounting** — component is created and inserted into the DOM.
2. **Updating** — component re-renders due to changes in `props` or `state`.
3. **Unmounting** — component is removed from the DOM.
---
 
## Need & Benefits of the Component Lifecycle
 
### Why it's needed
Without lifecycle methods, a component would have no way to:
- Run code at a *specific* point in time (e.g., only once, right after the component appears on screen).
- React to changes in its own data over time.
- Clean up things like timers, subscriptions, or event listeners before disappearing — leading to memory leaks.
### Benefits
 
- **Precise control over timing** — run code exactly when needed (e.g., fetch data only after the component mounts, not during every render).
- **Efficient resource management** — set up subscriptions/listeners on mount and clean them up on unmount, preventing memory leaks.
- **Better performance** — selectively control when a component should re-render, avoiding unnecessary updates.
- **Error handling** — catch and gracefully handle errors that occur during rendering, without crashing the whole app.
- **Predictable data flow** — clearly separates "component just appeared," "component just changed," and "component is about to disappear," making debugging and reasoning about the app easier.
---
 
## Lifecycle Hook Methods
 
Lifecycle methods are grouped by which phase of the component's life they belong to.
 
### 1. Mounting Phase
*(Component is being created and inserted into the DOM)*
 
| Method | Purpose |
|---|---|
| `constructor(props)` | Initializes state and binds event handlers. Called before the component is mounted. |
| `render()` | Required method that returns the JSX to be displayed. |
| `componentDidMount()` | Called immediately after the component is inserted into the DOM. Ideal for API calls, subscriptions, or DOM manipulation. |
 
### 2. Updating Phase
*(Component re-renders due to changes in props or state)*
 
| Method | Purpose |
|---|---|
| `render()` | Re-invoked whenever state or props change, to reflect the new UI. |
| `componentDidUpdate(prevProps, prevState)` | Called immediately after an update occurs. Useful for reacting to prop/state changes (e.g., re-fetching data when a prop changes). |
| `shouldComponentUpdate(nextProps, nextState)` | Lets you optimize performance by returning `false` to skip an unnecessary re-render. |
 
### 3. Unmounting Phase
*(Component is being removed from the DOM)*
 
| Method | Purpose |
|---|---|
| `componentWillUnmount()` | Called right before the component is removed. Used for cleanup — clearing timers, canceling network requests, removing event listeners. |
 
### 4. Error Handling Phase
 
| Method | Purpose |
|---|---|
| `componentDidCatch(error, info)` | Catches JavaScript errors thrown anywhere in the child component tree during rendering, allowing graceful error handling instead of a full app crash. |
 
---
 
## Rendering Sequence
 
When a component is first rendered (mounted) to the screen, the lifecycle methods fire in this exact order:
 
```
1. constructor(props)
        ↓
2. render()
        ↓
3. React updates the DOM and refs
        ↓
4. componentDidMount()
```
 
**Step-by-step breakdown:**
 
1. **`constructor(props)`** — the component instance is created; initial state is set up.
2. **`render()`** — React calls this to determine what the UI should look like; returns JSX describing the structure.
3. **DOM update** — React takes the JSX output, compares it against the Virtual DOM (diffing), and commits the necessary changes to the actual browser DOM.
4. **`componentDidMount()`** — fires once, immediately after the component has been rendered to the DOM for the first time. This is the standard place to trigger side effects like data fetching.
### On subsequent updates (state/props change):
 
```
1. render()
        ↓
2. React updates the DOM
        ↓
3. componentDidUpdate(prevProps, prevState)
```
 
### On removal from the DOM:
 
```
1. componentWillUnmount()
        ↓
2. Component is removed from the DOM
```
 
---
 
## Class vs Function Component Lifecycle
 
Function components don't use lifecycle methods directly — instead, the `useEffect` Hook covers the same use cases:
 
| Class Component | Function Component Equivalent |
|---|---|
| `componentDidMount()` | `useEffect(() => { ... }, [])` |
| `componentDidUpdate()` | `useEffect(() => { ... }, [dependency])` |
| `componentWillUnmount()` | `useEffect(() => { return () => { ... } }, [])` (cleanup function) |
 
**Example:**
 
```javascript
import { useEffect } from 'react';
 
function Posts() {
  useEffect(() => {
    // Equivalent to componentDidMount
    console.log("Component mounted");
 
    return () => {
      // Equivalent to componentWillUnmount
      console.log("Component will unmount");
    };
  }, []); // empty dependency array = run only once, on mount
 
  return <div>Posts</div>;
}
```
 
---
 
## 📝 Summary
 
The component lifecycle gives predictable checkpoints — creation, update, and removal — to run the right code at the right time. Understanding it is essential for tasks like data fetching, performance optimization, and proper resource cleanup in any non-trivial React application.