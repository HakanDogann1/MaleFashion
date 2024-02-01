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


namespace MaleFashion.BusinessLayer.Concrete
{
    public class AboutQuestionManager : IAboutQuestionService
    {
        private readonly IAboutQuestionDal _aboutQuestionDal;
        private readonly IUow _uow;

        public AboutQuestionManager(IAboutQuestionDal aboutQuestionDal, IUow uow)
        {
            _aboutQuestionDal = aboutQuestionDal;
            _uow = uow;
        }

        public async Task<Response<CreateAboutQuestionDto>> TAddAsync(CreateAboutQuestionDto entity)
        {
            var newEntity = ObjectMapper.mapper.Map<AboutQuestion>(entity);
            var value = await _aboutQuestionDal.AddAsync(newEntity);
            await _uow.CommitAsync();

            if(value != null)
            {
                return Response<CreateAboutQuestionDto>.Success(entity, ResponseType.Success);
            }
            return Response<CreateAboutQuestionDto>.Fail("Kayıt işlemi başarısız.",ResponseType.Fail);
        }

        public async Task<Response<NoContent>> TDelete(int id)
        {
            var value = await _aboutQuestionDal.GetByIdAsync(id);
            _aboutQuestionDal.Delete(value.First());
            _uow.Commit();
            var newValue = await _aboutQuestionDal.GetByIdAsync(id);
            if (!newValue.Any())
            {
                return Response<NoContent>.Fail("Silme işlemi başarısız.", ResponseType.Fail);
            }
            return Response<NoContent>.Success(ResponseType.Success);
        }

        public async Task<Response<List<ResultAboutQuestionDto>>> TGetAllAsync()
        {
            var values = await _aboutQuestionDal.GetAllAsync();
            var newValues = ObjectMapper.mapper.Map<List<ResultAboutQuestionDto>>(values);

            if (!newValues.Any())
            {
                return Response<List<ResultAboutQuestionDto>>.Fail("Liste getirilemedi.", ResponseType.Fail);
            }
            return Response<List<ResultAboutQuestionDto>>.Success(newValues, ResponseType.Success);
        }

        public async Task<Response<IEnumerable<ResultAboutQuestionDto>>> TGetByIdAsync(int id)
        {
            var value = await _aboutQuestionDal.GetByIdAsync(id);
            var newValue = ObjectMapper.mapper.Map<IEnumerable<ResultAboutQuestionDto>>(value);
            if(!newValue.Any())
            {
                return Response<IEnumerable<ResultAboutQuestionDto>>.Fail("Liste getirilemedi.", ResponseType.Fail);
            }
            return Response<IEnumerable<ResultAboutQuestionDto>>.Success(newValue, ResponseType.Success);
        }

        public Response<UpdateAboutQuestionDto> TUpdateAsync(UpdateAboutQuestionDto entity)
        {
            var newEntity = ObjectMapper.mapper.Map<AboutQuestion>(entity);
            var value = _aboutQuestionDal.UpdateAsync(newEntity);
            _uow.Commit();

            if(value != null)
            {
                return Response<UpdateAboutQuestionDto>.Success(entity, ResponseType.Success);
            }
            return Response<UpdateAboutQuestionDto>.Fail("Güncelleme işlemi başarısız.", ResponseType.Fail);
        }
    }
}
