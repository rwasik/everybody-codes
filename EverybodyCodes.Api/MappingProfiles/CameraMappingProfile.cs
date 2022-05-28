using AutoMapper;
using EverybodyCodes.Api.Models;
using EverybodyCodes.DataAccess.Entities;

namespace EverybodyCodes.Api.MappingProfiles;

public class CameraMappingProfile : Profile
{
    public CameraMappingProfile()
    {
        CreateMap<Camera, CameraModel>();
    }
}