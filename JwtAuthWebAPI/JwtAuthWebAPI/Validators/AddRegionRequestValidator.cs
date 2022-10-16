﻿using FluentValidation;
using JwtAuthWebAPI.Models.DTO;

namespace JwtAuthWebAPI.Validators
{
    public class AddRegionRequestValidator: AbstractValidator<AddRegionRequest>
    {
        public AddRegionRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);
            RuleFor(x => x.Population).GreaterThanOrEqualTo(0);

        }
    }
}
