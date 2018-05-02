using Matrix.DTOs;
using Matrix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Matrix.Helpers;

namespace Matrix.Data
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserInfoBriefDTO>().ForMember(dest => dest.PhotoUrl, opt =>
            {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsProfilePic).Url);
            }).ForMember(dest => dest.Age, opt =>
            {
                opt.ResolveUsing(d => d.BirthDate.CalculateAge());
            });

            CreateMap<User, UserInfoDetailedDTO>().ForMember(dest => dest.PhotoUrl, opt =>
            {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsProfilePic).Url);
            }).ForMember(dest => dest.Age, opt =>
            {
                opt.ResolveUsing(d => d.BirthDate.CalculateAge());
            });

            CreateMap<Photo, PhotoDTO>();

            CreateMap<UpdateUserDTO, User>();

            CreateMap<Photo, PhotoReturnedDTO>();

            CreateMap<AddPhotoDTO, Photo>();

            CreateMap<RegisterUserDTO, User>();
        }
    }
}
