using EverybodyCodes.Cli.Dtos;
using EverybodyCodes.DataAccess.Repositories;

namespace EverybodyCodes.Cli.Services;

public class SearchService : ISearchService
{
    private readonly ICameraRepository _cameraRepository;

    public SearchService(ICameraRepository cameraRepository)
    {
        _cameraRepository = cameraRepository;
    }

    public IEnumerable<CameraDto> FindByName(string name)
    {
        var cameras = _cameraRepository.FindByName(name);

        return cameras.Select(c => new CameraDto
        {
            Id = c.Id,
            Name = c.Name,
            Latitude = c.Latitude,
            Longitude = c.Longitude
        });
    }
}