using EverybodyCodes.DataAccess.Entities;

namespace EverybodyCodes.DataAccess.Repositories;

public interface ICameraRepository 
{
    IEnumerable<Camera> GetAll();
    IEnumerable<Camera> FindByName(string name);
    IEnumerable<Camera> FindDivisibleBy(IEnumerable<int> numbers);
    IEnumerable<Camera> FindNotDivisibleBy(IEnumerable<int> numbers);
}