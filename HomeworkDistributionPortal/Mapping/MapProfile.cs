using AutoMapper;
using HomeworkDistributionPortal.Dtos;
using HomeworkDistributionPortal.Models;


namespace HomeworkDistributionPortal.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Lesson, LessonDto>().ReverseMap();
            CreateMap<Homework, HomeworkDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
            CreateMap<Delivery, DeliveryDto>().ReverseMap();
            CreateMap<Announcement, AnnouncementDto>().ReverseMap();
            CreateMap<Class, ClassDto>().ReverseMap();
        }
    }
}