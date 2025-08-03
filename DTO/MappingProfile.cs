using ParentTeacherBridge.API.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;


namespace ParentTeacherBridge.API.DTO
{
    public class MappingProfile:Profile
    {
       public MappingProfile()
        {
            CreateMap<Teacher, TeacherDto>();
            CreateMap<CreateTeacherDto, Teacher>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<UpdateTeacherDto, Teacher>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));



            /// Behaviour mappings
        CreateMap<Behaviour, BehaviourDto>();
            CreateMap<CreateBehaviourDto, Behaviour>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateBehaviourDto, Behaviour>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Student, StudentDto>();

            CreateMap<Performance, PerformanceDto>().ReverseMap();
            CreateMap<CreatePerformanceDto, Performance>();
            CreateMap<UpdatePerformanceDto, Performance>();

        }

    }
}
