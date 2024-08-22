import React from "react";
import Card from "../components/CourseCard";

interface Course {
  id: number;
  name: string;
  description: string;
  category: string;
}

const MyCoursesPage: React.FC = () => {
  // Hardcoded courses for testing
  const courses: Course[] = [
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
        Java SE 8 Programmer Exam or an AP Computer Science Exam using external courses. ",
      category: "Computer Science",
    },
    {
      id: 2,
      name: "Calculus I",
      description: "A study of differential and integral calculus.",
      category: "Mathematics",
    },
    {
      id: 3,
      name: "World History",
      description: "Explore major events in world history.",
      category: "History",
    },
  ];

  return (
    <div className="min-h-screen flex items-center justify-center bg-orange-300">
      <div className="bg-white p-8 rounded-lg shadow-lg w-full max-w-md">
        <h2 className="text-2xl font-bold mb-6 text-center text-orange-600">
          My Courses
        </h2>
        <div className="space-y-4">
          {courses.map((course) => (
            <Card key={course.id} course={course} />
          ))}
        </div>
      </div>
    </div>
  );
};

export default MyCoursesPage;
