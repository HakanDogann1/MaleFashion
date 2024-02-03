using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.BusinessLayer.Mapping;
using MaleFashion.DataAccessLayer.Abstract;
using MaleFashion.DataAccessLayer.UnitOfWork;
using MaleFashion.DtoLayer.Dtos.BlogDtos;
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
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;
        private readonly IUow _uow;

        public BlogManager(IBlogDal blogDal, IUow uow)
        {
            _blogDal = blogDal;
            _uow = uow;
        }

        public async Task<Response<CreateBlogDto>> TAddAsync(CreateBlogDto entity)
        {
            var newEntity = ObjectMapper.mapper.Map<Blog>(entity);
            var value = await _blogDal.AddAsync(newEntity);
            await _uow.CommitAsync();
            if(value == null)
            {
                return Response<CreateBlogDto>.Fail("Blog eklenemedi", ResponseType.Fail);
            }
            return Response<CreateBlogDto>.Success(entity, ResponseType.Success);
        }

        public async Task<Response<NoContent>> TDelete(int id)
        {
            var value = await _blogDal.GetByIdAsync(id);
            _blogDal.Delete(value);
            _uow.Commit();
            if(value == null)
            {
                return Response<NoContent>.Fail("Ürün silinemedi",ResponseType.Fail);
            }
            return Response<NoContent>.Success(ResponseType.Success);

        }

        public async Task<Response<List<ResultBlogDto>>> TGetAllAsync()
        {

            var values = await _blogDal.GetAllAsync();
            var newValues = ObjectMapper.mapper.Map<List<ResultBlogDto>>(values);

            if(newValues != null)
            {
                return Response<List<ResultBlogDto>>.Success(newValues, ResponseType.Success);
            }
            return Response<List<ResultBlogDto>>.Fail("Liste getirilemedi", ResponseType.Fail);
        }

        public async Task<Response<ResultBlogDto>> TGetByIdAsync(int id)
        {
            var value = await _blogDal.GetByIdAsync(id);
            var newValue = ObjectMapper.mapper.Map<ResultBlogDto>(value);

            if(newValue != null)
            {
                return Response<ResultBlogDto>.Success(newValue, ResponseType.Success);
            }
            return Response<ResultBlogDto>.Fail("Veri bulunamadı.", ResponseType.Fail);
        }

        public Response<UpdateBlogDto> TUpdate(UpdateBlogDto entity)
        {
            var newValue = ObjectMapper.mapper.Map<Blog>(entity);
            var value = _blogDal.Update(newValue);
            if(value != null)
            {
                return Response<UpdateBlogDto>.Success(entity, ResponseType.Success);
            }
            return Response<UpdateBlogDto>.Fail("Güncelleme işlemi başarısız.", ResponseType.Fail);
        }
    }
}
