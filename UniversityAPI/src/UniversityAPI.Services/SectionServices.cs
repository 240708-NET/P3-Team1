using UniversityAPI.Models;
using UniversityAPI.Repositories;

namespace UniversityAPI.Services;

public class SectionService : Service<Section>, ISectionServices
{
    public SectionService(ISectionRepository repository) : base(repository)
    {

    }

    public async Task<Section> AddStudentToSection(int sectionId, int studentId)
    {
        Section? section = await ((ISectionRepository)_repository).AddStudentToSection(sectionId, studentId);
        if (section == null)
        {
            throw new ResourceNotFoundException();
        }
        return section;
    }

    public async Task<Section> DeleteStudentFromSection(int sectionId, int studentId)
    {
        Section? section = await ((ISectionRepository)_repository).DeleteStudentFromSection(sectionId, studentId);
        if (section == null)
        {
            throw new ResourceNotFoundException();
        }
        return section;
    }

    public async Task<List<Student>> GetRegisteredStudents(int id)
    {
        Section? section = await ((ISectionRepository)_repository).GetById(id);
        if (section == null)
        {
            throw new SectionNotFoundException();
        }
        List<Student>? students = await ((ISectionRepository)_repository).GetRegisteredStudents(id);
        if (students == null)
        {
            throw new RepositoryException();
        }
        return students;
    }
}