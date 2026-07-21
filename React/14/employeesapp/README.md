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

# React Context API

A guide to the React Context API — why it exists, how to use `createContext()`, and a recap of router component types.

## 📚 Table of Contents

- [The Need and Benefits of React Context API](#the-need-and-benefits-of-react-context-api)
- [Working with createContext()](#working-with-createcontext)
- [Types of Router Components](#types-of-router-components)

---

## The Need and Benefits of React Context API

### The problem: prop drilling

In a typical React app, data flows one way — from parent to child — via `props`. This works fine for shallow component trees, but becomes cumbersome when a piece of data (like a theme, logged-in user, or language preference) needs to reach a component several levels deep.

```
App (has theme)
 └── EmployeesList (doesn't use theme, but must pass it through)
      └── EmployeeCard (actually uses theme)
```

To get `theme` from `App` to `EmployeeCard`, it has to be passed as a prop through `EmployeesList` too — even though `EmployeesList` itself has no use for it. This pattern is called **prop drilling**, and it gets worse as the component tree grows deeper, since every intermediate component becomes an unnecessary "middleman" just relaying data.

### The solution: Context API

The **Context API** lets you share data across a component tree without manually passing props through every intermediate level. A value is made available at some point in the tree (via a `Provider`), and any descendant component — no matter how deeply nested — can access it directly.

```
App (Provider supplies theme)
 └── EmployeesList (doesn't touch theme at all)
      └── EmployeeCard (reads theme directly via useContext)
```

### Benefits

- **Eliminates prop drilling** — intermediate components no longer need to know about or forward data they don't use.
- **Cleaner component APIs** — components only receive the props they actually need.
- **Centralized, shareable state** — ideal for data that many components across the tree need: theme, authenticated user, locale/language, feature flags, etc.
- **Simpler refactors** — adding a new consumer deep in the tree doesn't require modifying every component in between.

### When *not* to use Context
Context is best suited for data considered "global" to a section of the app (theme, auth, locale). For data only shared between a few closely related components, regular props are often simpler and keep data flow more explicit/traceable.

---

## Working with createContext()

`createContext()` is the function used to create a new Context object.

### Step 1 — Create the context

```javascript
import { createContext } from 'react';

const ThemeContext = createContext('light');

export default ThemeContext;
```

The argument passed (`'light'` here) is the **default value** — used only if a component consumes the context without any matching `Provider` above it in the tree.

### Step 2 — Provide the value

Wrap the part of your component tree that needs access with `<Context.Provider>`, and supply the actual value via the `value` prop:

```javascript
import ThemeContext from './ThemeContext';
import { useState } from 'react';

function App() {
    const [theme, setTheme] = useState('light');

    return (
        <ThemeContext.Provider value={theme}>
            <select onChange={(e) => setTheme(e.target.value)}>
                <option value='light'>Light</option>
                <option value='dark'>Dark</option>
            </select>
            <EmployeesList employees={Employees} />
        </ThemeContext.Provider>
    );
}
```

Any component nested inside this `Provider` — regardless of depth — can now access `theme`, without it being passed down as a prop at every level.

### Step 3 — Consume the value

**In function components**, use the `useContext()` Hook:

```javascript
import { useContext } from 'react';
import ThemeContext from './ThemeContext';

function EmployeeCard(props) {
    const theme = useContext(ThemeContext);

    return (
        <div>
            <a href="#" className={theme}>Edit</a>
            <a href="#" className={theme}>Delete</a>
        </div>
    );
}
```

**In class components**, use `static contextType` instead, then access the value via `this.context`:

```javascript
class EmployeeCard extends React.Component {
    static contextType = ThemeContext;

    render() {
        const theme = this.context;
        return (
            <div>
                <a href="#" className={theme}>Edit</a>
            </div>
        );
    }
}
```

### Key points
- Only components **inside** the `Provider` can access the context value via `useContext`/`contextType`.
- When the `Provider`'s `value` changes (e.g., `theme` state updates), **every consuming component automatically re-renders** with the new value — no manual prop updates needed anywhere in between.
- Intermediate components (like `EmployeesList` in the example above) require **zero changes** to let context pass through them — they simply don't mention it at all.

---

## Types of Router Components

*(Recap from React Router — included here per the lab's listed objectives.)*

| Router Type | Use Case |
|---|---|
| `BrowserRouter` | Standard choice for web apps; uses the HTML5 History API for clean URLs. |
| `HashRouter` | Uses a URL hash (`/#/path`) for environments without server-side URL rewrite support. |
| `MemoryRouter` | Keeps routing history in memory; used for testing or non-browser environments. |
| `StaticRouter` | Used for server-side rendering (SSR), where the route comes from the incoming request. |

---

## 📝 Summary

- **Context API** solves prop drilling by letting data be shared across a component tree without passing it through every intermediate component.
- **`createContext()`** creates the context object, with an optional default value.
- **`<Context.Provider value={...}>`** supplies the actual value to all descendants.
- **`useContext()`** (function components) or **`static contextType`** (class components) is how descendants read that value.
- Context updates automatically propagate to all consumers, triggering re-renders wherever the value is used.