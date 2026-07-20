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

# React Props, State & Rendering

A guide to `props` in React — what they are, how default props work, how they differ from `state`, and how `ReactDOM.render()` gets everything onto the screen.

## 📚 Table of Contents

- [What are Props?](#what-are-props)
- [Default Props](#default-props)
- [State vs Props](#state-vs-props)
- [ReactDOM.render()](#reactdomrender)

---

## What are Props?

**Props** (short for "properties") are how data is passed from a **parent component** to a **child component** in React. They work similarly to function arguments — a component receives props as input and uses them to determine what to render.

```javascript
function Cart(props) {
    return (
        <table>
            <tbody>
                {props.item.map((item) => (
                    <tr key={item.itemname}>
                        <td>{item.itemname}</td>
                        <td>{item.price}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
}
```

```javascript
<Cart item={CartInfo} />
```

Here, `CartInfo` (an array of items) is passed down from the parent into `Cart` as the `item` prop.

### Key characteristics of props

- **Read-only** — a component must never modify its own props directly. Props flow one way: parent → child.
- **Passed like HTML attributes** — `<Component propName={value} />`.
- **Can be any data type** — strings, numbers, arrays, objects, functions, even other components.
- **Enable reusability** — the same component can render differently depending on what props it receives, without duplicating code.

### Accessing props

- In **function components**: received directly as a parameter — `function Home(props) { ... }` or destructured — `function Home({ title }) { ... }`.
- In **class components**: accessed via `this.props` — `this.props.item`.

---

## Default Props

**Default props** let you specify fallback values for props, used automatically when a parent doesn't explicitly pass that prop.

### Function components

```javascript
function Greeting({ name }) {
    return <h2>Hello, {name}!</h2>;
}

Greeting.defaultProps = {
    name: "Guest"
};
```

If used as `<Greeting />` (no `name` passed), it renders **"Hello, Guest!"** instead of breaking or showing `undefined`.

### Class components

```javascript
class Greeting extends React.Component {
    render() {
        return <h2>Hello, {this.props.name}!</h2>;
    }
}

Greeting.defaultProps = {
    name: "Guest"
};
```

### Why default props are useful

- **Prevents `undefined` errors/UI bugs** when a parent forgets to pass a required prop.
- **Improves component reliability** — the component behaves predictably even with incomplete input.
- **Self-documenting** — makes it clear what props a component expects and what reasonable defaults look like.

> Note: In newer versions of React, default parameter values in function components (`function Greeting({ name = "Guest" })`) are commonly used as a modern alternative to `defaultProps`.

---

## State vs Props

Both `state` and `props` hold data that influences what a component renders — but they serve very different purposes.

| Aspect | Props | State |
|---|---|---|
| **Ownership** | Owned and controlled by the **parent** component | Owned and controlled by the **component itself** |
| **Mutability** | Read-only — cannot be changed by the receiving component | Mutable — can be updated via `setState()` (class) or the setter from `useState()` (function) |
| **Data flow** | Passed **down** from parent to child | Local/internal to the component |
| **Who can change it** | Only the parent can change what's passed in | Only the component itself can change its own state |
| **Purpose** | Configure/customize a component from outside | Track dynamic, internal data that changes over time (e.g., form input, toggle state, fetched data) |
| **Triggers re-render?** | Yes, when the parent passes new prop values | Yes, when `setState`/`useState` setter is called |
| **Example** | `<Cart item={CartInfo} />` | `const [count, setCount] = useState(0);` |

### Simple analogy

Think of a component like a function:
- **Props** are like the function's **parameters** — supplied by whoever calls it.
- **State** is like a **local variable** declared inside the function — managed internally, not visible or controllable from outside.

---

## ReactDOM.render()

`ReactDOM.render()` (or in React 18+, `root.render()` via `createRoot`) is the method that actually takes your React component tree and injects it into the real browser DOM.

### Legacy syntax (React 17 and earlier)

```javascript
import ReactDOM from 'react-dom';
import App from './App';

ReactDOM.render(<App />, document.getElementById('root'));
```

### Modern syntax (React 18+, used in current create-react-app projects)

```javascript
import ReactDOM from 'react-dom/client';
import App from './App';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(<App />);
```

### What it does, step by step

1. **`document.getElementById('root')`** — locates the actual `<div id="root"></div>` element in `public/index.html`. This is the single entry point in the plain HTML page where React will take over.
2. **`<App />`** — the root component of your application, representing the entire component tree.
3. **`render()`** — React converts the JSX returned by your components into actual DOM nodes, and inserts them inside that `root` `<div>`.
4. From this point on, React manages all further updates to that part of the DOM using the **Virtual DOM** — efficiently diffing and patching only what's changed, rather than re-rendering the whole page.

### Why it matters

- It's the **bridge** between your React component tree (JavaScript objects describing UI) and the actual browser DOM (real HTML elements the user sees).
- It only needs to be called **once**, at the top level of your app — React handles all subsequent re-renders internally as state/props change.

---

## 📝 Summary

- **Props** pass data down from parent to child and are read-only.
- **Default props** provide fallback values when a prop isn't explicitly supplied.
- **State** is internal, mutable data managed by the component itself.
- **`ReactDOM.render()`** is the one-time call that mounts your entire React component tree into the real DOM.