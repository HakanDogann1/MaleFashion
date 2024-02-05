using FluentValidation;
using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Mapping;
using MaleFashion.DataAccessLayer.Abstract;
using MaleFashion.DataAccessLayer.UnitOfWork;
using MaleFashion.DtoLayer.Dtos.AboutQuestionDtos;
using MaleFashion.DtoLayer.Dtos.HeaderDtos;
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
    public class HeaderManager : IHeaderService
    {
        private readonly IHeaderDal _headerDal;
        private readonly IUow _uow;
        private readonly IValidator<CreateHeaderDto> _createValidator;
        private readonly IValidator<UpdateHeaderDto> _updateValidator;

        public HeaderManager(IHeaderDal headerDal, IUow uow, IValidator<CreateHeaderDto> createValidator, IValidator<UpdateHeaderDto> updateValidator)
        {
            _headerDal = headerDal;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<Response<CreateHeaderDto>> TAddAsync(CreateHeaderDto entity)
        {
            var newEntity = ObjectMapper.mapper.Map<Header>(entity);
            var validate = _createValidator.Validate(entity);
            if (!validate.IsValid)
            {
                List<ValidationError> error = new List<ValidationError>();
                foreach (var item in validate.Errors)
                {
                    error.Add(new ValidationError
                    {
                        Property = item.PropertyName,
                        Message = item.ErrorMessage,
                        Code = item.ErrorCode
                    });

                }
                return Response<CreateHeaderDto>.ValidatorErr(error, ResponseType.ValidationError);
            }
            var value = await _headerDal.AddAsync(newEntity);
            await _uow.CommitAsync();

            if (value != null)
            {
                return Response<CreateHeaderDto>.Success(entity, ResponseType.Success);
            }
            return Response<CreateHeaderDto>.Fail("Kayıt işlemi başarısız.", ResponseType.Fail);
        }

        public async Task<Response<NoContent>> TDelete(int id)
        {
            var value = await _headerDal.GetByIdAsync(id);
            _headerDal.Delete(value);
            _uow.Commit();

            if (value == null)
            {
                return Response<NoContent>.Fail("Silme işlemi başarısız.", ResponseType.Fail);
            }
            return Response<NoContent>.Success(ResponseType.Success);
        }

        public async Task<Response<List<ResultHeaderDto>>> TGetAllAsync()
        {
            var values = await _headerDal.GetAllAsync();
            var newValues = ObjectMapper.mapper.Map<List<ResultHeaderDto>>(values);

            if (values != null)
            {
                return Response<List<ResultHeaderDto>>.Success(newValues, ResponseType.Success);
            }
            return Response<List<ResultHeaderDto>>.Fail("Liste getirilemedi.", ResponseType.Fail);
        }

        public async Task<Response<ResultHeaderDto>> TGetByIdAsync(int id)
        {
            var value = await _headerDal.GetByIdAsync(id);
            var newValue = ObjectMapper.mapper.Map<ResultHeaderDto>(value);
            if (newValue == null)
            {
                return Response<ResultHeaderDto>.Fail("Liste getirilemedi.", ResponseType.Fail);
            }
            return Response<ResultHeaderDto>.Success(newValue, ResponseType.Success);
        }

        public Response<UpdateHeaderDto> TUpdate(UpdateHeaderDto entity)
        {
            var newEntity = ObjectMapper.mapper.Map<Header>(entity);
            var validate = _updateValidator.Validate(entity);
            List<ValidationError> error = new List<ValidationError>();
            if (!validate.IsValid)
            {
                foreach (var item in validate.Errors)
                {
                    error.Add(new ValidationError
                    {
                        Property = item.PropertyName,
                        Message = item.ErrorMessage,
                        Code = item.ErrorCode
                    });

                }
                return Response<UpdateHeaderDto>.ValidatorErr(error, ResponseType.ValidationError);
            }
            var value = _headerDal.Update(newEntity);
            _uow.Commit();

            if (value != null)
            {
                return Response<UpdateHeaderDto>.Success(entity, ResponseType.Success);
            }
            return Response<UpdateHeaderDto>.Fail("Güncelleme işlemi başarısız.", ResponseType.Fail);
        }
    }
}
