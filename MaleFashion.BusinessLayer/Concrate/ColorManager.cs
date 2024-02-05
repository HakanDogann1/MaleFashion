using MaleFashion.BusinessLayer.Abstract;
using MaleFashion.DataAccessLayer.Abstract;
using MaleFashion.DtoLayer.Dtos.ColorDtos;
using MaleFashion.SharedLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Concrate
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public Task<Response<CreateColorDto>> TAddAsync(CreateColorDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoContent>> TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ResultColorDto>>> TGetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<ResultColorDto>> TGetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Response<UpdateColorDto> TUpdate(UpdateColorDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
