import React, { useState } from "react";

interface Course {
  id: number;
  name: string;
  description: string;
  category: string;
  isRegistered: boolean; // This indicates if the student is registered for this course
  sectionID: number | null; // This will be used for dropping the course, null if not registered
}


interface CardProps {
  course: Course;
  isRegistered: boolean;
  onRegister: (courseId: number) => void;
  onDrop: (sectionID: number) => void;
}

const Card: React.FC<CardProps> = ({ course, onRegister, onDrop }) => {

  const handleRegister = () => {
    onRegister(course.id);
  }

  const handleDrop = () => {
    if (course.sectionID) {
      onDrop(course.sectionID);
    }
  };

  return (
    <div className="p-4 border rounded-lg shadow-sm">
      <h3 className="text-xl font-semibold text-orange-600">{course.name}</h3>
      <p className="text-gray-700">{course.description}</p>
      <p className="text-gray-500 text-sm">{course.category}</p>

      <div className="mt-4">
        {course.isRegistered ? (
          <button
            className="px-4 py-2 bg-red-500 text-white rounded hover:bg-red-400"
            onClick={handleDrop}
          >
            Drop Course
          </button>
        ) : (
          <button
            className="px-4 py-2 bg-green-500 text-white rounded hover:bg-green-400"
            onClick={handleRegister}
          >
            Register
          </button>
        )}
      </div>

    </div>
  );
};

export default Card;
