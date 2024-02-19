using FluentValidation;
using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.DataAccessLayer.Abstract;
using MaleFashion.DataAccessLayer.EntityFramework;
using MaleFashion.DataAccessLayer.UnitOfWork;
using MaleFashion.DtoLayer.Dtos.SocialMediaDtos;
using MaleFashion.DtoLayer.Dtos.SocialMediaDtos;
using MaleFashion.SharedLayer.Enums;
using MaleFashion.SharedLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaleFashion.BusinessLayer.Mapping;
using MaleFashion.EntityLayer.Concrete;

namespace MaleFashion.BusinessLayer.Concrate
{
    public class SocialMediaManager:ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;
        private readonly IValidator<CreateSocialMediaDto> _createValidator;
        private readonly IValidator<UpdateSocialMediaDto> _updateValidator;
        private readonly IUow _uow;

        public SocialMediaManager(ISocialMediaDal socialMediaDal, IValidator<CreateSocialMediaDto> createValidator, IValidator<UpdateSocialMediaDto> updateValidator, IUow uow)
        {
            _socialMediaDal = socialMediaDal;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _uow = uow;
        }
        public async Task<Response<CreateSocialMediaDto>> TAddAsync(CreateSocialMediaDto entity)
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

                return Response<CreateSocialMediaDto>.ValidatorErr(validationError, ResponseType.ValidationError);
            }

            var value = await _socialMediaDal.AddAsync(ObjectMapper.mapper.Map<SocialMedia>(entity));
            await _uow.CommitAsync();
            if (value?.Id == null)
            {
                return Response<CreateSocialMediaDto>.Fail("Veri eklenemedi", ResponseType.Fail);
            }
            return Response<CreateSocialMediaDto>.Success(entity, ResponseType.Success);
        }

        public async Task<Response<NoContent>> TDelete(int id)
        {
            var value = await _socialMediaDal.GetByIdAsync(id);
            if (value?.Id == null)
            {
                return Response<NoContent>.Fail("Veri silinemedi", ResponseType.Fail);
            }
            _socialMediaDal.Delete(value);
            _uow.Commit();
            return Response<NoContent>.Success(ResponseType.Success);
        }

        public async Task<Response<List<ResultSocialMediaDto>>> TGetAllAsync()
        {
            var values = await _socialMediaDal.GetAllAsync();
            if (values?.Count < 1)
            {
                return Response<List<ResultSocialMediaDto>>.Fail("Veri getirilemedi", ResponseType.Fail);
            }
            return Response<List<ResultSocialMediaDto>>.Success(ObjectMapper.mapper.Map<List<ResultSocialMediaDto>>(values), ResponseType.Success);
        }

        public async Task<Response<ResultSocialMediaDto>> TGetByIdAsync(int id)
        {
            var value = await _socialMediaDal.GetByIdAsync(id);
            if (value?.Id == null)
            {
                return Response<ResultSocialMediaDto>.Fail("Veri getirilemedi", ResponseType.Fail);
            }
            return Response<ResultSocialMediaDto>.Success(ObjectMapper.mapper.Map<ResultSocialMediaDto>(value), ResponseType.Success);
        }

        public Response<UpdateSocialMediaDto> TUpdate(UpdateSocialMediaDto entity)
        {
            var validate = _updateValidator.Validate(entity);
            List<ValidationError> errors = new List<ValidationError>();
            if (!validate.IsValid)
            {
                foreach (var item in validate.Errors)
                {
                    errors.Add(new ValidationError { Code = item.ErrorCode, Message = item.ErrorMessage, Property = item.PropertyName });
                }
                return Response<UpdateSocialMediaDto>.ValidatorErr(errors, ResponseType.ValidationError);
            }
            var value = _socialMediaDal.Update(ObjectMapper.mapper.Map<SocialMedia>(entity));
            if (value?.Id == null)
            {
                return Response<UpdateSocialMediaDto>.Fail("Güncelleme başarısız.", ResponseType.Fail);
            }
            return Response<UpdateSocialMediaDto>.Success(entity, ResponseType.Success);
        }
    }
}
