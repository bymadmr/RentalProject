using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public  class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(p=>p.Name).NotEmpty().WithMessage("Marka ismi boş olamaz!");
            RuleFor(p => p.Name).MinimumLength(2);
            //RuleFor(p => p.Name).Must(StartWithA);
        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
