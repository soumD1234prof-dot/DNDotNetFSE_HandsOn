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

# Event Examples App - React Event Handling

A simple React application to demonstrate various **event handling** techniques in React.

---

## 🎯 Objectives

- Explain **React Events**
- Explain **Event Handlers** in React
- Understand what a **Synthetic Event** is
- Learn **React Event Naming Convention**

---

## 📋 Features

- **Counter** with Increment & Decrement buttons
- Increment button demonstrates **multiple function calls**
- "Say Welcome" button – passes argument to function
- "Click on me" button – demonstrates **Synthetic Event**
- **Currency Converter** – Converts INR to Euro on form submit

---

## 🧠 What You Will Learn

### 1. React Events
React events are similar to HTML events but with some differences.  
Examples: `onClick`, `onChange`, `onSubmit`, etc.

### 2. Event Handlers
These are functions that get executed when an event occurs.

```jsx
<button onClick={increment}>Increment</button>
```

### 3. Synthetic Event
React wraps the native browser event into a **Synthetic Event**.  
This gives consistent behavior across all browsers.

```jsx
const handleClick = (e) => {
  console.log(e);        // Synthetic Event object
  alert("I was clicked");
};
```

### 4. React Event Naming Convention
- Uses **camelCase** instead of lowercase
- Examples:
  - `onclick` → `onClick`
  - `onchange` → `onChange`
  - `onsubmit` → `onSubmit`

---

## 📌 Key Code Examples

### Event Handler with Multiple Functions
```jsx
const increment = () => {
  setCount(prev => prev + 1);
  sayHello();        // Multiple methods called
};
```

### Passing Argument to Function
```jsx
<button onClick={() => sayWelcome("welcome")}>
  Say welcome
</button>
```

### Form Submit with Synthetic Event
```jsx
const handleSubmit = (e) => {
  e.preventDefault();     // Prevents page reload
  // ... conversion logic
};
```

---
