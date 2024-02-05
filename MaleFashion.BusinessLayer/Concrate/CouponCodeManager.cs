using FluentValidation;
using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Mapping;
using MaleFashion.DataAccessLayer.Abstract;
using MaleFashion.DataAccessLayer.EntityFramework;
using MaleFashion.DataAccessLayer.UnitOfWork;
using MaleFashion.DtoLayer.Dtos.AboutQuestionDtos;
using MaleFashion.DtoLayer.Dtos.CouponCodeDtos;
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
    public class CouponCodeManager : ICouponCodeService
    {
        private readonly ICouponCodeDal _couponCodeDal;
        private readonly IUow _uow;
        private readonly IValidator<CreateCouponCodeDto> _createValidator;
        private readonly IValidator<UpdateCouponCodeDto> _updateValidator;

        public CouponCodeManager(ICouponCodeDal couponCodeDal, IUow uow, IValidator<CreateCouponCodeDto> createValidator, IValidator<UpdateCouponCodeDto> updateValidator)
        {
            _couponCodeDal = couponCodeDal;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<Response<CreateCouponCodeDto>> TAddAsync(CreateCouponCodeDto entity)
        {
            List<ValidationError> errors = new List<ValidationError>();
            var validate = _createValidator.Validate(entity);
            if(!validate.IsValid)
            {
                foreach(var item in validate.Errors)
                {
                    errors.Add(new ValidationError { Code = item.ErrorCode, Message = item.ErrorMessage, Property = item.PropertyName });
                }
                return Response<CreateCouponCodeDto>.ValidatorErr(errors, ResponseType.ValidationError);
            }
            var newEntity = ObjectMapper.mapper.Map<CouponCode>(entity);
            var value = await _couponCodeDal.AddAsync(newEntity);
            await _uow.CommitAsync();
            if(value != null)
            {
                return Response<CreateCouponCodeDto>.Success(entity, ResponseType.Success);
            }
            return Response<CreateCouponCodeDto>.Fail("Ekleme işlemi başarısız.",ResponseType.Fail);
        }

        public async Task<Response<NoContent>> TDelete(int id)
        {
            var value = await _couponCodeDal.GetByIdAsync(id);
            _couponCodeDal.Delete(value);
            if(value != null)
            {
                return Response<NoContent>.Success(ResponseType.Success);
            }
            return Response<NoContent>.Fail("Kupon kodu silinemedi", ResponseType.Fail);
        }

        public async Task<Response<List<ResultCouponCodeDto>>> TGetAllAsync()
        {
            var values = await _couponCodeDal.GetAllAsync();
            var newValues = ObjectMapper.mapper.Map<List<ResultCouponCodeDto>>(values);

            if (values != null)
            {
                return Response<List<ResultCouponCodeDto>>.Success(newValues, ResponseType.Success);
            }
            return Response<List<ResultCouponCodeDto>>.Fail("Liste getirilemedi.", ResponseType.Fail);
        }

        public async Task<Response<ResultCouponCodeDto>> TGetByIdAsync(int id)
        {
            var value = await _couponCodeDal.GetByIdAsync(id);
            var newValue = ObjectMapper.mapper.Map<ResultCouponCodeDto>(value);
            if (newValue == null)
            {
                return Response<ResultCouponCodeDto>.Fail("Liste getirilemedi.", ResponseType.Fail);
            }
            return Response<ResultCouponCodeDto>.Success(newValue, ResponseType.Success);
        }

        public Response<UpdateCouponCodeDto> TUpdate(UpdateCouponCodeDto entity)
        {
            var newEntity = ObjectMapper.mapper.Map<CouponCode>(entity);
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
                return Response<UpdateCouponCodeDto>.ValidatorErr(error, ResponseType.ValidationError);
            }
            var value = _couponCodeDal.Update(newEntity);
            _uow.Commit();

            if (value != null)
            {
                return Response<UpdateCouponCodeDto>.Success(entity, ResponseType.Success);
            }
            return Response<UpdateCouponCodeDto>.Fail("Güncelleme işlemi başarısız.", ResponseType.Fail);
        }
    }
}
