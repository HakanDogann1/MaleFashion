using MaleFashion.SharedLayer;
using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.DataAccessLayer.Abstract;
using MaleFashion.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaleFashion.DtoLayer.Dtos.AboutQuestionDtos;
using MaleFashion.BusinessLayer.Mapping;
using MaleFashion.SharedLayer.Enums;
using MaleFashion.DataAccessLayer.UnitOfWork;
using FluentValidation;


namespace MaleFashion.BusinessLayer.Concrate
{
    public class AboutQuestionManager : IAboutQuestionService
    {
        private readonly IAboutQuestionDal _aboutQuestionDal;
        private readonly IUow _uow;
        private readonly IValidator<CreateAboutQuestionDto> _createValidator;
        private readonly IValidator<UpdateAboutQuestionDto> _updateValidator;

        public AboutQuestionManager(IAboutQuestionDal aboutQuestionDal, IUow uow, IValidator<CreateAboutQuestionDto> createValidator, IValidator<UpdateAboutQuestionDto> updateValidator)
        {
            _aboutQuestionDal = aboutQuestionDal;
            _uow = uow;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<Response<CreateAboutQuestionDto>> TAddAsync(CreateAboutQuestionDto entity)
        {
            var newEntity = ObjectMapper.mapper.Map<AboutQuestion>(entity);
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
                return Response<CreateAboutQuestionDto>.ValidatorErr(error, ResponseType.ValidationError);
            }
            var value = await _aboutQuestionDal.AddAsync(newEntity);
            await _uow.CommitAsync();

            if (value != null)
            {
                return Response<CreateAboutQuestionDto>.Success(entity, ResponseType.Success);
            }
            return Response<CreateAboutQuestionDto>.Fail("Kayıt işlemi başarısız.", ResponseType.Fail);
        }

        public async Task<Response<NoContent>> TDelete(int id)
        {
            var value = await _aboutQuestionDal.GetByIdAsync(id);
            _aboutQuestionDal.Delete(value);
            _uow.Commit();

            if (value == null)
            {
                return Response<NoContent>.Fail("Silme işlemi başarısız.", ResponseType.Fail);
            }
            return Response<NoContent>.Success(ResponseType.Success);
        }

        public async Task<Response<List<ResultAboutQuestionDto>>> TGetAllAsync()
        {
            var values = await _aboutQuestionDal.GetAllAsync();
            var newValues = ObjectMapper.mapper.Map<List<ResultAboutQuestionDto>>(values);

            if (values != null)
            {
                return Response<List<ResultAboutQuestionDto>>.Success(newValues, ResponseType.Success);
            }
            return Response<List<ResultAboutQuestionDto>>.Fail("Liste getirilemedi.", ResponseType.Fail);
        }

        public async Task<Response<ResultAboutQuestionDto>> TGetByIdAsync(int id)
        {
            var value = await _aboutQuestionDal.GetByIdAsync(id);
            var newValue = ObjectMapper.mapper.Map<ResultAboutQuestionDto>(value);
            if (newValue == null)
            {
                return Response<ResultAboutQuestionDto>.Fail("Liste getirilemedi.", ResponseType.Fail);
            }
            return Response<ResultAboutQuestionDto>.Success(newValue, ResponseType.Success);
        }

        public Response<UpdateAboutQuestionDto> TUpdate(UpdateAboutQuestionDto entity)
        {
            var newEntity = ObjectMapper.mapper.Map<AboutQuestion>(entity);
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
                return Response<UpdateAboutQuestionDto>.ValidatorErr(error, ResponseType.ValidationError);
            }
            var value = _aboutQuestionDal.Update(newEntity);
            _uow.Commit();

            if (value != null)
            {
                return Response<UpdateAboutQuestionDto>.Success(entity, ResponseType.Success);
            }
            return Response<UpdateAboutQuestionDto>.Fail("Güncelleme işlemi başarısız.", ResponseType.Fail);
        }
    }
}
