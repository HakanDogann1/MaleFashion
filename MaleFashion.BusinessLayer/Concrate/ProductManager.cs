using FluentValidation;
using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.DataAccessLayer.Abstract;
using MaleFashion.DataAccessLayer.EntityFramework;
using MaleFashion.DataAccessLayer.UnitOfWork;
using MaleFashion.DtoLayer.Dtos.ProductDtos;
using MaleFashion.DtoLayer.Dtos.ProductDtos;
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
    public class ProductManager:IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IValidator<CreateProductDto> _createValidator;
        private readonly IValidator<UpdateProductDto> _updateValidator;
        private readonly IUow _uow;

        public ProductManager(IProductDal productDal, IValidator<CreateProductDto> createValidator, IValidator<UpdateProductDto> updateValidator, IUow uow)
        {
            _productDal = productDal;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _uow = uow;
        }
        public async Task<Response<CreateProductDto>> TAddAsync(CreateProductDto entity)
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

                return Response<CreateProductDto>.ValidatorErr(validationError, ResponseType.ValidationError);
            }

            var value = await _productDal.AddAsync(ObjectMapper.mapper.Map<Product>(entity));
            await _uow.CommitAsync();
            if (value?.Id == null)
            {
                return Response<CreateProductDto>.Fail("Veri eklenemedi", ResponseType.Fail);
            }
            return Response<CreateProductDto>.Success(entity, ResponseType.Success);
        }

        public async Task<Response<NoContent>> TDelete(int id)
        {
            var value = await _productDal.GetByIdAsync(id);
            if (value?.Id == null)
            {
                return Response<NoContent>.Fail("Veri silinemedi", ResponseType.Fail);
            }
            _productDal.Delete(value);
            _uow.Commit();
            return Response<NoContent>.Success(ResponseType.Success);
        }

        public async Task<Response<List<ResultProductDto>>> TGetAllAsync()
        {
            var values = await _productDal.GetAllAsync();
            if (values?.Count < 1)
            {
                return Response<List<ResultProductDto>>.Fail("Veri getirilemedi", ResponseType.Fail);
            }
            return Response<List<ResultProductDto>>.Success(ObjectMapper.mapper.Map<List<ResultProductDto>>(values), ResponseType.Success);
        }

        public async Task<Response<ResultProductDto>> TGetByIdAsync(int id)
        {
            var value = await _productDal.GetByIdAsync(id);
            if (value?.Id == null)
            {
                return Response<ResultProductDto>.Fail("Veri getirilemedi", ResponseType.Fail);
            }
            return Response<ResultProductDto>.Success(ObjectMapper.mapper.Map<ResultProductDto>(value), ResponseType.Success);
        }

        public Response<UpdateProductDto> TUpdate(UpdateProductDto entity)
        {
            var validate = _updateValidator.Validate(entity);
            List<ValidationError> errors = new List<ValidationError>();
            if (!validate.IsValid)
            {
                foreach (var item in validate.Errors)
                {
                    errors.Add(new ValidationError { Code = item.ErrorCode, Message = item.ErrorMessage, Property = item.PropertyName });
                }
                return Response<UpdateProductDto>.ValidatorErr(errors, ResponseType.ValidationError);
            }
            var value = _productDal.Update(ObjectMapper.mapper.Map<Product>(entity));
            if (value?.Id == null)
            {
                return Response<UpdateProductDto>.Fail("Güncelleme başarısız.", ResponseType.Fail);
            }
            return Response<UpdateProductDto>.Success(entity, ResponseType.Success);
        }

    }
}
