using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        IMapper _mapper;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public async Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest)
        {
            Category category = _mapper.Map<Category>(createCategoryRequest);
            category.Id = Guid.NewGuid();
            await _categoryDal.AddAsync(category);
            CreatedCategoryResponse createdCategoryResponse = _mapper.Map<CreatedCategoryResponse>(category);
            return createdCategoryResponse;
        }

        public async Task<IPaginate<GetListedCategoryResponse>> GetListAsync(PageRequest pageRequest)
        {
            var result = await _categoryDal.GetListAsync(index:pageRequest.Index, size:pageRequest.Size);
            Paginate<GetListedCategoryResponse> response = _mapper.Map<Paginate<GetListedCategoryResponse>>(result);
            return response;
        }
    }
}



