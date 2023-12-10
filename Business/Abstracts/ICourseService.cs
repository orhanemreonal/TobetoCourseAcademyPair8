using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICourseService
    {
        Task<IPaginate<GetListedCourseResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedCourseResponse> Add(CreateCourseRequest createCourseRequest);
    }

    //1-GetList operasyonuna response ekle 
    //Tobetodaki tüm nesneleri response request patternine göre ekle 
    //Sistemleri automappera çek
}
