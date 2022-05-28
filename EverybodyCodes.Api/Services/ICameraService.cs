using EverybodyCodes.Api.Models;

namespace EverybodyCodes.Api.Services;

public interface ICameraService 
{
    IEnumerable<CameraModel> GetAll();
    IEnumerable<CameraModel> GetDivisibleBy(IEnumerable<int> numbers, bool negation);
}