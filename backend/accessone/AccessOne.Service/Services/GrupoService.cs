using AccessOne.Domain.Entities;
using AccessOne.Infra.Data.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace AccessOne.Service.Services
{
    public class GrupoService
    {
        private GrupoRepository<Grupo> repository = new GrupoRepository<Grupo>();

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            repository.Delete(id);
        }

        public Grupo Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            return repository.Select(id);
        }

        public IList<Grupo> Get()
        {
            return repository.Select();
        }

        public Grupo Post<V>(Grupo obj) where V : AbstractValidator<Grupo>
        {
            Validate(obj, Activator.CreateInstance<V>());
            repository.Insert(obj);
            return obj;
        }

        public Grupo Put<V>(Grupo obj) where V : AbstractValidator<Grupo>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        private void Validate(Grupo obj, AbstractValidator<Grupo> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
