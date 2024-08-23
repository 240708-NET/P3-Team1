import React, { useState } from "react";
import CourseModal from "./CourseModal";
import { Course } from "../types";

interface CardProps {
  course: Course;
  onRegister: (courseId: number) => void;
  onDrop: (sectionID: number) => void;
}

const Card: React.FC<CardProps> = ({ course, onRegister, onDrop }) => {
  const [isModalOpen, setIsModalOpen] = useState(false);

  function handleClick() {
    setIsModalOpen(true);
  }

  function handleModalClose() {
    setIsModalOpen(false);
  }

  const handleRegister = (event: React.MouseEvent<HTMLButtonElement>) => {
    event.stopPropagation();
    onRegister(course.id);
  };

  const handleDrop = (event: React.MouseEvent<HTMLButtonElement>) => {
    event.stopPropagation();
    if (course.sectionID) {
      onDrop(course.sectionID);
    }
  };

  return (
    <>
      <div className="p-4 border rounded-lg shadow-sm" onClick={handleClick}>
        <h3 className="text-xl font-semibold text-orange-600">{course.name}</h3>
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
      <CourseModal
        course={course}
        open={isModalOpen}
        onClose={handleModalClose}
      />
    </>
  );
};

export default Card;
