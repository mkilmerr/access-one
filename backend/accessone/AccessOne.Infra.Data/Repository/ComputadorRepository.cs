using AccessOne.Domain.Entities;
using AccessOne.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AccessOne.Infra.Data.Repository
{
    public class ComputadorRepository<T>
    {
        private AccessOneContext context = new AccessOneContext();

        public void Delete(int id)
        {
            var computador = context.Computadores.SingleOrDefault(c => c.Id == id);
            context.Computadores.Remove(computador);
            context.SaveChanges();
        }

        public void Insert(Computador obj)
        {
            context.Computadores.Add(obj);
            context.SaveChanges();
        }

        public Computador Select(int id)
        {
            return context.Computadores.Include(cm => cm.Comandos).SingleOrDefault(c => c.Id == id);
        }

        public IList<Computador> Select()
        {
            return context.Computadores.Include(cm => cm.Comandos).ToList();
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
