
export interface Course {
    id: number;
    name: string;
    description: string;
    category: string;
    isRegistered: boolean; // This indicates if the student is registered for this course
    sectionID: number | null; // This will be used for dropping the course, null if not registered
}
