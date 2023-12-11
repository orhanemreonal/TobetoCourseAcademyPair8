using AutoMapper;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.MappingProfiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<Category, CreateCategoryRequest>().ReverseMap();
            CreateMap<Category, CreatedCategoryResponse>().ReverseMap();
            CreateMap<Category, GetListedCategoryResponse>().ReverseMap();
            CreateMap<Paginate<Category>, Paginate<GetListedCategoryResponse>>().ReverseMap();


            CreateMap<Course, GetListedCourseResponse>()
                .ForMember(destinationMember: p => p.CategoryName,
                            memberOptions: opt => opt.MapFrom(p => p.Category.CategoryName)).ReverseMap();
            CreateMap<Course, CreateCourseRequest>().ReverseMap();
            CreateMap<Course, CreatedCourseResponse>().ReverseMap();
            CreateMap<Course, GetListedCourseResponse>().ReverseMap();
            CreateMap<Paginate<Course>, Paginate<GetListedCourseResponse>>().ReverseMap();



            CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();
            CreateMap<Instructor, CreatedInstructorResponse>().ReverseMap();
            CreateMap<Instructor, GetListedInstructorResponse>().ReverseMap();
            CreateMap<Paginate<Instructor>, Paginate<GetListedInstructorResponse>>().ReverseMap();

        }
    }
}
