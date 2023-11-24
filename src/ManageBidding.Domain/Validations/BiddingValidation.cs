using FluentValidation;
using ManageBidding.Domain.Models;

namespace ManageBidding.Domain.Validations
{
    public class BiddingValidation : AbstractValidator<Bidding>
    {
        public BiddingValidation()
        {
            RuleFor(b => b.Number)
                .NotEmpty().WithMessage("O número da licitação é obrigatório");

            RuleFor(b => b.Description)
                .Length(10, 1000).WithMessage("A descrição precisa ter entre {MinLength} e {MaxLength} caracteres")
                .NotEmpty().WithMessage("A descrição da licitação é obrigatória.");

            RuleFor(b => b.Status)
                .NotEmpty().WithMessage("O status da licitação é obrigatório.");
        }
    }
}
