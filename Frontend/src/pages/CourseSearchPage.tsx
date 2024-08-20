import React, { useState, useEffect } from 'react';

interface Section {
  id: number;
  course: {
    name: string;
    category: string;
    description?: string;
  };
  professor: {
    firstName: string;
    lastName: string;
  };
  day: string;
  startTime: string;
  endTime: string;
}

const CourseSearchPage: React.FC = () => {
  // Hardcoded sections
  const mockSections: Section[] = [
    {
      id: 1,
      course: {
        name: "Algebra 1",
        category: "Mathematics",
        description: "Learn basic algebra."
      },
      professor: {
        firstName: "John",
        lastName: "Doe"
      },
      day: "Monday",
      startTime: "09:00",
      endTime: "10:30"
    },
    {
      id: 2,
      course: {
        name: "Calculus 1",
        category: "Mathematics",
        description: "A study of differential and integral calculus."
      },
      professor: {
        firstName: "Jane",
        lastName: "Smith"
      },
      day: "Tuesday",
      startTime: "11:00",
      endTime: "12:30"
    },
    {
      id: 3,
      course: {
        name: "World History",
        category: "History",
        description: "Explore major events in world history."
      },
      professor: {
        firstName: "Emily",
        lastName: "Johnson"
      },
      day: "Wednesday",
      startTime: "13:00",
      endTime: "14:30"
    },
    {
      id: 4,
      course: {
        name: "Biology 101",
        category: "Science",
        description: "Introduction to biological principles and concepts."
      },
      professor: {
        firstName: "Michael",
        lastName: "Brown"
      },
      day: "Thursday",
      startTime: "08:00",
      endTime: "09:30"
    },
    {
      id: 5,
      course: {
        name: "Advanced Algebra",
        category: "Mathematics",
        description: "Deep dive into advanced algebraic concepts."
      },
      professor: {
        firstName: "Linda",
        lastName: "Wilson"
      },
      day: "Friday",
      startTime: "10:00",
      endTime: "11:30"
    },
    {
      id: 6,
      course: {
        name: "Introduction to Philosophy",
        category: "Humanities",
        description: "Explore fundamental questions and theories in philosophy."
      },
      professor: {
        firstName: "Robert",
        lastName: "Davis"
      },
      day: "Monday",
      startTime: "15:00",
      endTime: "16:30"
    },
    {
      id: 7,
      course: {
        name: "Introduction to Economics",
        category: "Economics",
        description: "Basic principles of economics and their application."
      },
      professor: {
        firstName: "Susan",
        lastName: "Martinez"
      },
      day: "Wednesday",
      startTime: "09:00",
      endTime: "10:30"
    }
  ];

  const [sections, setSections] = useState<Section[]>(mockSections);
  const [filteredSections, setFilteredSections] = useState<Section[]>(mockSections);
  const [searchQuery, setSearchQuery] = useState<string>("");
  const [selectedCategory, setSelectedCategory] = useState<string>("");
  const [categories, setCategories] = useState<string[]>([]);
  const [selectedCourses, setSelectedCourses] = useState<Set<number>>(new Set());
  const [selectedCourse, setSelectedCourse] = useState<Section["course"] | null>(null);

  //Get the unique categories for courses for the dropdown options .
  useEffect(() => {
    const uniqueCategories: string[] = Array.from(
      new Set(sections.map((section) => section.course.category))
    );
    setCategories(uniqueCategories);

    setFilteredSections(sections);
  }, [sections]);

  // Search and filter courses based on the courses name.
  useEffect(() => {
    const filtered = sections.filter(
      (section) =>
        (section.course.name.toLowerCase().includes(searchQuery.toLowerCase()) ||
          section.id.toString().includes(searchQuery)) &&
        (selectedCategory === "" || section.course.category === selectedCategory)
    );
    setFilteredSections(filtered);
  }, [searchQuery, selectedCategory, sections]);

  // Handle selecting or deselecting courses on the checkbox
  const handleCheckboxChange = (id: number) => {
    setSelectedCourses((prevSelectedCourses) => {
      const newSelectedCourses = new Set(prevSelectedCourses);
      if (newSelectedCourses.has(id)) {
        newSelectedCourses.delete(id);
      } else {
        newSelectedCourses.add(id);
      }
      return newSelectedCourses;
    });
  };

  // Clicking on a course name will display its description.
  const handleCourseClick = (course: Section["course"]) => {
    setSelectedCourse(course);
  };

  // Register button will display the selected courses in the console output for testing. 
  const handleRegister = () => {
    const selectedSections = sections.filter(section => selectedCourses.has(section.id));
    console.log("Selected sections:");
    selectedSections.forEach(section => {
      console.log(`Course: ${section.course.name}, Professor: ${section.professor.firstName} ${section.professor.lastName}`);
    });
  };

  return (
    <div className="min-h-screen bg-slate-100 p-10">
      <div className="max-w-4xl mx-auto bg-white p-6 rounded-md shadow-lg">
        <header className="flex justify-between items-center mb-8">
          <h1 className="text-2xl font-semibold text-gray-900">Register a Course</h1>
        </header>

        <div className="mb-6 flex flex-col gap-4 md:flex-row md:gap-6">
          <div className="flex items-center">
            <label className="mr-2 text-gray-700">Search:</label>
            <input
              type="text"
              value={searchQuery}
              onChange={(e) => setSearchQuery(e.target.value)}
              className="border border-gray-300 p-2 rounded-md shadow-sm focus:ring-2 focus:ring-indigo-400"
            />
          </div>
          <div className="flex items-center">
            <label className="mr-2 text-gray-700">Category:</label>
            <select
              value={selectedCategory}
              onChange={(e) => setSelectedCategory(e.target.value)}
              className="border border-gray-300 p-2 rounded-md shadow-sm focus:ring-2 focus:ring-indigo-400"
            >
              <option value="">All</option>
              {categories.map((category) => (
                <option key={category} value={category}>{category}</option>
              ))}
            </select>
          </div>
        </div>

        <table className="w-full text-left border-collapse">
          <thead>
            <tr>
              <th className="px-4 py-2 border bg-gray-200">ID</th>
              <th className="px-4 py-2 border bg-gray-200">Course</th>
              <th className="px-4 py-2 border bg-gray-200">Professor</th>
              <th className="px-4 py-2 border bg-gray-200">Day</th>
              <th className="px-4 py-2 border bg-gray-200">Start Time</th>
              <th className="px-4 py-2 border bg-gray-200">End Time</th>
              <th className="px-4 py-2 border bg-gray-200">Select</th>
            </tr>
          </thead>
          <tbody>
            {filteredSections.length > 0 ? (
              filteredSections.map((section) => (
                <tr key={section.id}>
                  <td className="px-4 py-2 border">{section.id}</td>
                  <td className="px-4 py-2 border">
                    <button
                      onClick={() => handleCourseClick(section.course)}
                      className="text-indigo-600 underline hover:text-indigo-500"
                    >
                      {section.course.name}
                    </button>
                  </td>
                  <td className="px-4 py-2 border">
                    {section.professor.firstName} {section.professor.lastName}
                  </td>
                  <td className="px-4 py-2 border">{section.day}</td>
                  <td className="px-4 py-2 border">{section.startTime}</td>
                  <td className="px-4 py-2 border">{section.endTime}</td>
                  <td className="px-4 py-2 border text-center">
                    <input
                      type="checkbox"
                      checked={selectedCourses.has(section.id)}
                      onChange={() => handleCheckboxChange(section.id)}
                      className="h-4 w-4 text-indigo-600"
                    />
                  </td>
                </tr>
              ))
            ) : (
              <tr>
                <td colSpan={7} className="text-center py-4 text-gray-700">
                  No sections available.
                </td>
              </tr>
            )}
          </tbody>
        </table>

        {selectedCourse && (
          <div className="mt-6 p-4 bg-gray-200 rounded-md">
            <h2 className="text-xl font-semibold text-gray-900">
              {selectedCourse.name} Description:
            </h2>
            <p className="text-gray-700">{selectedCourse.description}</p>
          </div>
        )}

        <div className="mt-6 flex justify-end">
          <button
            onClick={handleRegister}
            className="bg-indigo-600 text-white px-4 py-2 rounded-md shadow-sm hover:bg-indigo-500 focus:outline-none focus:ring-2 focus:ring-indigo-400"
          >
            Register
          </button>
        </div>
      </div>
    </div>
  );
};

export default CourseSearchPage;