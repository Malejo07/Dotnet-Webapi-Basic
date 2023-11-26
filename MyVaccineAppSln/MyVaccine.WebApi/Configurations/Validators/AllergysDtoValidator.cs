using FluentValidation;
using MyVaccine.WebApi.Dtos.Allergy;

namespace MyVaccine.WebApi.Configurations.Validators
{
    public class AllergysDtoValidator : AbstractValidator<AllergyRequestDto>
    {
        public AllergysDtoValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().MaximumLength(255);
            RuleFor(dto => dto.UserId).NotEmpty().GreaterThan(0);
        }
    }
}
