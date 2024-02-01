using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.EntityLayer.Concrete
{
    public class Comment
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String CommentDescription { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
