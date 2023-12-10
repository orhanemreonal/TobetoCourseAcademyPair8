﻿using Business.Abstracts;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class CourseManager : ICourseService
{
    ICourseDal _courseDal;
    public CourseManager(ICourseDal courseDal)
    {
        _courseDal = courseDal;
    }
    
    public async Task<CreatedCourseResponse> Add(CreateCourseRequest createCourseRequest)
    {
        Course course = new Course();
        course.Id = Guid.NewGuid();
        course.Name = createCourseRequest.Name;
        course.Price = createCourseRequest.Price;
        course.Description = createCourseRequest.Description;
        course.ImageUrl = createCourseRequest.ImageUrl;
        course.Category = createCourseRequest.Category;
        course.Instructor = createCourseRequest.Instructor;

        Course createdCourse = await _courseDal.AddAsync(course);
        CreatedCourseResponse createdCourseResponse = new CreatedCourseResponse();
        createdCourseResponse.Id = createdCourse.Id;
        createdCourseResponse.Name = createCourseRequest.Name;
        createdCourseResponse.Category = createCourseRequest.Category;
        createdCourseResponse.Instructor = createCourseRequest.Instructor;
        createdCourseResponse.Description = createCourseRequest.Description;
        createdCourseResponse.ImageUrl = createCourseRequest.ImageUrl;
        createdCourseResponse.Price = createCourseRequest.Price;

        return createdCourseResponse;
  
    }

    public async Task<IPaginate<GetListedCourseResponse>> GetListAsync()
    {
        //paginate içinde course listesi
        var result = await _courseDal.GetListAsync(); //Kursların olduğu tüm listeyi result'a attık.

        //getListedCourseResponse 
        List<GetListedCourseResponse> getList = new List<GetListedCourseResponse>();

        //product list mapping
          foreach (var item in result.Items)
        {
            GetListedCourseResponse getListedCourseResponse = new GetListedCourseResponse();
            getListedCourseResponse.Id = item.Id;
            getListedCourseResponse.Name= item.Name;    
            getListedCourseResponse.Instructor = item.Instructor;
            getListedCourseResponse.Category = item.Category;
            getListedCourseResponse.Description = item.Description;
            getListedCourseResponse.ImageUrl = item.ImageUrl;
            getListedCourseResponse.Price = item.Price; 
            getList.Add(getListedCourseResponse);
        }

        //paginate mapping
        Paginate<GetListedCourseResponse> _paginate = new Paginate<GetListedCourseResponse>();
        _paginate.Pages = result.Pages;
        _paginate.Items = getList;
        _paginate.Index = result.Index;
        _paginate.Size = result.Size;
        _paginate.Count = result.Count;
        _paginate.From = result.From;
        //_paginate.HasNext=result.Result.HasNext; //auto value
        //_paginate.HasPrevious = result.Result.HasPrevious; //auto value
        return _paginate;
    }
}

//1-GetList operasyonuna response ekle 
//Tobetodaki tüm nesneleri response request patternine göre ekle
//Sistemleri automappera çek
