using FluentValidation;
using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.DataAccessLayer.Abstract;
using MaleFashion.DataAccessLayer.EntityFramework;
using MaleFashion.DataAccessLayer.UnitOfWork;
using MaleFashion.DtoLayer.Dtos.TeamDtos;
using MaleFashion.DtoLayer.Dtos.TeamDtos;
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
    public class TeamManager:ITeamService
    {
        private readonly ITeamDal _teamDal;
        private readonly IValidator<CreateTeamDto> _createValidator;
        private readonly IValidator<UpdateTeamDto> _updateValidator;
        private readonly IUow _uow;

        public TeamManager(ITeamDal teamDal, IValidator<CreateTeamDto> createValidator, IValidator<UpdateTeamDto> updateValidator, IUow uow)
        {
            _teamDal = teamDal;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _uow = uow;
        }
        public async Task<Response<CreateTeamDto>> TAddAsync(CreateTeamDto entity)
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

                return Response<CreateTeamDto>.ValidatorErr(validationError, ResponseType.ValidationError);
            }

            var value = await _teamDal.AddAsync(ObjectMapper.mapper.Map<Team>(entity));
            await _uow.CommitAsync();
            if (value?.Id == null)
            {
                return Response<CreateTeamDto>.Fail("Veri eklenemedi", ResponseType.Fail);
            }
            return Response<CreateTeamDto>.Success(entity, ResponseType.Success);
        }

        public async Task<Response<NoContent>> TDelete(int id)
        {
            var value = await _teamDal.GetByIdAsync(id);
            if (value?.Id == null)
            {
                return Response<NoContent>.Fail("Veri silinemedi", ResponseType.Fail);
            }
            _teamDal.Delete(value);
            _uow.Commit();
            return Response<NoContent>.Success(ResponseType.Success);
        }

        public async Task<Response<List<ResultTeamDto>>> TGetAllAsync()
        {
            var values = await _teamDal.GetAllAsync();
            if (values?.Count < 1)
            {
                return Response<List<ResultTeamDto>>.Fail("Veri getirilemedi", ResponseType.Fail);
            }
            return Response<List<ResultTeamDto>>.Success(ObjectMapper.mapper.Map<List<ResultTeamDto>>(values), ResponseType.Success);
        }

        public async Task<Response<ResultTeamDto>> TGetByIdAsync(int id)
        {
            var value = await _teamDal.GetByIdAsync(id);
            if (value?.Id == null)
            {
                return Response<ResultTeamDto>.Fail("Veri getirilemedi", ResponseType.Fail);
            }
            return Response<ResultTeamDto>.Success(ObjectMapper.mapper.Map<ResultTeamDto>(value), ResponseType.Success);
        }

        public Response<UpdateTeamDto> TUpdate(UpdateTeamDto entity)
        {
            var validate = _updateValidator.Validate(entity);
            List<ValidationError> errors = new List<ValidationError>();
            if (!validate.IsValid)
            {
                foreach (var item in validate.Errors)
                {
                    errors.Add(new ValidationError { Code = item.ErrorCode, Message = item.ErrorMessage, Property = item.PropertyName });
                }
                return Response<UpdateTeamDto>.ValidatorErr(errors, ResponseType.ValidationError);
            }
            var value = _teamDal.Update(ObjectMapper.mapper.Map<Team>(entity));
            if (value?.Id == null)
            {
                return Response<UpdateTeamDto>.Fail("Güncelleme başarısız.", ResponseType.Fail);
            }
            return Response<UpdateTeamDto>.Success(entity, ResponseType.Success);
        }
    }
}
