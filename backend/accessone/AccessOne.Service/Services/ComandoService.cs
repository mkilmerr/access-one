using AccessOne.Domain.Entities;
using AccessOne.Infra.Data.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace AccessOne.Service.Services
{
    public class ComandoService
    {
        private ComandoRepository<Comando> repository = new ComandoRepository<Comando>();

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            repository.Delete(id);
        }

        public Comando Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            return repository.Select(id);
        }

        public IList<Comando> Get()
        {
            return repository.Select();
        }

        public Comando Post<V>(Comando obj) where V : AbstractValidator<Comando>
        {
            Validate(obj, Activator.CreateInstance<V>());
            repository.Insert(obj);
            return obj;
        }

        public Comando Put<V>(Comando obj) where V : AbstractValidator<Comando>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        private void Validate(Comando obj, AbstractValidator<Comando> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
