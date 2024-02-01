using AutoMapper;
using MaleFashion.BusinessLayer.Mapping.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.BusinessLayer.Mapping
{
    public class ObjectMapper
    {
        public static Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile<MaleFashionMapping>();
            });
            return config.CreateMapper();
        });

        public static IMapper mapper => lazy.Value;
    }
}
