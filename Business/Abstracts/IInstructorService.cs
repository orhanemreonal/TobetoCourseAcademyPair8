using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IInstructorService
    {
        Task<IPaginate<GetListedInstructorResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest);
    }
}
