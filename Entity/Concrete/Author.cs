using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Author:IEntity
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
