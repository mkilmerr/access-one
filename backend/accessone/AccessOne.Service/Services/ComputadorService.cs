using AccessOne.Domain.Entities;
using AccessOne.Infra.Data.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace AccessOne.Service.Services
{
    public class ComputadorService
    {
        private ComputadorRepository<Computador> repository = new ComputadorRepository<Computador> ();

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            repository.Delete(id);
        }

        public Computador Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            return repository.Select(id);
        }

        public IList<Computador> Get()
        {
            return repository.Select();
        }

        public Computador Post<V>(Computador obj) where V : AbstractValidator<Computador>
        {
            Validate(obj, Activator.CreateInstance<V>());
            repository.Insert(obj);
            return obj;
        }

        public Computador Put<V>(Computador obj) where V : AbstractValidator<Computador>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        private void Validate(Computador obj, AbstractValidator<Computador> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
