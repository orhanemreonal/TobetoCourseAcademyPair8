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
    public interface ICategoryService
    {
        Task<IPaginate<GetListedCategoryResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest);
    }
}
