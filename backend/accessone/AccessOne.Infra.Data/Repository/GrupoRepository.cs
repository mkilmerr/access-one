using AccessOne.Domain.Entities;
using AccessOne.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AccessOne.Infra.Data.Repository
{
    public class GrupoRepository<T>
    {
        private AccessOneContext context = new AccessOneContext();

        public void Delete(int id)
        {
            var grupo = context.Computadores.SingleOrDefault(c => c.Id == id);
            context.Computadores.Remove(grupo);
            context.SaveChanges();
        }

        public void Insert(Grupo obj)
        {
            context.Grupos.Add(obj);
            context.SaveChanges();
        }

        public Grupo Select(int id)
        {
            return context.Grupos.SingleOrDefault(c => c.Id == id);
        }

        public IList<Grupo> Select()
        {
            return context.Grupos.ToList();
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
