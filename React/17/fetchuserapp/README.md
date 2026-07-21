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

# React Fundamentals: Consuming REST APIs

---

## 🎯 Objectives

By exploring this repository and its examples, you will be able to:
- [x] Explain how to **consume REST APIs** from React applications
- [x] Handle **loading**, **success**, and **error states** during asynchronous requests
- [x] Compare API consumption in **Class Components** (`componentDidMount`) vs. **Functional Components** (`useEffect`)
- [x] Utilize both the native **`fetch()` API** and third-party libraries like **`axios`**

---

## 📚 Key Concepts & Explanations

### 1. What is a REST API?
A **REST (Representational State Transfer) API** allows front-end applications like React to communicate with back-end servers over HTTP. React applications send HTTP requests (e.g., `GET`, `POST`, `PUT`, `DELETE`) to specific API endpoints and receive data back, typically in JSON format.

---

### 2. Core Approaches to Fetching Data in React

#### A. Native JavaScript `fetch()` API
The `fetch()` function is built into modern browsers and returns a Promise.

```javascript
fetch('https://api.example.com/data')
  .then(response => response.json())
  .then(data => console.log(data))
  .catch(error => console.error('Error fetching data:', error));
```

#### B. Axios Library
`axios` is a popular promise-based HTTP client. It automatically transforms JSON responses and provides straightforward error handling for HTTP status codes out of the box.

```bash
npm install axios
```

---

### 3. Consuming REST APIs in Functional Components (Using `useEffect`)

In modern React, the `useEffect` hook is used to perform side effects, such as fetching data when a component mounts.

#### Example using `fetch` + `async/await`:
```jsx
import React, { useState, useEffect } from 'react';

function UserProfile() {
  const [user, setUser] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchUserData = async () => {
      try {
        setLoading(true);
        const response = await fetch('https://api.randomuser.me/');
        
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const data = await response.json();
        setUser(data.results[0]);
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };

    fetchUserData();
  }, []); // Empty dependency array ensures this runs once when component mounts

  if (loading) return <p>Loading user details...</p>;
  if (error) return <p style={{ color: 'red' }}>Error: {error}</p>;

  return (
    <div>
      <h2>{user.name.title} {user.name.first} {user.name.last}</h2>
      <img src={user.picture.large} alt="Profile" />
    </div>
  );
}

export default UserProfile;
```

---

### 4. Consuming REST APIs in Class Components (`componentDidMount`)

In class-based React components, asynchronous API calls are invoked inside the `componentDidMount()` lifecycle method.

```jsx
import React, { Component } from 'react';

class GetUser extends Component {
  constructor(props) {
    super(props);
    this.state = {
      person: null,
      loading: true,
      error: null
    };
  }

  async componentDidMount() {
    try {
      const url = "https://api.randomuser.me/";
      const response = await fetch(url);
      const data = await response.json();

      this.setState({ person: data.results[0], loading: false });
    } catch (err) {
      this.setState({ error: err.message, loading: false });
    }
  }

  render() {
    const { loading, person, error } = this.state;

    if (loading) return <div>Loading...</div>;
    if (error) return <div style={{ color: 'red' }}>{error}</div>;

    return (
      <div>
        <h2>{person.name.title} {person.name.first} {person.name.last}</h2>
        <img src={person.picture.large} alt="User" />
      </div>
    );
  }
}

export default GetUser;
```

---

### 5. Managing the Three Essential API States

Every robust API integration requires managing three primary states:
1. **Loading State:** Displays a spinner or text while data is being fetched over the network.
2. **Data / Success State:** Holds the retrieved JSON payload and renders the UI when the request succeeds.
3. **Error State:** Catches network failures, 4xx/5xx HTTP errors, and provides user feedback.

---

### 6. Best Practices for REST API Consumption in React

* **Handle Cleanups:** Use `AbortController` with `fetch` to cancel pending HTTP requests if a component unmounts before the request resolves.
* **Awareness of React 18 Strict Mode:** In development mode, `useEffect` and `componentDidMount` execute twice to help detect side effects, causing dual API calls in rapid succession.
* **Secure Environment Variables:** Never hardcode sensitive API keys in component files; store them in `.env` variables (e.g., `REACT_APP_API_KEY`).