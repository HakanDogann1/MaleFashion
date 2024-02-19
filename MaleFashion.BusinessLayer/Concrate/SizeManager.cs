using FluentValidation;
using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.DataAccessLayer.Abstract;
using MaleFashion.DataAccessLayer.EntityFramework;
using MaleFashion.DataAccessLayer.UnitOfWork;
using MaleFashion.DtoLayer.Dtos.SizeDtos;
using MaleFashion.EntityLayer.Concrete;
using MaleFashion.SharedLayer.Enums;
using MaleFashion.SharedLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaleFashion.BusinessLayer.Mapping;

namespace MaleFashion.BusinessLayer.Concrate
{
    public class SizeManager:ISizeService
    {
        private readonly ISizeDal _sizeDal;
        private readonly IValidator<CreateSizeDto> _createValidator;
        private readonly IValidator<UpdateSizeDto> _updateValidator;
        private readonly IUow _uow;

        public SizeManager(ISizeDal sizeDal, IValidator<CreateSizeDto> createValidator, IValidator<UpdateSizeDto> updateValidator, IUow uow)
        {
            _sizeDal = sizeDal;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _uow = uow;
        }
        public async Task<Response<CreateSizeDto>> TAddAsync(CreateSizeDto entity)
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

                return Response<CreateSizeDto>.ValidatorErr(validationError, ResponseType.ValidationError);
            }

            var value = await _sizeDal.AddAsync(ObjectMapper.mapper.Map<Size>(entity));
            await _uow.CommitAsync();
            if (value?.Id == null)
            {
                return Response<CreateSizeDto>.Fail("Veri eklenemedi", ResponseType.Fail);
            }
            return Response<CreateSizeDto>.Success(entity, ResponseType.Success);
        }

        public async Task<Response<NoContent>> TDelete(int id)
        {
            var value = await _sizeDal.GetByIdAsync(id);
            if (value?.Id == null)
            {
                return Response<NoContent>.Fail("Veri silinemedi", ResponseType.Fail);
            }
            _sizeDal.Delete(value);
            _uow.Commit();
            return Response<NoContent>.Success(ResponseType.Success);
        }

        public async Task<Response<List<ResultSizeDto>>> TGetAllAsync()
        {
            var values = await _sizeDal.GetAllAsync();
            if (values?.Count < 1)
            {
                return Response<List<ResultSizeDto>>.Fail("Veri getirilemedi", ResponseType.Fail);
            }
            return Response<List<ResultSizeDto>>.Success(ObjectMapper.mapper.Map<List<ResultSizeDto>>(values), ResponseType.Success);
        }

        public async Task<Response<ResultSizeDto>> TGetByIdAsync(int id)
        {
            var value = await _sizeDal.GetByIdAsync(id);
            if (value?.Id == null)
            {
                return Response<ResultSizeDto>.Fail("Veri getirilemedi", ResponseType.Fail);
            }
            return Response<ResultSizeDto>.Success(ObjectMapper.mapper.Map<ResultSizeDto>(value), ResponseType.Success);
        }

        public Response<UpdateSizeDto> TUpdate(UpdateSizeDto entity)
        {
            var validate = _updateValidator.Validate(entity);
            List<ValidationError> errors = new List<ValidationError>();
            if (!validate.IsValid)
            {
                foreach (var item in validate.Errors)
                {
                    errors.Add(new ValidationError { Code = item.ErrorCode, Message = item.ErrorMessage, Property = item.PropertyName });
                }
                return Response<UpdateSizeDto>.ValidatorErr(errors, ResponseType.ValidationError);
            }
            var value = _sizeDal.Update(ObjectMapper.mapper.Map<Size>(entity));
            if (value?.Id == null)
            {
                return Response<UpdateSizeDto>.Fail("Güncelleme başarısız.", ResponseType.Fail);
            }
            return Response<UpdateSizeDto>.Success(entity, ResponseType.Success);
        }
    }
}
