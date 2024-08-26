import React, { useState } from "react";
import CourseModal from "./CourseModal";
import { Course } from "../types";

interface CardProps {
  course: Course;
  onRegister: (courseId: number) => void;
  onDrop: (sectionID: number) => void;
}

const Card: React.FC<CardProps> = ({ course, onDrop }) => { //onRegister,
  const [isModalOpen, setIsModalOpen] = useState(false);

  function handleClick() {
    setIsModalOpen(true);
  }

  function handleModalClose() {
    setIsModalOpen(false);
  }

  // const handleRegister = (event: React.MouseEvent<HTMLButtonElement>) => {
  //   event.stopPropagation();
  //   onRegister(course.id);
  // };

  const handleDrop = (event: React.MouseEvent<HTMLButtonElement>) => {
    event.stopPropagation();
    if (course.sectionID) {
      onDrop(course.sectionID);
    }
  };

  return (
    <>
      <div
        className="px-4 py-2 flex border justify-between bg-gray-50 hover:bg-white cursor-pointer"
        onClick={handleClick}
      >
        <div className="flex gap-8 items-center">
          <div className="text-xl">{course.name}</div>
          <div className="text-sm font-light">{course.category}</div>
        </div>
        <button
          className="px-4 py-2 bg-red-500 text-white rounded hover:bg-red-400"
          onClick={handleDrop}
        >
          Drop
        </button>
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
