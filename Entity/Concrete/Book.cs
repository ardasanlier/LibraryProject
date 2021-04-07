using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Book:IEntity
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public string BookName { get; set; }
        public string Publisher { get; set; }
        public int PageCount { get; set; }
        public int CabinetId { get; set; }
        public int ShelfId { get; set; }

    }
}
