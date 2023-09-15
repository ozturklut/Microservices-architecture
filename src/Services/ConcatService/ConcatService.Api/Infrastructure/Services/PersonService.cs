using ConcatService.Api.Core.Domain.Entities;
using ConcatService.Api.Infrastructure.Context;
using ContactService.Api.Core.Domain.Models.Base;
using ContactService.Api.Core.Domain.Models.Request.Person;
using ContactService.Api.Core.Domain.Models.Request;
using ContactService.Api.Core.Domain.Models.Response.Person;
using ContactService.Api.Infrastructure.Services.Abstarct;
using ContactService.Api.Infrastructure.Services.Base;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ContactService.Api.Infrastructure.Services
{
    public class PersonService : BaseService, IPersonService
    {
        private readonly IMapper _mapper;
        public PersonService(ConcatDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<ApiBaseResponseModel<AddPersonResponseModel>> AddPerson(AddPersonRequestModel requestModel)
        {
            ApiBaseResponseModel<AddPersonResponseModel> responseModel = new ApiBaseResponseModel<AddPersonResponseModel>();

            try
            {
                var person = new Person
                {
                    CreatedDate = DateTime.UtcNow,
                    FirstName = requestModel.FirstName,
                    LastName = requestModel.LastName,
                    Company = requestModel.Company
                };

                context.Person.Add(person);
                await context.SaveChangesAsync();

                responseModel.Success = true;
                responseModel.Message = "Person added.";
                responseModel.Data = _mapper.Map<AddPersonResponseModel>(person);
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = "Failed to add person:  " + ex.Message;
                responseModel.Data = null;
            }

            return responseModel;
        }

        public async Task<ApiBaseResponseModel<List<PersonResponseModel>>> GetAllPerson()
        {
            var responseModel = new ApiBaseResponseModel<List<PersonResponseModel>>();

            try
            {
                var peopleList = await context.Person
                    .AsNoTracking()
                    .ToListAsync();

                responseModel.Data = _mapper.Map<List<PersonResponseModel>>(peopleList);
                responseModel.Success = true;
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = "Failed to retrieve people: " + ex.Message;
                responseModel.Data = null;
            }

            return responseModel;
        }

        public async Task<ApiBaseResponseModel<PersonWithContactInformationResponseModel>> GetPerson(BaseGetRequestModel requestModel)
        {
            var responseModel = new ApiBaseResponseModel<PersonWithContactInformationResponseModel>();

            try
            {
                var person = context.Person
                    .Include(x => x.ContactInformations)
                    .FirstOrDefault(c => c.Id == requestModel.Id);

                if (person == null)
                {
                    responseModel.Success = false;
                    responseModel.Message = "Person not found!";
                }
                else
                {
                    responseModel.Data = _mapper.Map<PersonWithContactInformationResponseModel>(person);
                    responseModel.Success = true;
                }
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = "Failed to retrieve person: " + ex.Message;
            }

            return responseModel;
        }

        public async Task<ApiBaseResponseModel<bool>> DeletePerson(BaseDeleteRequestModel requestModel)
        {
            var responseModel = new ApiBaseResponseModel<bool>();

            try
            {
                var person = await context.Person
                    .Include(p => p.ContactInformations)
                    .FirstOrDefaultAsync(p => p.Id == requestModel.Id);

                if (person == null)
                {
                    responseModel.Success = false;
                    responseModel.Message = "Person not found!";
                    responseModel.Data = false;
                }
                else
                {
                    context.Person.Remove(person);
                    await context.SaveChangesAsync();

                    responseModel.Success = true;
                    responseModel.Message = "Person and associated contacts deleted.";
                    responseModel.Data = true;
                }
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = "Failed to delete person: " + ex.Message;
                responseModel.Data = false;
            }

            return responseModel;
        }
    }
}
