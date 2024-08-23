import React, { useState, useEffect } from "react";
import Card from "../components/CourseCard";
import Navbar from "../components/Navbar";
import { useUser } from "../context/UserContext";
import { useNavigate } from "react-router-dom";

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
  const navigate = useNavigate();
  const userContext = useUser();

  if( !userContext ){
    return <div>Loading...</div>;
  }

  const { user } = userContext;

  useEffect(() => {
    if( !user ) {
      navigate("/login");
    }
  }, [ user ])

  useEffect(() => {
    if( !user ) return;
    // Fetch the courses from the backend when the component mounts
    // Replace with actual endpoint to fetch courses the student is registered in
    // fetch("http://localhost:5236/api/student/courses")
    //   .then((response) => response.json())
    //   .then((data) => setCourses(data))
    //   .catch((error) => console.error("Error fetching courses:", error));

    // Use dummy data before merging backend branch
    setCourses([
      {
        id: 1,
        name: "Introduction to Programming",
        description:
          "In this course, students learn fundamentals of Java programming within WPILib and obtain widely applicable \
          skills in programming that they can transfer to industry credentials. Students will learn fundamental \
          programming concepts such as methods, objects, conditionals, loops, arrays, command-based programming, \
          errors, and troubleshooting. Students apply their knowledge to programming a robot that completes an \
          obstacle course with feedback checkpoints. This course enables students to complete tasks with the XRP \
          robot as well as the Romi robot. In the second semester, students further their knowledge to prepare for the \
          Java SE 8 Programmer Exam or an AP Computer Science Exam using external courses.",
        category: "Computer Science",
        isRegistered: true,
        sectionID: 1001,
      },
      {
        id: 2,
        name: "Introduction to Statistic",
        description:
          "In our digital world, data-driven decision-making is becoming more common and more expected. Effective \
          leadership and communication, therefore, often hinges on the ability to acquire, manage, analyze, and display \
          large, quantitative data sets. Even many entry-level jobs assume or require basic knowledge of data analytics. \
          This online data analytics course introduces students to important concepts in data analytics across a wide \
          range of applications using the programming language R. Students complete the course with a clear understanding \
          of how to utilize quantitative data in real-time problem identification, decision-making, and problem-solving. \
          No prerequisites in statistics or math are required.",
        category: "Data Analytics",
        isRegistered: false,
        sectionID: 1002,
      },
      {
        id: 3,
        name: "Introduction to Statistic",
        description: "...",
        category: "Data Analytics",
        isRegistered: false,
        sectionID: 1002,
      },
    ]);
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
              ? {
                  ...course,
                  isRegistered: true,
                  sectionID: /* Update with actual section ID */ null,
                }
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
    <div className="min-h-screen h-full flex flex-col">
      <Navbar />
      <div className="mx-8 mb-8 h-full shadow-xl rounded-2xl px-16 py-6 bg-white grow">
        <div className="py-12 text-center text-3xl font-medium leading-normal tracking-tight text-gray-900">
          My Courses
        </div>
        <div className="mx-auto max-w-3xl bg-gray-50">
          {courses.map((course) => (
            <Card
              key={course.id}
              course={course}
              onRegister={handleRegister}
              onDrop={handleDrop}
            />
          ))}
        </div>
      </div>
    </div>
  );
};

export default MyCoursesPage;
