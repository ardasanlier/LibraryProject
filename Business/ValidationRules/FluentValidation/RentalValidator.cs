using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.TakeDate).Equal(DateTime.Now);
            RuleFor(r => r.ReturnDate).LessThan(DateTime.Now);
            RuleFor(r => r.BookName).NotNull();
        }
    }
}
