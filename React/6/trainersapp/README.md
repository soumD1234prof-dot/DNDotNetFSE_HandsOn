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

# React Router Fundamentals

A guide to client-side routing in React using **React Router** — why it's needed, its core components, the types of router components available, and how to pass parameters via the URL.

## 📚 Table of Contents

- [The Need and Benefits of React Router](#the-need-and-benefits-of-react-router)
- [Components in React Router](#components-in-react-router)
- [Types of Router Components](#types-of-router-components)
- [Parameter Passing via URL](#parameter-passing-via-url)
- [Putting It All Together](#putting-it-all-together)

---

## The Need and Benefits of React Router

React by itself has no built-in concept of "pages" or "URLs" — a plain React app is a **Single-Page Application (SPA)** that renders everything on one HTML page, with no native way to show different views for different URLs.

**React Router** solves this by providing client-side routing: it lets you map different URL paths to different components, all without triggering a full page reload from the server.

### Why it's needed
- SPAs need a way to simulate multi-page navigation (different views, different URLs) while keeping the SPA's performance benefits.
- Without it, you'd have no way to deep-link to a specific view (e.g., share a link directly to one trainer's detail page).
- Browser back/forward buttons need to work meaningfully, tied to what's currently displayed.

### Benefits
- **No full page reloads** — navigation feels instant, since only the relevant component swaps out; the rest of the page (e.g., a nav bar) stays untouched.
- **Bookmarkable, shareable URLs** — each view can have its own distinct URL, even though it's technically all one page.
- **Declarative routing** — routes are defined as React components (`<Route>`), fitting naturally into React's component-based mental model.
- **Dynamic, parameterized routes** — supports patterns like `/trainers/:id`, so the same component can render different content based on the URL.
- **Nested and conditional rendering** — routes can be nested, protected, or conditionally rendered based on app state (e.g., authentication).

---

## Components in React Router

React Router (v6) provides several core components that work together to enable routing:

| Component | Purpose |
|---|---|
| `<BrowserRouter>` | Wraps the entire app; enables client-side routing using the HTML5 History API (clean URLs, no `#`). |
| `<Routes>` | A container that holds all individual `<Route>` definitions; renders the first matching route. |
| `<Route>` | Defines a single mapping between a URL `path` and the `element` (component) to render. |
| `<Link>` | Renders a navigable link (like `<a>`), but without triggering a full page reload. |
| `<NavLink>` | Similar to `<Link>`, but automatically applies styling/classes when the link matches the current URL — useful for highlighting active nav items. |
| `<Navigate>` | Programmatically redirects to a different route (e.g., after a form submission or failed auth check). |
| `<Outlet>` | Used in nested routing; renders the matched child route within a parent route's layout. |

**Basic example:**

```javascript
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import Home from './Home';
import TrainersList from './Trainerlist';

function App() {
    return (
        <BrowserRouter>
            <nav>
                <Link to="/">Home</Link> | <Link to="/trainers">Show Trainers</Link>
            </nav>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/trainers" element={<TrainersList />} />
            </Routes>
        </BrowserRouter>
    );
}
```

---

## Types of Router Components

React Router offers a few different **router** implementations, each suited to different environments:

| Router Type | Use Case |
|---|---|
| `BrowserRouter` | The most common choice for web apps. Uses the HTML5 History API for clean URLs (e.g., `/trainers/1`). Requires server configuration to handle direct URL access/refresh correctly. |
| `HashRouter` | Uses a URL hash (e.g., `/#/trainers/1`) to simulate routing. Useful when you can't configure the server (e.g., static file hosting without URL rewrite rules). |
| `MemoryRouter` | Keeps the routing history in memory instead of the browser's address bar. Commonly used for testing, or non-browser environments (e.g., React Native). |
| `StaticRouter` | Used for server-side rendering (SSR), where the route is determined by the incoming request rather than browser navigation. |

For most standard web apps (like a typical create-react-app project), **`BrowserRouter`** is the default and recommended choice.

---

## Parameter Passing via URL

React Router allows dynamic segments in a route's path, letting the same component render different data based on what's in the URL.

### Defining a dynamic route

Use a colon (`:`) prefix in the path to mark a segment as a parameter:

```javascript
<Route path="/trainers/:id" element={<TrainerDetail />} />
```

Here, `:id` is a placeholder — it will match any value in that position of the URL (e.g., `/trainers/t-syed8`, `/trainers/t-jojo`, etc.).

### Linking with a parameter

```javascript
<Link to={`/trainers/${trainer.trainerId}`}>{trainer.name}</Link>
```

### Reading the parameter — the `useParams` hook

Inside the component rendered by that route, use the `useParams()` hook to access the value:

```javascript
import { useParams } from 'react-router-dom';
import trainersMock from './TrainersMock';

function TrainerDetail() {
    const { id } = useParams();
    const trainer = trainersMock.find(t => t.trainerId === id);

    if (!trainer) {
        return <p>Trainer not found</p>;
    }

    return (
        <div>
            <h3>Trainers Details</h3>
            <p><strong>{trainer.name} ({trainer.technology})</strong></p>
            <p>{trainer.email}</p>
            <p>{trainer.phone}</p>
            <ul>
                {trainer.skills.map((skill, index) => (
                    <li key={index}>{skill}</li>
                ))}
            </ul>
        </div>
    );
}

export default TrainerDetail;
```

**Important:** `useParams()` always returns values as **strings**, regardless of what type the data looks like. If the actual IDs are string-based (e.g., `'t-syed8'`), compare directly with `===`. Only convert with `Number()` or `parseInt()` if the underlying data genuinely uses numeric IDs — otherwise, `parseInt('t-syed8')` returns `NaN` and the match will always fail.

---

## Putting It All Together

A minimal end-to-end routing setup, combining static and dynamic routes:

```javascript
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import Home from './Home';
import TrainersList from './Trainerlist';
import TrainerDetail from './TrainerDetails';
import trainersMock from './TrainersMock';

function App() {
    return (
        <BrowserRouter>
            <h1>My Academy Trainers App</h1>
            <nav>
                <Link to="/">Home</Link> | <Link to="/trainers">Show Trainers</Link>
            </nav>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/trainers" element={<TrainersList trainers={trainersMock} />} />
                <Route path="/trainers/:id" element={<TrainerDetail />} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;
```

**Flow summary:**
1. `/` → renders `Home`
2. `/trainers` → renders `TrainersList`, showing clickable trainer names
3. Clicking a name navigates to `/trainers/:id` → renders `TrainerDetail`, which reads `id` via `useParams()` and looks up the matching trainer from mock data