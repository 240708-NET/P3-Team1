import React, { useState, useEffect } from 'react';
import axios from 'axios';

// Define the Section type with data types
interface Section {
    id: number;
    courseID: number; 
    course: {
        id: number; 
        name: string;
        description?: string; 
        category?: string; 
    };
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

const API_BASE = "http://localhost:5236/api";

const CourseSearchPage: React.FC = () => {
    // States for sections, categories, and search queries
    const [sections, setSections] = useState<Section[]>([]);
    const [filteredSections, setFilteredSections] = useState<Section[]>([]);
    const [searchQuery, setSearchQuery] = useState<string>("");
    const [selectedCategory, setSelectedCategory] = useState<string>("");
    const [categories, setCategories] = useState<string[]>([]);
    const [selectedCourses, setSelectedCourses] = useState<Set<number>>(new Set());
    const [selectedCourse, setSelectedCourse] = useState<Section["course"] | null>(null);

    // Fetch sections from the API.
    useEffect(() => {
        axios
            .get<Section[]>(`${API_BASE}/Section`)
            .then((response) => {
                const sectionData = response.data;
                setSections(sectionData);

                // Extract unique categories for the dropdown
                const uniqueCategories: string[] = Array.from(
                    new Set(sectionData.map((section) => section.course.category || ""))
                );
                setCategories(uniqueCategories);

                // Set initial filtered sections
                setFilteredSections(sectionData);
            })
            .catch((error) => {
                console.error("Error fetching sections:", error);
                alert("Failed to fetch sections");
            });
    }, []);

    // Search and filter courses based on the course name and category
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

    // Clicking on a course name will display its description
    const handleCourseClick = (course: Section["course"]) => {
        setSelectedCourse(course);
    };

    // Register button will display the Sections in the console for now.
    const handleRegister = () => {
        const selectedSections = sections.filter(section => selectedCourses.has(section.id));
        console.log("Selected sections:");
        selectedSections.forEach(section => {
            console.log(section);
        });
    };

    // Function to format time by excluding seconds and converting to 12-hour format with AM/PM
    const formatTime = (time: string) => {
        const [hours, minutes] = time.split(':').map(Number);
        const period = hours >= 12 ? 'PM' : 'AM';
        const adjustedHours = hours % 12 || 12; 
        return `${adjustedHours}:${minutes.toString().padStart(2, '0')} ${period}`;
    };

    // Function to get the first three letters of the day or days
    const getShortDay = (day: string) => {
        // Convert multiple days to their short forms
        return day.split(',').map(d => d.trim().slice(0, 3)).join(', ');
    };

    return (
        <div className="min-h-screen bg-orange-300 p-10">
            <div className="max-w-4xl mx-auto bg-white p-6 rounded-md shadow-lg">
                <header className="text-center mb-8">
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
                            <th className="px-4 py-2 border bg-gray-200">Course ID</th>
                            <th className="px-4 py-2 border bg-gray-200">Course</th>
                            <th className="px-4 py-2 border bg-gray-200">Professor</th>
                            <th className="px-4 py-2 border bg-gray-200">Times</th>
                            <th className="px-4 py-2 border bg-gray-200">Select</th>
                        </tr>
                    </thead>
                    <tbody>
                        {filteredSections.length > 0 ? (
                            filteredSections.map((section) => (
                                <tr key={section.course.id}>
                                    <td className="px-4 py-2 border">{section.course.id}</td>
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
                                    <td className="px-4 py-2 border">
                                        <span className="font-bold text-gray-800">{getShortDay(section.day)}</span> {formatTime(section.startTime)}-{formatTime(section.endTime)}
                                    </td>
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
                                <td colSpan={5} className="text-center py-4 text-gray-700">
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
