using AutoMapper;
using ConcatService.Api.Core.Domain.Entities;
using ConcatService.Api.Infrastructure.Context;
using ContactService.Api.Core.Domain.Models.Base;
using ContactService.Api.Core.Domain.Models.Request.ContactInformation;
using ContactService.Api.Core.Domain.Models.Response.ContactInformation;
using ContactService.Api.Infrastructure.Services.Abstarct;
using ContactService.Api.Infrastructure.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Api.Infrastructure.Services
{
    public class ContactInformationService : BaseService, IContactInformationService
    {
        private readonly IMapper _mapper;
        public ContactInformationService(ConcatDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<ApiBaseResponseModel<AddContactInformationResponseModel>> AddContactInformation(AddContactInformationRequestModel requestModel)
        {
            var responseModel = new ApiBaseResponseModel<AddContactInformationResponseModel>();

            try
            {
                var person = await context.Person
                    .Include(p => p.ContactInformations)
                    .FirstOrDefaultAsync(p => p.Id == requestModel.PersonId);

                if (person == null)
                {
                    responseModel.Success = false;
                    responseModel.Message = "Person not found!";
                    return responseModel;
                }

                if (person.ContactInformations == null)
                {
                    person.ContactInformations = new List<ContactInformation>();
                }

                var contactInformation = _mapper.Map<ContactInformation>(requestModel);

                person.ContactInformations.Add(contactInformation);

                await context.SaveChangesAsync();

                if (contactInformation.Id != Guid.Empty)
                {
                    responseModel.Success = true;
                    responseModel.Message = "Contact information added.";
                    responseModel.Data = _mapper.Map<AddContactInformationResponseModel>(contactInformation);
                }
                else
                {
                    responseModel.Success = false;
                    responseModel.Message = "Failed to add contact information!";
                    responseModel.Data = null;
                }
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = "An error occurred: " + ex.Message;
                responseModel.Data = null;
            }

            return responseModel;
        }
    }
}
