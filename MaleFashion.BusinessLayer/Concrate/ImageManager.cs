using FluentValidation;
using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Mapping;
using MaleFashion.DataAccessLayer.Abstract;
using MaleFashion.DataAccessLayer.UnitOfWork;
using MaleFashion.DtoLayer.Dtos.ImageDtos;
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
    public class ImageManager : IImageService
    {
        private readonly IImageDal _imageDal;
        private readonly IUow _uow;
        private readonly IValidator<CreateImageDto> _createValidator;
        private readonly IValidator<UpdateImageDto> _updateValidator;

        public ImageManager(IImageDal imageDal, IUow uow, IValidator<CreateImageDto> createValidator, IValidator<UpdateImageDto> updateValidator)
        {
            _imageDal = imageDal;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<Response<CreateImageDto>> TAddAsync(CreateImageDto entity)
        {
            var validate = _createValidator.Validate(entity);
            List<ValidationError> validationError = new List<ValidationError>();
            if(!validate.IsValid)
            {
                foreach (var item in validate.Errors)
                {
                   
                    validationError.Add(
                         new ValidationError() { Code = item.ErrorCode, Message = item.ErrorMessage, Property = item.PropertyName }
                        );
                }

                return Response<CreateImageDto>.ValidatorErr(validationError, ResponseType.ValidationError);
            }

            var value = await _imageDal.AddAsync(ObjectMapper.mapper.Map<Image>(entity));
            await _uow.CommitAsync();
            if(value?.Id==null)
            {
                return Response<CreateImageDto>.Fail("Veri eklenemedi", ResponseType.Fail);
            }
            return Response<CreateImageDto>.Success(entity,ResponseType.Success);
        }

        public async Task<Response<NoContent>> TDelete(int id)
        {
            var value = await _imageDal.GetByIdAsync(id);
            if(value?.Id==null)
            {
                return Response<NoContent>.Fail("Veri silinemedi",ResponseType.Fail);
            }
            _imageDal.Delete(value);
            _uow.Commit();
            return Response<NoContent>.Success(ResponseType.Success);

            
        }

        public async Task<Response<List<ResultImageDto>>> TGetAllAsync()
        {
            var values = await _imageDal.GetAllAsync();
            if (values?.Count < 1)
            {
                return Response<List<ResultImageDto>>.Fail("Veri getirilemedi", ResponseType.Fail);
            }
            return Response<List<ResultImageDto>>.Success(ObjectMapper.mapper.Map<List<ResultImageDto>>(values), ResponseType.Success);
        }

        public async Task<Response<ResultImageDto>> TGetByIdAsync(int id)
        {
            var value = await _imageDal.GetByIdAsync(id);
            if (value?.Id==null)
            {
                return Response<ResultImageDto>.Fail("Veri getirilemedi", ResponseType.Fail);
            }
            return Response<ResultImageDto>.Success(ObjectMapper.mapper.Map<ResultImageDto>(value),ResponseType.Success);
        }

        public Response<UpdateImageDto> TUpdate(UpdateImageDto entity)
        {
            var validate = _updateValidator.Validate(entity);
            List<ValidationError> errors = new List<ValidationError>();
            if(!validate.IsValid)
            {
                foreach (var item in validate.Errors)
                {
                    errors.Add(new ValidationError { Code = item.ErrorCode, Message = item.ErrorMessage, Property = item.PropertyName });
                }
                return Response<UpdateImageDto>.ValidatorErr(errors, ResponseType.ValidationError);
            }
            var value = _imageDal.Update(ObjectMapper.mapper.Map<Image>(entity));
            if (value?.Id==null)
            {
                return Response<UpdateImageDto>.Fail("Güncelleme başarısız.",ResponseType.Fail);
            }
            return Response<UpdateImageDto>.Success(entity,ResponseType.Success);
        }
    }
}
