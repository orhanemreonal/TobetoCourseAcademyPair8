using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        IInstructorDal _instructorDal;
        IMapper _mapper;

        public InstructorManager(IInstructorDal instructorDal, IMapper mapper)
        {
            _instructorDal = instructorDal;
            _mapper = mapper;
        }

        public async Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest)
        {
            Instructor instructor = _mapper.Map<Instructor>(createInstructorRequest);
            instructor.Id = Guid.NewGuid();
            await _instructorDal.AddAsync(instructor);
            CreatedInstructorResponse createdInstructorResponse = _mapper.Map<CreatedInstructorResponse>(instructor);
            return createdInstructorResponse;
        }

        public async Task<IPaginate<GetListedInstructorResponse>> GetListAsync(PageRequest pageRequest)
        {
           var result = await _instructorDal.GetListAsync(index:pageRequest.Index,size:pageRequest.Size);
            Paginate<GetListedInstructorResponse> response = _mapper.Map<Paginate<GetListedInstructorResponse>>(result);
            return response;
        }
    }
}
