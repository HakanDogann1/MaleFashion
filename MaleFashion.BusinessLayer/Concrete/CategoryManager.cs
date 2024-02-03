using FluentValidation;
using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Mapping;
using MaleFashion.DataAccessLayer.Abstract;
using MaleFashion.DataAccessLayer.UnitOfWork;
using MaleFashion.DtoLayer.Dtos.CategoryDtos;
using MaleFashion.EntityLayer.Concrete;
using MaleFashion.SharedLayer;
using MaleFashion.SharedLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IUow _uow;
        private readonly IValidator<CreateCategoryDto> _createValidator;
        private readonly IValidator<UpdateCategoryDto> _updateValidator;
        public CategoryManager(ICategoryDal categoryDal, IUow uow, IValidator<CreateCategoryDto> createValidator, IValidator<UpdateCategoryDto> updateValidator)
        {
            _categoryDal = categoryDal;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<Response<CreateCategoryDto>> TAddAsync(CreateCategoryDto entity)
        {
            var newEntity = ObjectMapper.mapper.Map<Category>(entity);
            var validate = _createValidator.Validate(entity);
            if (!validate.IsValid)
            {
                List<ValidationError> errors = new List<ValidationError>();
                foreach (var error in validate.Errors)
                {
                    errors.Add(new ValidationError { Code = error.ErrorCode, Message = error.ErrorMessage, Property = error.PropertyName });
                }

                return Response<CreateCategoryDto>.ValidatorErr(errors,ResponseType.ValidationError);
            }
            var value = await _categoryDal.AddAsync(newEntity);
            if(value != null)
            {
                return Response<CreateCategoryDto>.Success(entity,ResponseType.Success);
            }
            return Response<CreateCategoryDto>.Fail("Ekleme işlemi başarısız.",ResponseType.Fail);
            
        }

        public Task<Response<NoContent>> TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ResultCategoryDto>>> TGetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<ResultCategoryDto>> TGetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Response<UpdateCategoryDto> TUpdate(UpdateCategoryDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
