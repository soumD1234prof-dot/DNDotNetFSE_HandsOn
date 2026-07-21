import './App.css';
import { books } from './books';
import { blogs } from './blogs';
import { courses } from './courses';

function App(props) {

    // Technique 1: Element variable (assign JSX to a variable, render with {})
    const bookdet = (
        <ul>
            {books.map((book) =>
                <div key={book.id}>
                    <h3> {book.bname}</h3>
                    <h4>{book.price}</h4>
                </div>
            )}
        </ul>
    );

    // Technique 2: if / else statement building a variable
    let content;
    if (blogs && blogs.length > 0) {
        content = (
            <ul>
                {blogs.map((blog) =>
                    <div key={blog.id}>
                        <h3>{blog.btitle}</h3>
                        <h4>{blog.author}</h4>
                        <p>{blog.content}</p>
                    </div>
                )}
            </ul>
        );
    } else {
        content = <p>No blogs available!!</p>;
    }

    // Technique 3: Ternary operator
    const coursedet = courses && courses.length > 0 ? (
        <ul>
            {courses.map((course) =>
                <div key={course.id}>
                    <h3>{course.cname}</h3>
                    <h4>{course.date}</h4>
                </div>
            )}
        </ul>
    ) : (
        <p>No courses available</p>
    );

    return (
        <div>
          <div className="flexrow">
              <div className="mystyle1">
                    <h1> Course Details</h1>
                    {coursedet}
                </div>
                <div className="st2">
                    <h1> Book Details</h1>
                    {bookdet}
                </div>
                <div className="v1">
                    <h1> Blog Details</h1>
                    {content}
                </div>
            </div>
        </div>
    );
}

export default App;