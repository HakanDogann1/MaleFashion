using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.SharedLayer
{
    public class ErrorDto
    {
        public List<String> Errors { get; set; }
        public bool IsShow { get; set; }
        public ErrorDto(String error,bool isShow)
        {
            Errors.Add(error);
            IsShow = isShow;
        }
        public ErrorDto(List<String> errors,bool isShow)
        {
            Errors = errors;
            IsShow = isShow;
        }
    }
}
