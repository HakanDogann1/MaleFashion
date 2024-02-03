using MaleFashion.SharedLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Abstract
{
    public interface IGenericService<TResult,TUpdt,TCreate>
    {
        Task<Response<TCreate>> TAddAsync(TCreate entity);
        Response<TUpdt> TUpdate(TUpdt entity);
        Task<Response<NoContent>> TDelete(int id);
        Task<Response<TResult>> TGetByIdAsync(int id);
        Task<Response<List<TResult>>> TGetAllAsync();
    }
}
