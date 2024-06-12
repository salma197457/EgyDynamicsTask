using AutoMapper;
using EgyDynamics2.DTO;
using EgyDynamics2.Models;

namespace EgyDynamics2.Config
{
    public class AutoMap : Profile
    {
        public AutoMap()
        {
            CreateMap<العميل, العميلDTO>()
                .ForMember(dest => dest.ادخالبواسطة, opt => opt.MapFrom(src => src.ادخالبواسطةNavigation.اسمالموظف))
                .ForMember(dest => dest.اخرتعديل, opt => opt.MapFrom(src => src.اخرتعديلNavigation.اسمالموظف));


            CreateMap<اضافة_عميلDTO, العميل>();
            CreateMap<العميل, تعديل_عميلDTO>()
                .ForMember(dest=>dest.اخرتعديل,opt=>opt.MapFrom(src=>src.اخرتعديلNavigation.اسمالموظف))
                .ForMember(dest=>dest.ادخالبواسطة,opt=>opt.MapFrom(src=>src.ادخالبواسطةNavigation.اسمالموظف));

            //CreateMap<مكالمهالعميل, المكالماتDTO>()
            //    .ForMember(dest => dest.اخرتعديل, opt => opt.MapFrom(src => src.اخرتعديلNavigation.اسمالموظف)) // Ensure property name and type match
            //    .ForMember(dest => dest.ادخالبواسطه, opt => opt.MapFrom(src => src.ادخالبواسطهNavigation.اسمالموظف)) // Ensure property name and type match
            //    .ForMember(dest => dest.الموظف, opt => opt.MapFrom(src => src.الموظفNavigation.اسمالموظف)); // Ensure property name and type match

            CreateMap<تعديل_عميلDTO,العميل>();
            CreateMap<العميل, تعديل_عميلDTO>();

        }
    }
}
