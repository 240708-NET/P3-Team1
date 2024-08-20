import React from "react";
import CourseModal from "./CourseModal";

interface Course {
  id: number;
  name: string;
  description: string;
  category: string;
}

interface CardProps {
  course: Course;
}

const Card: React.FC<CardProps> = ({ course }) => {
  return (
    <div className="p-4 border rounded-lg shadow-sm">
      <h3 className="text-xl font-semibold text-orange-600">{course.name}</h3>
      <p className="text-gray-700">{course.description}</p>
      <p className="text-gray-500 text-sm">{course.category}</p>
      <CourseModal />
    </div>
  );
};

export default Card;
