using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Publisher:IEntity
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
    }
}
