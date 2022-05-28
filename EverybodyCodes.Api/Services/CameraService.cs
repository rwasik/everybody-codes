using AutoMapper;
using EverybodyCodes.Api.Models;
using EverybodyCodes.DataAccess.Repositories;

namespace EverybodyCodes.Api.Services;

public class CameraService : ICameraService
{
    private readonly ICameraRepository _cameraRepository;
    private readonly IMapper _mapper;

    public CameraService(ICameraRepository cameraRepository, IMapper mapper)
    {
        _cameraRepository = cameraRepository;
        _mapper = mapper;
    }

    public IEnumerable<CameraModel> GetAll()
    {
        var cameras = _cameraRepository.GetAll();

        return _mapper.Map<IEnumerable<CameraModel>>(cameras);
    }

    public IEnumerable<CameraModel> GetDivisibleBy(IEnumerable<int> numbers, bool negation)
    {
        var cameras = negation ? 
            _cameraRepository.FindNotDivisibleBy(numbers) :
            _cameraRepository.FindDivisibleBy(numbers);

        return _mapper.Map<IEnumerable<CameraModel>>(cameras);
    }
}