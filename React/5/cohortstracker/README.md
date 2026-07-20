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

# Styling React Components
 
A guide to why component styling matters in React, and two common approaches: **CSS Modules** and **inline styles**.
 
## 📚 Table of Contents
 
- [The Need for Styling React Components](#the-need-for-styling-react-components)
- [Ways to Style React Components](#ways-to-style-react-components)
- [CSS Modules](#css-modules)
- [Inline Styles](#inline-styles)
- [CSS Modules vs Inline Styles](#css-modules-vs-inline-styles)
- [Hands-On Example](#hands-on-example)
---
 
## The Need for Styling React Components
 
React is responsible for building the *structure* and *behavior* of a UI, but structure alone doesn't make an application usable or pleasant — **styling** is what turns raw markup into a polished, readable, and intuitive interface.
 
### Why styling matters in a component-based architecture
 
- **Visual clarity** — spacing, borders, colors, and typography help users quickly understand and navigate information (e.g., distinguishing separate cards, sections, or states).
- **Conveying state visually** — styling can reflect dynamic data at a glance (e.g., a status shown in green for "Ongoing" vs. blue for "Scheduled"), reducing the need to read every word.
- **Component reusability** — since React apps are built from independent, reusable components, each component ideally carries its *own* styling — so it looks and behaves consistently wherever it's used, without depending on global CSS rules that could conflict.
- **Avoiding style collisions** — in larger apps with many components, plain global CSS class names can easily clash between files (e.g., two different components both defining a `.title` class). React-specific styling approaches help prevent this.
- **Maintainability** — keeping styles scoped and organized alongside their components makes it easier to update, debug, and reason about UI changes without unintended side effects elsewhere in the app.
---
 
## Ways to Style React Components
 
There are several common approaches to styling in React:
 
1. **Plain CSS files** — traditional global stylesheets imported into components.
2. **CSS Modules** — CSS files scoped locally to a single component.
3. **Inline styles** — styles written directly in JSX using JavaScript objects.
4. **CSS-in-JS libraries** — e.g., styled-components, Emotion (not covered here).
This guide focuses on the two most commonly taught first: **CSS Modules** and **inline styles**.
 
---
 
## CSS Modules
 
A **CSS Module** is a CSS file where all class names are scoped **locally** to the component that imports it, rather than applying globally across the whole app. This is achieved by naming the file with a `.module.css` extension.
 
### Why use CSS Modules
- Prevents class name collisions between components.
- Keeps styling colocated with the component it belongs to.
- Still lets you write plain, familiar CSS syntax.
### Example
 
**`CohortDetails.module.css`**
```css
.box {
  width: 300px;
  display: inline-block;
  margin: 10px;
  padding: 10px 20px;
  border: 1px solid black;
  border-radius: 10px;
}
 
dt {
  font-weight: 500;
}
```
 
**`CohortDetails.js`**
```javascript
import styles from './CohortDetails.module.css';
 
function CohortDetails(props) {
  return (
    <div className={styles.box}>
      {/* content */}
    </div>
  );
}
```
 
**Key points:**
- Import the CSS Module as a JavaScript object: `import styles from './File.module.css'`.
- Reference class names as properties on that object: `className={styles.box}`, not `className="box"`.
- Behind the scenes, React/Webpack generates a unique class name (e.g., `box__a1b2c`) to guarantee it won't clash with any other `.box` class elsewhere in the app.
- Tag selectors (like `dt` in the example above) are **not** scoped the same way — they still apply globally to that tag wherever it's rendered within the imported file's usage.
---
 
## Inline Styles
 
**Inline styles** in React are written directly on an element using the `style` attribute — but unlike plain HTML, React expects a **JavaScript object**, not a string.
 
### Syntax rules
- Use double curly braces: `style={{ ... }}` — the outer braces mark it as a JS expression, the inner braces define the object.
- Property names are written in **camelCase** (e.g., `backgroundColor`, not `background-color`).
- Values are typically strings (e.g., `'red'`), except for unitless numeric CSS properties.
### Example
 
```javascript
<h3 style={{ color: 'green' }}>Ongoing</h3>
```
 
### Conditional inline styles
 
Inline styles are especially useful for styles that depend on dynamic data, such as component state or props:
 
```javascript
<h3 style={{ color: status === 'Ongoing' ? 'green' : 'blue' }}>
  {status}
</h3>
```
 
Here, the color changes automatically based on the value of `status` — something that's awkward to express with static CSS classes alone.
 
---
 
## CSS Modules vs Inline Styles
 
| Aspect | CSS Modules | Inline Styles |
|---|---|---|
| **Syntax** | Standard CSS syntax | JavaScript object syntax |
| **Scoping** | Automatically scoped per component | Scoped by nature (applied per element) |
| **Reusability** | Classes can be reused across the file | Must be repeated or extracted into variables |
| **Pseudo-classes/media queries** | Fully supported (`:hover`, `@media`, etc.) | Not supported directly |
| **Best for** | Static, reusable styling (layout, borders, spacing) | Dynamic, data-driven styling (conditional colors, computed values) |
| **Performance** | Styles loaded once as CSS | Recalculated on every render |
 
**Rule of thumb:** use CSS Modules for most static styling, and reach for inline styles when a value needs to change based on component logic (state/props) at runtime.
 
---
 
## Hands-On Example
 
A quick end-to-end example combining both approaches, based on a "Cohort Details" card component:
 
```javascript
import styles from './CohortDetails.module.css';
 
function CohortDetails(props) {
  return (
    <div className={styles.box}>
      <h3 style={{ color: props.cohort.currentStatus === 'Ongoing' ? 'green' : 'blue' }}>
        {props.cohort.cohortCode} - <span>{props.cohort.technology}</span>
      </h3>
      <dl>
        <dt>Started On</dt>
        <dd>{props.cohort.startDate}</dd>
        <dt>Current Status</dt>
        <dd>{props.cohort.currentStatus}</dd>
        <dt>Coach</dt>
        <dd>{props.cohort.coachName}</dd>
        <dt>Trainer</dt>
        <dd>{props.cohort.trainerName}</dd>
      </dl>
    </div>
  );
}
 
export default CohortDetails;
```
 
```css
/* CohortDetails.module.css */
.box {
  width: 300px;
  display: inline-block;
  margin: 10px;
  padding: 10px 20px;
  border: 1px solid black;
  border-radius: 10px;
}
 
dt {
  font-weight: 500;
}
```
 
This demonstrates the typical split: **structural/static styling** (box borders, spacing, bold labels) lives in the CSS Module, while **dynamic, data-dependent styling** (status color) is handled inline.