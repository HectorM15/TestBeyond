using AutoMapper;
using TestBeyond.API.DTOs;
using Domain.Entities;

namespace TestBeyond.API.Mappings;

public class TodoItemProfile : Profile
{
    public TodoItemProfile()
    {
        CreateMap<TodoItem, TodoItemReadDto>()
            .ForMember(dest => dest.Progressions, opt => opt.MapFrom(src => src.Progressions.ToList()));
        CreateMap<Progression, ProgressionDto>();
    }
}
