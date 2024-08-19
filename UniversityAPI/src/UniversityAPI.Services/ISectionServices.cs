using UniversityAPI.Models;

namespace UniversityAPI.Services;

public interface ISectionServices : IService<Section>{
    public List<Section> GetAllSections();
}