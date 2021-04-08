using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos
{
    public class RentalDetail:IEntity
    {
        public int RentalId { get; set; }
        public string Email { get; set; }
        public string BookName { get; set; }
        public DateTime TakeDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
