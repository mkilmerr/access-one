using AccessOne.Domain.Entities;
using AccessOne.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AccessOne.Infra.Data.Repository
{
    public class ComandoRepository<T>
    {
        private AccessOneContext context = new AccessOneContext();

        public void Delete(int id)
        {
            var grupo = context.Comandos.SingleOrDefault(cm => cm.Id == id);
            context.Comandos.Remove(grupo);
            context.SaveChanges();
        }

        public void Insert(Comando obj)
        {
            context.Comandos.Add(obj);
            context.SaveChanges();
        }

        public Comando Select(int id)
        {
            return context.Comandos.SingleOrDefault(c => c.Id == id);
        }

        public IList<Comando> Select()
        {
            return context.Comandos.ToList();
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
