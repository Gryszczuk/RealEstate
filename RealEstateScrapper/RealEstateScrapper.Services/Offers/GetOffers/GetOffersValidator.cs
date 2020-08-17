using FluentValidation;
using RealEstateScrapper.Services.Repositories;

namespace RealEstateScrapper.Services.Offers.GetOffers
{
    public class GetOffersValidator : AbstractValidator<GetOffersQuery>
    {
        public GetOffersValidator(ICityRepository repository)
        {
            RuleFor(x => x.City)
                .MustAsync(async (name, token) => await repository.GetCityDetails(name) != null)
                .When(x => x.City != null)
                .WithMessage("City with given name does not exists");
        }
    }
}
