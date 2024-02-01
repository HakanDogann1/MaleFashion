using MaleFashion.DtoLayer.Dtos.CommentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Abstract
{
    public interface ICommentService:IGenericService<ResultCommentDto,UpdateCommentDto,CreateCommentDto>
    {
    }
}
