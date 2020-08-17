using FluentValidation;
using RealEstateScrapper.Services.Repositories;

namespace RealEstateScrapper.Services.Offers.GetOfferDetails
{
    public class GetOfferDetailsValidator : AbstractValidator<GetOfferDetailsQuery>
    {
        public GetOfferDetailsValidator(IOfferRepository repository)
        {
            RuleFor(x => x.Id)
                .MustAsync(async (id, token) => await repository.GetById(id) != null)
                .WithMessage("Offer with given Id does not exists");
        }
    }
}
