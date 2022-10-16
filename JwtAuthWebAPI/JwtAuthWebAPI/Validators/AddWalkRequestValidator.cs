using FluentValidation;
using JwtAuthWebAPI.Models.DTO;

namespace JwtAuthWebAPI.Validators
{
    public class AddWalkRequestValidator: AbstractValidator<AddWalkRequest>
    {
        public AddWalkRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
