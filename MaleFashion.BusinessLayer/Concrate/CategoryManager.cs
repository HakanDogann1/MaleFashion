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

namespace MaleFashion.BusinessLayer.Concrate
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

        public async Task<Response<NoContent>> TDelete(int id)
        {
            var value = await _categoryDal.GetByIdAsync(id);
            if(value == null)
            {
                return Response<NoContent>.Fail("id bulunamadı.", ResponseType.Fail);
            }
            _categoryDal.Delete(value);
            _uow.Commit();
            return Response<NoContent>.Success(ResponseType.Success);
        }

        public async Task<Response<List<ResultCategoryDto>>> TGetAllAsync()
        {
            var value = await _categoryDal.GetAllAsync();
            
            if(value != null)
            {
                var newValue = ObjectMapper.mapper.Map<List<ResultCategoryDto>>(value);
                return Response<List<ResultCategoryDto>>.Success(newValue, ResponseType.Success);
            }
            return Response<List<ResultCategoryDto>>.Fail("Kategori listelenemedi.", ResponseType.Fail);
        }

        public async Task<Response<ResultCategoryDto>> TGetByIdAsync(int id)
        {
            var value = await _categoryDal.GetByIdAsync(id);
            var newValue = ObjectMapper.mapper.Map<ResultCategoryDto>(value);
            if(value != null)
            {
                return Response<ResultCategoryDto>.Success(newValue, ResponseType.Success);
            }
            return Response<ResultCategoryDto>.Fail("Bu id ait veri bulunamadı",ResponseType.Fail);
        }

        public Response<UpdateCategoryDto> TUpdate(UpdateCategoryDto entity)
        {
            var newEntity = ObjectMapper.mapper.Map<Category>(entity);
            var value = _categoryDal.Update(newEntity);
            if(value != null)
            {
                return Response<UpdateCategoryDto>.Success(entity, ResponseType.Success);
            }
            return Response<UpdateCategoryDto>.Fail("Güncelleme başarısız.", ResponseType.Fail);
        }
    }
}
