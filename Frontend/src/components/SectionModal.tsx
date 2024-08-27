import React from 'react';
import { useUser } from "../context/UserContext";
import { Navigate } from "react-router-dom";
import axios from "axios";

const API_BASE = import.meta.env.VITE_API_BASE;

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

interface SectionModalProps {
    sections: Section[];
    selectedCourseName: string;
    courseDescription: string;
    onClose: () => void;
}

const SectionModal: React.FC<SectionModalProps> = ({
    sections,
    selectedCourseName,
    courseDescription,
    onClose,
}: SectionModalProps) => {
    const userContext = useUser();

    if (!userContext?.user) {
        return <Navigate to="/login" />;
    }
    console.log(userContext.user);



    const handleRegister = async (section: Section) => {
        try {
            if (!userContext?.user) {
                console.error('User is not logged in');
                alert('You need to log in to register for a section.');
                return;
            }

            // Get the registered sections for student.
            const { data: registeredSections } = await axios.get<Section[]>(
                `${API_BASE}/student/${userContext.user.id}/section`
            );

            // Check if already registered for section.
            const isAlreadyRegisteredForSection = registeredSections.some(
                (s) => s.id === section.id
            );

            if (isAlreadyRegisteredForSection) {
                alert(`You are already registered for this section.`);
                return;
            }

            // Check if already registered for the same course.
            const isAlreadyRegisteredForCourse = registeredSections.some(
                (s) => s.courseID === section.courseID
            );

            if (isAlreadyRegisteredForCourse) {
                alert(`You are already registered for this course.`);
                return;
            }

            // Register section 
            const response = await axios.post(
                `${API_BASE}/Student/${userContext.user.id}/section`,
                section.id,
                {
                    headers: {
                        'Content-Type': 'application/json',
                    },
                }
            );
            console.log(response);

            alert(`Successfully registered for Section: ${section.id}!`);
        } catch (error) {
            console.error('Error registering', error);
            alert('Failed to register for section.');
        }
    };

    // Convert time to 12-hour format.
    const convertTo12HourFormat = (time: string) => {
        let [hours, minutes] = time.split(':').map(Number);
        const period = hours >= 12 ? 'PM' : 'AM';
        hours = hours % 12 || 12;
        return `${hours}:${minutes.toString().padStart(2, '0')} ${period}`;
    };

    return (
        <div className="fixed inset-0 z-50 flex items-center justify-center bg-black bg-opacity-50">
            <div className="bg-white p-6 rounded-md shadow-lg max-w-3xl w-full">
                <div className="flex justify-between items-center mb-4">
                    <h2 className="text-xl font-semibold text-gray-900">
                        Sections: {selectedCourseName}
                    </h2>
                    <button
                        onClick={onClose}
                        className="text-gray-500 hover:text-gray-700 focus:outline-none"
                    >
                        Close
                    </button>
                </div>

                <p className="text-gray-700 mb-4">{courseDescription}</p>

                {sections.length > 0 ? (
                    <table className="w-full text-left border-collapse mt-4">
                        <thead>
                            <tr>
                                <th className="px-4 py-2 border bg-gray-200">Section ID</th>
                                <th className="px-4 py-2 border bg-gray-200">Professor</th>
                                <th className="px-4 py-2 border bg-gray-200">Times</th>
                                <th className="px-4 py-2 border bg-gray-200">Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            {sections.map((section) => (
                                <tr key={section.id}>
                                    <td className="px-4 py-2 border">{section.id}</td>
                                    <td className="px-4 py-2 border">
                                        {section.professor.firstName} {section.professor.lastName}
                                    </td>
                                    <td className="px-4 py-2 border">
                                        <span className="font-bold text-gray-800">{section.day}</span>{' '}
                                        {convertTo12HourFormat(section.startTime)} - {convertTo12HourFormat(section.endTime)}
                                    </td>
                                    <td className="px-4 py-2 border">
                                        <button
                                            onClick={() => handleRegister(section)}
                                            className="text-white bg-blue-500 px-3 py-1 rounded-md hover:bg-blue-600"
                                        >
                                            Register
                                        </button>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                ) : (
                    <p className="text-gray-700 mt-4">No sections available for this course.</p>
                )}
            </div>
        </div>
    );
};

export default SectionModal;
