import React, { useState, useEffect } from "react";
import axios from "axios";
import Navbar from "../components/Navbar";
import { Navigate } from "react-router-dom";
import { useUser } from "../context/UserContext";
import SectionModal from '../components/SectionModal';

// Define the Section type with data types
interface Course {
  id: number;
  name: string;
  description?: string;
  category?: string;
}

interface Section {
  id: number;
  courseID: number;
  professorID: number;
  professor: {
    id: number;
    firstName: string;
    lastName: string;
  };
  startTime: string;
  endTime: string;
  day: string;
}

const API_BASE = import.meta.env.VITE_API_BASE;

const CourseSearchPage: React.FC = () => {
  // States for sections, categories, and search queries
  const [courses, setCourses] = useState<Course[]>([]);
  const [filteredCourses, setFilteredCourses] = useState<Course[]>([]);
  const [sections, setSections] = useState<Section[]>([]);
  const [selectedCourse, setSelectedCourse] = useState<Course | null>(null);
  const [searchQuery, setSearchQuery] = useState<string>("");
  const [selectedCategory, setSelectedCategory] = useState<string>("");
  const [categories, setCategories] = useState<string[]>([]);
  const userContext = useUser();

  if (!userContext?.user) {
    return <Navigate to="/login" />;
  }

  // Get all courses.
  useEffect(() => {
    axios
      .get<Course[]>(`${API_BASE}/Course`)
      .then((response) => {
        const courseData = response.data;
        setCourses(courseData);
        setFilteredCourses(courseData);

        const uniqueCategories: string[] = Array.from(
          new Set(courseData.map((course) => course.category || ""))
        );
        setCategories(uniqueCategories);
      })
      .catch((error) => {
        console.error("Error fetching courses:", error);
        alert("Failed to fetch courses");
      });
  }, []);

  // Search and filter courses based on the course name and category
  useEffect(() => {
    const filtered = courses.filter(
      (course) =>
        (course.name.toLowerCase().includes(searchQuery.toLowerCase()) ||
          course.id.toString().includes(searchQuery)) &&
        (selectedCategory === "" || course.category === selectedCategory)
    );
    setFilteredCourses(filtered);
  }, [searchQuery, selectedCategory, courses]);


  //Get all sections with the given courseID.
  const fetchSectionsByCourse = (courseID: number) => {
    axios
      .get<Section[]>(`${API_BASE}/Section`)
      .then((response) => {
        const filteredSections = response.data.filter(section => section.courseID === courseID);
        setSections(filteredSections);
      })
      .catch((error) => {
        console.error("Error fetching sections:", error);
        alert("Failed to fetch sections");
      });
  };

  //Handles the event when a course is clicked.
  const handleCourseClick = (course: Course) => {
    setSelectedCourse(course);
    fetchSectionsByCourse(course.id);
  };

  const handleCloseModal = () => {
    setSelectedCourse(null);
  };

  return (
    <div className="min-h-screen h-full flex flex-col">
      <Navbar />
      <div className="mx-8 mb-8 h-full shadow-xl rounded-2xl px-16 py-6 bg-white grow">
        <div className="py-12 text-center text-3xl font-medium leading-normal tracking-tight text-gray-900">
          Register a Course
        </div>

        <div className="mx-auto max-w-3xl mb-6 flex flex-row justify-around">
          <div className="flex items-center">
            <label className="mr-2 text-gray-700 font-medium">Search:</label>
            <input
              type="text"
              value={searchQuery}
              onChange={(e) => setSearchQuery(e.target.value)}
              className="border border-gray-300 p-2 rounded-md shadow-sm focus:ring-2 focus:ring-indigo-500"
            />
          </div>
          <div className="flex items-center">
            <label className="mr-2 text-gray-700 font-medium">Category:</label>
            <select
              value={selectedCategory}
              onChange={(e) => setSelectedCategory(e.target.value)}
              className="border border-gray-300 p-2 rounded-md shadow-sm focus:ring-2 focus:ring-indigo-500"
            >
              <option value="">All</option>
              {categories.map((category) => (
                <option key={category} value={category}>{category}</option>
              ))}
            </select>
          </div>
        </div>

        <table className="w-full text-left border-collapse mb-6 shadow-md">
          <thead>
            <tr>
              <th className="px-4 py-2 border bg-gray-200 text-gray-800 font-semibold">Course ID</th>
              <th className="px-4 py-2 border bg-gray-200 text-gray-800 font-semibold">Course Name</th>
              <th className="px-4 py-2 border bg-gray-200 text-gray-800 font-semibold">Category</th>
            </tr>
          </thead>
          <tbody>
            {filteredCourses.length > 0 ? (
              filteredCourses.map((course) => (
                <tr key={course.id} className="hover:bg-gray-100 cursor-pointer">
                  <td className="px-4 py-2 border">{course.id}</td>
                  <td className="px-4 py-2 border">
                    <button
                      onClick={() => handleCourseClick(course)}
                      className="text-indigo-600 font-medium hover:text-indigo-500"
                    >
                      {course.name}
                    </button>
                  </td>
                  <td className="px-4 py-2 border">{course.category || "N/A"}</td>
                </tr>
              ))
            ) : (
              <tr>
                <td colSpan={3} className="text-center py-4 text-gray-700">
                  No courses available.
                </td>
              </tr>
            )}
          </tbody>
        </table>

        {selectedCourse && (
          <SectionModal
            sections={sections}
            selectedCourseName={selectedCourse.name}
            courseDescription={selectedCourse.description || "No description available"}
            onClose={handleCloseModal}
          />
        )}
      </div>
    </div>
  );
};

export default CourseSearchPage;

