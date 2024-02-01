using MaleFashion.DtoLayer.Dtos.SocialMediaDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Abstract
{
    public interface ISocialMediaService : IGenericService<ResultSocialMediaDto,UpdateSocialMediaDto,CreateSocialMediaDto>
    {
    }
}
