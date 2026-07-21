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

# Conditional Rendering, Lists & Keys in React

A guide to rendering logic in React — the different ways to conditionally show content, rendering multiple components together, working with list components, and understanding `key`s and the `map()` function.

## 📚 Table of Contents

- [Various Ways of Conditional Rendering](#various-ways-of-conditional-rendering)
- [Rendering Multiple Components](#rendering-multiple-components)
- [List Components](#list-components)
- [Keys in React Applications](#keys-in-react-applications)
- [Extracting Components with Keys](#extracting-components-with-keys)
- [React map() Function](#react-map-function)

---

## Various Ways of Conditional Rendering

**Conditional rendering** means displaying different UI depending on some condition — such as whether data exists, a flag is true, or a user is logged in. React doesn't have special syntax for this; it just uses plain JavaScript logic within JSX. There are several common patterns:

### 1. Element Variable
Assign JSX to a variable ahead of time, then render it with `{}`.

```javascript
const bookdet = (
    <ul>
        {books.map((book) => <li key={book.id}>{book.bname}</li>)}
    </ul>
);

return <div>{bookdet}</div>;
```

### 2. if / else Statement
Build up a variable using a full `if/else` block before the `return`.

```javascript
let content;
if (blogs && blogs.length > 0) {
    content = <ul>{blogs.map((blog) => <li key={blog.id}>{blog.btitle}</li>)}</ul>;
} else {
    content = <p>No blogs available!!</p>;
}
```

### 3. Ternary Operator
A compact one-line equivalent of if/else — commonly used directly inline in JSX.

```javascript
const coursedet = courses && courses.length > 0 ? (
    <ul>{courses.map((course) => <li key={course.id}>{course.cname}</li>)}</ul>
) : (
    <p>No courses available</p>
);
```

### 4. Logical && Operator
Renders content only if the condition is truthy; renders nothing (`false`, which React ignores) otherwise. Best for "show this OR show nothing" cases.

```javascript
{isLoggedIn && <h2>Welcome back!</h2>}
```

### 5. Preventing a Component from Rendering
Returning `null` from a component tells React to render nothing at all for it.

```javascript
function WarningBanner(props) {
    if (!props.show) {
        return null;
    }
    return <div className="warning">Warning!</div>;
}
```

**Choosing between them:** use the element-variable or if/else pattern for more complex, multi-branch logic; use the ternary for simple two-outcome cases; use `&&` when there's no "else" case at all.

---

## Rendering Multiple Components

React allows any number of components to be composed together within a single parent, simply by including them side-by-side in JSX (wrapped in one parent element):

```javascript
function App() {
    return (
        <div className="flexrow">
            <div className="mystyle1">
                <h1>Course Details</h1>
                {coursedet}
            </div>
            <div className="st2">
                <h1>Book Details</h1>
                {bookdet}
            </div>
            <div className="v1">
                <h1>Blog Details</h1>
                {content}
            </div>
        </div>
    );
}
```

Each section here is independently computed (via its own conditional rendering logic) and then combined into one final returned tree. This is the foundation of how larger React applications are built — small, independent pieces composed together into a full page.

---

## List Components

A **list component** is a component responsible for rendering a collection of items — typically by looping through an array and rendering one element (or sub-component) per item.

```javascript
function BookList(props) {
    return (
        <ul>
            {props.books.map((book) => (
                <li key={book.id}>
                    <h3>{book.bname}</h3>
                    <h4>{book.price}</h4>
                </li>
            ))}
        </ul>
    );
}
```

This pattern separates **data** (the array passed via props) from **presentation** (how each item is displayed), making the component reusable with any array of similarly-shaped data.

---

## Keys in React Applications

A **key** is a special string attribute you must include when creating a list of elements in React. Keys help React identify which items have changed, been added, or been removed between renders.

```javascript
{books.map((book) => (
    <div key={book.id}>
        <h3>{book.bname}</h3>
    </div>
))}
```

### Why keys are needed
- React uses keys to match elements in the new render with elements from the previous render, rather than blindly re-rendering the entire list.
- Without stable keys, React may re-render more than necessary, or — worse — mismatch state between list items when the list is reordered, filtered, or has items added/removed.

### Rules for good keys
- **Must be unique** among siblings (not necessarily globally unique across the whole app).
- **Should be stable** — ideally a unique ID from your data (e.g., `book.id`), not something that changes between renders.
- **Avoid using array index as a key** when the list can be reordered, filtered, or have items inserted/removed — this can cause subtle bugs with component state, since React matches by position rather than identity. Index-as-key is only safe for static lists that never change order.
- Keys are **not passed as props** to the component — they're used internally by React only, and aren't accessible via `props.key`.

---

## Extracting Components with Keys

When list rendering logic grows more complex, it's common to **extract** the per-item markup into its own separate component — but the `key` still needs to be placed correctly.

### Before extraction (inline)
```javascript
<ul>
    {books.map((book) => (
        <li key={book.id}>
            <h3>{book.bname}</h3>
            <h4>{book.price}</h4>
        </li>
    ))}
</ul>
```

### After extraction
```javascript
function BookItem({ book }) {
    return (
        <li>
            <h3>{book.bname}</h3>
            <h4>{book.price}</h4>
        </li>
    );
}

function BookList({ books }) {
    return (
        <ul>
            {books.map((book) => (
                <BookItem key={book.id} book={book} />
            ))}
        </ul>
    );
}
```

**Important rule:** the `key` must be placed on the element returned directly by the `.map()` call — in this case, `<BookItem key={book.id} ... />` — **not** on the `<li>` inside `BookItem`. React needs the key at the level where the list is actually being generated, not buried inside a child component.

---

## React map() Function

`.map()` is a built-in JavaScript array method — not something unique to React — but it's the standard, idiomatic way to transform an array of data into an array of JSX elements.

```javascript
const numbers = [1, 2, 3, 4];
const doubled = numbers.map((n) => n * 2);
// doubled = [2, 4, 6, 8]
```

Applied to JSX, each array item is transformed into a corresponding React element:

```javascript
{players.map((item) => (
    <li key={item.name}>Mr. {item.name} <span>{item.score}</span></li>
))}
```

### How it works
1. `.map()` iterates over every item in the source array.
2. For each item, the arrow function returns a piece of JSX.
3. The result is a **new array of JSX elements**, which React knows how to render directly when placed inside `{}`.
4. The original array (`players`) is never mutated — `.map()` always returns a brand-new array.

### Why map() (not a for loop) is preferred in JSX
- `.map()` is an **expression** (it returns a value), so it can be used directly inside `{}` in JSX.
- A traditional `for` loop is a **statement** and cannot be embedded directly inside JSX — it would need to build up an array separately beforehand.
- `.map()` keeps list-rendering logic concise and colocated with the JSX that displays it.

---

## 📝 Summary

- Conditional rendering can be done via element variables, if/else, ternaries, `&&`, or returning `null`.
- Multiple components are combined by simply nesting them inside a shared parent element.
- List components loop through arrays (typically via `.map()`) to render repeated UI.
- Every element in a list **must** have a unique, stable `key` — placed on the outermost element/component returned inside the `.map()` call.
- `.map()` is preferred over `for` loops for rendering lists because it's an expression that fits naturally inside JSX.