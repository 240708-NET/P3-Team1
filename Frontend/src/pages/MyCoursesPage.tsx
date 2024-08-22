import React, { useState, useEffect } from "react";
import Card from "../components/CourseCard"
import Navbar from "../components/Navbar";

interface Course {
  id: number;
  name: string;
  description: string;
  category: string;
  isRegistered: boolean;
  sectionID: number | null;
}

const MyCoursesPage: React.FC = () => {
  const [courses, setCourses] = useState<Course[]>([]);

  useEffect(() => {
    // Fetch the courses from the backend when the component mounts
    // Replace with actual endpoint to fetch courses the student is registered in
    fetch("http://localhost:5236/api/student/courses")
      .then((response) => response.json())
      .then((data) => setCourses(data))
      .catch((error) => console.error("Error fetching courses:", error));
  }, []);

  const handleRegister = (courseID: number) => {
    // Endpoint for registering a course
    // Replace with actual endpoint to register a course
    fetch(`http://localhost:5236/api/student/register/${courseID}`, {
      method: "POST",
    })
      .then(() => {
        // Update the UI after successful registration
        setCourses((prevCourses) =>
          prevCourses.map((course) =>
            course.id === courseID
              ? { ...course, isRegistered: true, sectionID: /* Update with actual section ID */ null }
              : course
          )
        );
      })
      .catch((error) => console.error("Error registering course:", error));
  };

  const handleDrop = (sectionID: number) => {
    // Endpoint for dropping a course
    // Replace with actual endpoint to drop a course
    fetch(`http://localhost:5236/api/student/drop/${sectionID}`, {
      method: "DELETE",
    })
      .then(() => {
        // Update the UI after successful drop
        setCourses((prevCourses) =>
          prevCourses.map((course) =>
            course.sectionID === sectionID
              ? { ...course, isRegistered: false, sectionID: null }
              : course
          )
        );
      })
      .catch((error) => console.error("Error dropping course:", error));
  };

  return (
    <div>
      <Navbar />
      <div className="min-h-screen flex items-center justify-center bg-orange-300">
        <div className="bg-white p-8 rounded-lg shadow-lg w-full max-w-md">
          <h2 className="text-2xl font-bold mb-6 text-center text-orange-600">My Courses</h2>
          <div className="space-y-4">
            {courses.map((course) => (
              <Card key={course.id} course={course} />
            ))}
          </div>
        </div>
      </div>
    </div>
  );
};

export default MyCoursesPage;
