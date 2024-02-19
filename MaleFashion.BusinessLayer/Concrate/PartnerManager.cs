using FluentValidation;
using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Mapping;
using MaleFashion.DataAccessLayer.Abstract;
using MaleFashion.DataAccessLayer.EntityFramework;
using MaleFashion.DataAccessLayer.UnitOfWork;
using MaleFashion.DtoLayer.Dtos.PartnerDtos;
using MaleFashion.DtoLayer.Dtos.PartnerDtos;
using MaleFashion.EntityLayer.Concrete;
using MaleFashion.SharedLayer;
using MaleFashion.SharedLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Concrate
{
    public class PartnerManager : IPartnerService
    {
        private readonly IPartnerDal _partnerDal;
        private readonly IValidator<CreatePartnerDto> _createValidator;
        private readonly IValidator<UpdatePartnerDto> _updateValidator;
        private readonly IUow _uow;

        public PartnerManager(IPartnerDal partnerDal, IValidator<CreatePartnerDto> createValidator, IValidator<UpdatePartnerDto> updateValidator, IUow uow)
        {
            _partnerDal = partnerDal;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _uow = uow;
        }


        public async Task<Response<CreatePartnerDto>> TAddAsync(CreatePartnerDto entity)
        {
            var validate = _createValidator.Validate(entity);
            List<ValidationError> validationError = new List<ValidationError>();
            if (!validate.IsValid)
            {
                foreach (var item in validate.Errors)
                {

                    validationError.Add(
                         new ValidationError() { Code = item.ErrorCode, Message = item.ErrorMessage, Property = item.PropertyName }
                        );
                }

                return Response<CreatePartnerDto>.ValidatorErr(validationError, ResponseType.ValidationError);
            }

            var value = await _partnerDal.AddAsync(ObjectMapper.mapper.Map<Partner>(entity));
            await _uow.CommitAsync();
            if (value?.Id == null)
            {
                return Response<CreatePartnerDto>.Fail("Veri eklenemedi", ResponseType.Fail);
            }
            return Response<CreatePartnerDto>.Success(entity, ResponseType.Success);
        }

        public async Task<Response<NoContent>> TDelete(int id)
        {
            var value = await _partnerDal.GetByIdAsync(id);
            if (value?.Id == null)
            {
                return Response<NoContent>.Fail("Veri silinemedi", ResponseType.Fail);
            }
            _partnerDal.Delete(value);
            _uow.Commit();
            return Response<NoContent>.Success(ResponseType.Success);
        }

        public async Task<Response<List<ResultPartnerDto>>> TGetAllAsync()
        {
            var values = await _partnerDal.GetAllAsync();
            if (values?.Count < 1)
            {
                return Response<List<ResultPartnerDto>>.Fail("Veri getirilemedi", ResponseType.Fail);
            }
            return Response<List<ResultPartnerDto>>.Success(ObjectMapper.mapper.Map<List<ResultPartnerDto>>(values), ResponseType.Success);
        }

        public async Task<Response<ResultPartnerDto>> TGetByIdAsync(int id)
        {
            var value = await _partnerDal.GetByIdAsync(id);
            if (value?.Id == null)
            {
                return Response<ResultPartnerDto>.Fail("Veri getirilemedi", ResponseType.Fail);
            }
            return Response<ResultPartnerDto>.Success(ObjectMapper.mapper.Map<ResultPartnerDto>(value), ResponseType.Success);
        }

        public Response<UpdatePartnerDto> TUpdate(UpdatePartnerDto entity)
        {
            var validate = _updateValidator.Validate(entity);
            List<ValidationError> errors = new List<ValidationError>();
            if (!validate.IsValid)
            {
                foreach (var item in validate.Errors)
                {
                    errors.Add(new ValidationError { Code = item.ErrorCode, Message = item.ErrorMessage, Property = item.PropertyName });
                }
                return Response<UpdatePartnerDto>.ValidatorErr(errors, ResponseType.ValidationError);
            }
            var value = _partnerDal.Update(ObjectMapper.mapper.Map<Partner>(entity));
            if (value?.Id == null)
            {
                return Response<UpdatePartnerDto>.Fail("Güncelleme başarısız.", ResponseType.Fail);
            }
            return Response<UpdatePartnerDto>.Success(entity, ResponseType.Success);
        }
    }
}
