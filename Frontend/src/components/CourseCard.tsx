import React, { useState } from "react";
import CourseModal from "./CourseModal";
import { Course } from "../types";

interface CardProps {
  course: Course;
}

const Card: React.FC<CardProps> = ({ course }) => {
  const [isModalOpen, setIsModalOpen] = useState(false);

  function handleClick() {
    setIsModalOpen(true);
  }

  function handleModalClose() {
    setIsModalOpen(false);
  }

  return (
    <>
      <div className="p-4 border rounded-lg shadow-sm" onClick={handleClick}>
        <h3 className="text-xl font-semibold text-orange-600">{course.name}</h3>
        <p className="text-gray-500 text-sm">{course.category}</p>
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
