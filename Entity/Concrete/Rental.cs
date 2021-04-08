using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Rental:IEntity
    {
        public int RentalId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateTime TakeDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
