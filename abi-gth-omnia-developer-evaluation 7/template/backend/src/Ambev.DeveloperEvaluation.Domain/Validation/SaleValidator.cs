using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(sale => sale.Customer).NotEmpty().Length(3, 50);
        RuleFor(x => x.SaleNumber).GreaterThan(0);
        RuleFor(x => x.Branch).NotEmpty().MaximumLength(100);
        RuleFor(x => x.SaleDate).LessThanOrEqualTo(DateTime.Now);
        RuleFor(x => x.Product).NotEmpty().Must(x => x.Count > 0);
        RuleForEach(x => x.Product).SetValidator(new SaleProductValidator());
        RuleFor(x => x.Items).NotEmpty().Must(x => x.Count > 0);
    }
}

public class SaleProductValidator : AbstractValidator<Product>
{
    public SaleProductValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Category).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.UnitPrice).GreaterThan(0);
        RuleFor(x => x.Discount).GreaterThanOrEqualTo(0).LessThanOrEqualTo(x => x.UnitPrice * x.Quantity);
    }
}