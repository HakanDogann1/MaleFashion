using FluentValidation;
using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.DataAccessLayer.Abstract;
using MaleFashion.DataAccessLayer.EntityFramework;
using MaleFashion.DataAccessLayer.UnitOfWork;
using MaleFashion.DtoLayer.Dtos.TagDtos;
using MaleFashion.DtoLayer.Dtos.TagDtos;
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
    public class TagManager:ITagService
    {
        private readonly ITagDal _tagDal;
        private readonly IValidator<CreateTagDto> _createValidator;
        private readonly IValidator<UpdateTagDto> _updateValidator;
        private readonly IUow _uow;

        public TagManager(ITagDal tagDal, IValidator<CreateTagDto> createValidator, IValidator<UpdateTagDto> updateValidator, IUow uow)
        {
            _tagDal = tagDal;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _uow = uow;
        }
        public async Task<Response<CreateTagDto>> TAddAsync(CreateTagDto entity)
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

                return Response<CreateTagDto>.ValidatorErr(validationError, ResponseType.ValidationError);
            }

            var value = await _tagDal.AddAsync(ObjectMapper.mapper.Map<Tag>(entity));
            await _uow.CommitAsync();
            if (value?.Id == null)
            {
                return Response<CreateTagDto>.Fail("Veri eklenemedi", ResponseType.Fail);
            }
            return Response<CreateTagDto>.Success(entity, ResponseType.Success);
        }

        public async Task<Response<NoContent>> TDelete(int id)
        {
            var value = await _tagDal.GetByIdAsync(id);
            if (value?.Id == null)
            {
                return Response<NoContent>.Fail("Veri silinemedi", ResponseType.Fail);
            }
            _tagDal.Delete(value);
            _uow.Commit();
            return Response<NoContent>.Success(ResponseType.Success);
        }

        public async Task<Response<List<ResultTagDto>>> TGetAllAsync()
        {
            var values = await _tagDal.GetAllAsync();
            if (values?.Count < 1)
            {
                return Response<List<ResultTagDto>>.Fail("Veri getirilemedi", ResponseType.Fail);
            }
            return Response<List<ResultTagDto>>.Success(ObjectMapper.mapper.Map<List<ResultTagDto>>(values), ResponseType.Success);
        }

        public async Task<Response<ResultTagDto>> TGetByIdAsync(int id)
        {
            var value = await _tagDal.GetByIdAsync(id);
            if (value?.Id == null)
            {
                return Response<ResultTagDto>.Fail("Veri getirilemedi", ResponseType.Fail);
            }
            return Response<ResultTagDto>.Success(ObjectMapper.mapper.Map<ResultTagDto>(value), ResponseType.Success);
        }

        public Response<UpdateTagDto> TUpdate(UpdateTagDto entity)
        {
            var validate = _updateValidator.Validate(entity);
            List<ValidationError> errors = new List<ValidationError>();
            if (!validate.IsValid)
            {
                foreach (var item in validate.Errors)
                {
                    errors.Add(new ValidationError { Code = item.ErrorCode, Message = item.ErrorMessage, Property = item.PropertyName });
                }
                return Response<UpdateTagDto>.ValidatorErr(errors, ResponseType.ValidationError);
            }
            var value = _tagDal.Update(ObjectMapper.mapper.Map<Tag>(entity));
            if (value?.Id == null)
            {
                return Response<UpdateTagDto>.Fail("Güncelleme başarısız.", ResponseType.Fail);
            }
            return Response<UpdateTagDto>.Success(entity, ResponseType.Success);
        }
    }
}
