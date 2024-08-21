namespace UniversityAPI.Repository;
using UniversityAPI.Models;

    public interface IStudentRepository
    {
        Student CreateStudent(Student student);
        List<Student> GetAllStudents();
        Student? GetStudentById(int id);
        Student? UpdateStudent(Student student);
        Student? DeleteStudentById(int id);
        List<Student> DeleteAllStudents();
        List<Section> GetRegisteredSectionsByStudentId(int id);
    }