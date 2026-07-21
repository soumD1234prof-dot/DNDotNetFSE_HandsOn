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


# React Fundamentals: Form Handling & Validation

## 🎯 Objectives

By exploring this repository and its examples, you will be able to:
- [x] Explain **React Forms validation**
- [x] Identify the differences between a **React Form** and an **HTML Form**
- [x] Explain **controlled components**
- [x] Identify various **React Form input controls**
- [x] Explain how to **handle React Forms**
- [x] Explain about **submitting forms** in React

---

## 📚 Key Concepts & Explanations

### 1. Differences Between React Forms and Traditional HTML Forms

| Feature | HTML Form | React Form (Controlled) |
| :--- | :--- | :--- |
| **State Owner** | The browser DOM | The React Component State |
| **Data Retrieval** | On form submission via DOM element values | Real-time synchronization via state (`useState` / `this.state`) |
| **Page Behavior** | Default action reloads or navigates to a new URL | Prevented with `e.preventDefault()`, allowing Single Page Application (SPA) behavior |
| **Validation** | Native browser constraints on submit | Custom JS/React logic in real time or on submit |

---

### 2. Controlled Components

A **Controlled Component** is an input element whose value is entirely driven by React state. 

Instead of letting the DOM maintain the input's internal value, React state serves as the **"single source of truth."**

#### Mechanics:
1. The `value` prop is bound to a state variable.
2. The `onChange` event listener triggers a state update as the user types.
3. The UI re-renders with the newly updated state value.

```jsx
import React, { useState } from 'react';

function ControlledInput() {
  const [name, setName] = useState('');

  return (
    <input
      type="text"
      value={name}                           // Bound to React state
      onChange={(e) => setName(e.target.value)} // State updated on every keystroke
    />
  );
}
```

---

### 3. Various React Form Input Controls

React manages all standard HTML form input controls using controlled components:

* **Text Inputs (`<input type="text">`):** Value bound to string state.
* **Textarea (`<textarea>`):** Uses a `value` prop directly (unlike traditional HTML where children `<textarea>text</textarea>` are used).
* **Select Dropdowns (`<select>`):** Uses a `value` prop on the parent `<select>` tag matching the selected `<option>` value.
* **Checkboxes (`<input type="checkbox">`):** Bound using the `checked` boolean prop instead of `value`.
* **Radio Buttons (`<input type="radio">`):** Grouped by `name`, checked state determined by comparing value to current state.

```jsx
// Examples of handling different controls
const [formData, setFormData] = useState({
  bio: '',
  role: 'developer',
  subscribe: false
});

// Textarea
<textarea value={formData.bio} onChange={handleChange} name="bio" />

// Select
<select value={formData.role} onChange={handleChange} name="role">
  <option value="developer">Developer</option>
  <option value="designer">Designer</option>
</select>

// Checkbox
<input
  type="checkbox"
  checked={formData.subscribe}
  onChange={(e) => setFormData({ ...formData, subscribe: e.target.checked })}
/>
```

---

### 4. Handling React Forms

To handle forms efficiently—especially when dealing with multiple input fields—use a single unified handler function with **computed property names** (`[event.target.name]`).

```jsx
import React, { useState } from 'react';

function RegistrationForm() {
  const [formData, setFormData] = useState({
    username: '',
    email: '',
    password: ''
  });

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    
    setFormData((prevData) => ({
      ...prevData,
      [name]: type === 'checkbox' ? checked : value
    }));
  };

  return (
    <form>
      <input name="username" value={formData.username} onChange={handleChange} />
      <input name="email" value={formData.email} onChange={handleChange} />
      <input type="password" name="password" value={formData.password} onChange={handleChange} />
    </form>
  );
}
```

---

### 5. Submitting Forms in React

Form submission in React is handled by attaching an `onSubmit` event handler to the `<form>` tag.

#### Essential Submission Steps:
1. **Prevent Default Browser Reload:** Call `e.preventDefault()` inside the submit handler.
2. **Access Form Data:** Read directly from state (no DOM querying required).
3. **Execute Logic:** Send API payload, reset form, or display feedback.

```jsx
const handleSubmit = (e) => {
  e.preventDefault(); // Stop full page reload

  console.log('Submitted Data:', formData);
  
  // Example API call simulation
  // fetch('/api/register', { method: 'POST', body: JSON.stringify(formData) });
};

return <form onSubmit={handleSubmit}>...</form>;
```

---

### 6. React Forms Validation

Validation ensures user input meets specific formatting and security criteria before processing.

#### Validation Strategies:

1. **Real-time (On Change) Validation:** Validates inputs dynamically as the user types and displays errors immediately.
2. **On Blur Validation:** Validates an input field when the user leaves/clicks away from it (`onBlur`).
3. **On Submit Validation:** Validates all fields when the user submits the form; stops submission if errors exist.

#### Custom Validation Example:
```jsx
import React, { useState } from 'react';

function ValidatedForm() {
  const [email, setEmail] = useState('');
  const [error, setError] = useState('');

  const validateEmail = (val) => {
    if (!val) {
      return 'Email is required!';
    } else if (!/\S+@\S+\.\S+/.test(val)) {
      return 'Invalid email format!';
    }
    return '';
  };

  const handleChange = (e) => {
    const value = e.target.value;
    setEmail(value);
    setError(validateEmail(value));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const validationError = validateEmail(email);
    if (validationError) {
      setError(validationError);
      return;
    }
    alert('Form submitted successfully!');
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>Email:</label>
      <input type="text" value={email} onChange={handleChange} />
      {error && <p style={{ color: 'red' }}>{error}</p>}
      
      <button type="submit">Submit</button>
    </form>
  );
}
```