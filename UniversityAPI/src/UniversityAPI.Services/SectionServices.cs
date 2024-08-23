using UniversityAPI.Models;
using UniversityAPI.Repositories;

namespace UniversityAPI.Services;

public class SectionService : Service<Section>, ISectionServices
{
    public SectionService(ISectionRepository repository) : base(repository)
    {
    }

    public Student AddSectionToStudent(int sectionId, int studentId)
    {
        throw new NotImplementedException();
    }


    public Student DeleteSectionFromStudent(int sectionId, int studentId)
    {
        throw new NotImplementedException();
    }

    public List<Student> GetRegisteredSections(int id)
    {
        throw new NotImplementedException();
    }
}