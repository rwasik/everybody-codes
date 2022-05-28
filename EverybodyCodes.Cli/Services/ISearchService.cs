using EverybodyCodes.Cli.Dtos;

namespace EverybodyCodes.Cli.Services;

public interface ISearchService
{
    IEnumerable<CameraDto> FindByName(string name);
}