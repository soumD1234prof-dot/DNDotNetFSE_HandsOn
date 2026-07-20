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

# React Fundamentals: Conditional Rendering

---

## 🎯 Objectives

By exploring this repository and its examples, you will be able to:
- [x] Explain conditional rendering in React
- [x] Define element variables
- [x] Explain how to prevent components from rendering

---

## 📚 Key Concepts & Explanations

### 1. Conditional Rendering in React
Conditional rendering in React works the same way conditions work in standard JavaScript. You use JavaScript operators to create elements representing the current state, and let React update the UI to match them.

#### Common Approaches:

#### A. `if / else` Statements
Best suited for top-level logic outside the returned JSX block.

```jsx
function Greeting({ isLoggedIn }) {
  if (isLoggedIn) {
    return <h1>Welcome back, User!</h1>;
  }
  return <h1>Please sign in to continue.</h1>;
}
```

#### B. Inline Ternary Operator (`condition ? true : false`)
Ideal for compact conditional output directly inside JSX expressions.

```jsx
function StatusBadge({ isOnline }) {
  return (
    <span className={isOnline ? 'badge-green' : 'badge-gray'}>
      {isOnline ? 'Online' : 'Offline'}
    </span>
  );
}
```

#### C. Logical AND Operator (`&&`)
Used for short-circuit evaluation when you want to render something only if a condition is `true`, and render nothing if `false`.

```jsx
function Mailbox({ unreadMessages }) {
  return (
    <div>
      <h2>Inbox</h2>
      {unreadMessages.length > 0 && (
        <p>You have {unreadMessages.length} unread messages.</p>
      )}
    </div>
  );
}
```
> ⚠️ **Caution with `&&`:** Ensure the left side evaluates to a boolean (e.g., `length > 0` instead of just `length`), otherwise `0` will be rendered to the DOM instead of nothing.

---

### 2. Element Variables
**Element variables** allow you to store React elements (JSX) inside standard JavaScript variables. This helps keep your main `return` statement clean and readable when handling complex conditional logic.

#### Example:
```jsx
import React, { useState } from 'react';

function LoginControl() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  // Declare an element variable
  let button;

  if (isLoggedIn) {
    button = <button onClick={() => setIsLoggedIn(false)}>Logout</button>;
  } else {
    button = <button onClick={() => setIsLoggedIn(true)}>Login</button>;
  }

  return (
    <div>
      <header>
        <h1>Dashboard</h1>
      </header>
      {/* Render the stored JSX element */}
      {button}
    </div>
  );
}

export default LoginControl;
```

---

### 3. Preventing Components from Rendering
In rare cases, you might want a component to hide itself even though it was rendered by a parent component. To do this, return `null` from its render function instead of returning JSX markup.

#### Example (Warning Banner):
```jsx
function WarningBanner({ warn }) {
  // Prevent rendering if warn prop is false
  if (!warn) {
    return null;
  }

  return (
    <div className="warning-box">
      ⚠️ Warning: Unsaved changes will be lost!
    </div>
  );
}

function Page() {
  const [showWarning, setShowWarning] = useState(true);

  return (
    <div>
      <WarningBanner warn={showWarning} />
      <button onClick={() => setShowWarning(!showWarning)}>
        {showWarning ? 'Hide Warning' : 'Show Warning'}
      </button>
    </div>
  );
}
```

#### Important Notes on Returning `null`:
* Returning `null` from a component’s `render` function does **not** affect its lifecycle methods or hooks (e.g., `useEffect` will still run).
* It simply instructs React not to paint any visual nodes to the DOM for that component.

---