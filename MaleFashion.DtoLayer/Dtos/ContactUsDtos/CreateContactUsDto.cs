using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.DtoLayer.Dtos.ContactUsDtos
{
    public class CreateContactUsDto
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String Message { get; set; }
    }
}
