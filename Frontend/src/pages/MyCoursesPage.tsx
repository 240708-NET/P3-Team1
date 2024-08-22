import React from "react";
import Card from "../components/CourseCard"
import Navbar from "../components/Navbar";

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
      description: "Learn the basics of programming with Python.",
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
