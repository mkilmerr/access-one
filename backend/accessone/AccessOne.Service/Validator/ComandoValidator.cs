using AccessOne.Domain.Entities;
using FluentValidation;
using System;

namespace AccessOne.Service.Validator
{
    public class ComandoValidator : AbstractValidator<Comando>
    {
        public ComandoValidator()
        {
            RuleFor(cm => cm).NotNull().OnAnyFailure(x =>
            {
                throw new ArgumentNullException("Can't found the object.");
            });

            RuleFor(cm => cm.ComandoStr)
                .NotEmpty().WithMessage("É necessário informar o comando.")
                .NotNull().WithMessage("É necessário informar o comando.");

            RuleFor(cm => cm.Computador)
                .NotEmpty().WithMessage("É necessário informar o computador.")
                .NotNull().WithMessage("É necessário informar o computador.");

            RuleFor(cm => cm.DataRegistro)
                .NotEmpty().WithMessage("É necessário informar o comando.")
                .NotNull().WithMessage("É necessário informar o comando.");

            RuleFor(cm => cm.DataExecucao)
                .GreaterThanOrEqualTo(cm => cm.DataRegistro).WithMessage("Data de execução deve ser maior que a data de registro");
        }
    }
}
