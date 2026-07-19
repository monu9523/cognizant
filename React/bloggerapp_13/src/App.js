import React from "react";
import CourseDetails from "./CourseDetails";
import BookDetails from "./BookDetails";
import BlogDetails from "./BlogDetails";
import "./App.css";

function App() {

    const showCourses = true;
    const showBooks = true;
    const showBlogs = true;

    return (
        <div className="container">

            {showCourses && <CourseDetails />}

            {showBooks && <BookDetails />}

            {showBlogs ? <BlogDetails /> : null}

        </div>
    );
}

export default App;