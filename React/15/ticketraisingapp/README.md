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

# Complaint Register - React Forms Demo

A simple React application to demonstrate **Form Handling** using Controlled Components.

---

## 🎯 Learning Objectives

- Explain about **React Forms**
- Define **Controlled Components**
- Explain about various **Input Controls**
- Explain about **Handling Forms** in React
- Explain about **Submitting Forms**

---

## 📝 Features

- Form with Name (Text Input) and Complaint (Textarea)
- Controlled Components using `useState` / `this.state`
- Form submission with validation simulation
- Generates a random Transaction ID
- User-friendly alert message after submission

---

## 🧠 What You Will Learn

### 1. React Forms
Unlike traditional HTML forms, React forms are usually **controlled** by React state.

### 2. Controlled Components
A controlled component is a form element whose value is controlled by React state.

```jsx
<input
  type="text"
  name="ename"
  value={this.state.ename}    // Controlled by state
  onChange={this.handleChange}
/>
```

### 3. Various Input Controls
- `<input type="text">` -> Single line text
- `<textarea>` -> Multi-line text input
- `<button type="submit">` -> Form submission

### 4. Handling Forms
- `onChange` handler updates state as user types
- `handleChange` uses computed property name: `[event.target.name]`

### 5. Submitting Forms
- `onSubmit` on the `<form>` element
- `event.preventDefault()` to prevent page reload
- Process data (show alert, generate reference number, etc.)