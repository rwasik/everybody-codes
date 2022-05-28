using EverybodyCodes.DataAccess.DataContext;
using EverybodyCodes.DataAccess.Entities;

namespace EverybodyCodes.DataAccess.Repositories;

public class CameraRepository : ICameraRepository
{
    private readonly CSVContext _csvContext;

    public CameraRepository(CSVContext csvContext)
    {
        _csvContext = csvContext;
    }

    public IEnumerable<Camera> GetAll()
    {
        return _csvContext.Cameras;
    }

    public IEnumerable<Camera> FindByName(string name)
    {
        return _csvContext.Cameras.Where(x => x.Name.ToLower().Contains(name.ToLower()));
    }

    public IEnumerable<Camera> FindDivisibleBy(IEnumerable<int> numbers)
    {
        return _csvContext.Cameras.Where(x => numbers.All(n => x.Id % n == 0));
    }
    
    public IEnumerable<Camera> FindNotDivisibleBy(IEnumerable<int> numbers)
    {
        return _csvContext.Cameras.Where(x => numbers.All(n => x.Id % n != 0));
    }
}