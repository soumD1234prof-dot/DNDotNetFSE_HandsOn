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

# React Fundamentals: JSX & Rendering Essentials

## 🎯 Objectives

By exploring this repository and its examples, you will be able to:
- [x] Define **JSX**
- [x] Explain **ECMAScript** and its role in modern JS/React
- [x] Explain `React.createElement()`
- [x] Explain how to create React nodes with **JSX**
- [x] Define how to render **JSX to the DOM**
- [x] Explain how to use **JavaScript expressions** in JSX
- [x] Explain how to apply **inline CSS** in JSX

---

## 📚 Key Concepts & Explanations

### 1. What is ECMAScript?
**ECMAScript (ES)** is the standard specification upon which JavaScript is built. Standardized by ECMA International (TC39 committee), it defines the language's syntax, types, statements, and core features. 
* Modern React heavily relies on ECMAScript standard updates such as **ES6+** (arrow functions, modules, classes, destructuring, and template literals).
* Transpilers like **Babel** take modern ECMAScript/JSX code and convert it into backward-compatible JavaScript for older browsers.

---

### 2. What is JSX?
**JSX** stands for **JavaScript XML**. It is a syntax extension for JavaScript that allows you to write HTML-like markup directly inside a JavaScript file.

* **Why JSX?** It keeps visual UI structure and rendering logic together inside component files.
* **Syntax Rule:** JSX must return a single parent element (or a Fragment `<>...</>`). All tags must be explicitly closed (e.g., `<img />`, `<br />`).

---

### 3. Creating React Nodes: `React.createElement()` vs JSX

Under the hood, JSX is just **syntactic sugar** over `React.createElement()`.

#### Low-Level Syntax (`React.createElement`)
```javascript
import React from 'react';

// Signature: React.createElement(type, [props], [...children])
const element = React.createElement(
  'h1',
  { className: 'title' },
  'Hello, React!'
);
```

#### JSX Equivalent
```jsx
// Babel compiles this directly into the React.createElement() code above
const element = <h1 className="title">Hello, React!</h1>;
```

---

### 4. Rendering JSX to the DOM

To render JSX elements into the browser's Document Object Model (DOM), React 18+ uses the `createRoot` API from `react-dom/client`.

```jsx
import React from 'react';
import ReactDOM from 'react-dom/client';

// 1. Target the root HTML element
const container = document.getElementById('root');

// 2. Create a React root
const root = ReactDOM.createRoot(container);

// 3. Render JSX content
const App = () => <h1>Welcome to My React App</h1>;

root.render(<App />);
```

---

### 5. Using JavaScript Expressions in JSX

You can embed any valid JavaScript expression inside JSX by wrapping it in **curly braces `{}`**.

#### Examples:
```jsx
const user = {
  firstName: 'Priya',
  lastName: 'Sharma'
};

const formatName = (u) => `${u.firstName} ${u.lastName}`;
const isLoggedIn = true;

const UserCard = () => {
  return (
    <div>
      {/* Variable & Function Evaluation */}
      <h2>User: {formatName(user)}</h2>
      
      {/* Mathematical Operations */}
      <p>Next Year Age: {21 + 1}</p>

      {/* Ternary Operators for Conditional Rendering */}
      <p>Status: {isLoggedIn ? 'Active Member' : 'Guest'}</p>
    </div>
  );
};
```

---

### 6. Applying Inline CSS in JSX

Inline styles in JSX are written as **JavaScript objects** rather than traditional CSS strings.

* Property names use **camelCase** (e.g., `background-color` becomes `backgroundColor`).
* Numeric values without units default to pixels (`px`).
* Double curly braces `style={{ ... }}` are used: outer braces for the JS expression context, inner braces for the object literal.

#### Example:
```jsx
const CardStyle = () => {
  const customStyle = {
    color: '#ffffff',
    backgroundColor: '#1E293B',
    padding: '16px',
    borderRadius: '8px',
    fontSize: '18px'
  };

  return (
    <div>
      {/* Using an external style object */}
      <div style={customStyle}>
        Card with Object Styling
      </div>

      {/* Direct inline object declaration */}
      <p style={{ color: '#2563EB', fontWeight: 'bold', marginTop: '10px' }}>
        Direct Inline Styled Text
      </p>
    </div>
  );
};
```

---