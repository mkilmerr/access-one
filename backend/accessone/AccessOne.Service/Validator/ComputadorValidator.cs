using AccessOne.Domain.Entities;
using FluentValidation;
using System;

namespace AccessOne.Service.Validator
{
    public class ComputadorValidator : AbstractValidator<Computador>
    {
        public ComputadorValidator()
        {
            RuleFor(c => c).NotNull().OnAnyFailure(x =>
            {
                throw new ArgumentNullException("Can't found the object.");
            });

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("É necessário informar o nome.")
                .NotNull().WithMessage("É necessário informar o nome.");

            RuleFor(c => c.Ip)
                .NotEmpty().WithMessage("É necessário informar o ip.")
                .NotNull().WithMessage("É necessário informar o ip.");

            RuleFor(c => c.EspacoEmDisco)
                .NotEmpty().WithMessage("É necessário informar o espaço em disco.")
                .NotNull().WithMessage("É necessário informar o espaço em disco.")
                .GreaterThanOrEqualTo(0).WithMessage("O espaço em disco deve ser maior ou igual a 0");

            RuleFor(c => c.MemoriaDisponivel)
                .NotEmpty().WithMessage("É necessário informar a memória disponível.")
                .NotNull().WithMessage("É necessário informar a memória disponível.")
                .GreaterThan(0).WithMessage("A memória disponível deve ser maior ou igual a 0");

            RuleFor(c => c.Grupo)
                .NotEmpty().WithMessage("É necessário informar o grupo.")
                .NotNull().WithMessage("É necessário informar o grupo.");
        }
    }
}
