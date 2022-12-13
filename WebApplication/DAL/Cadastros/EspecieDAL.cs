using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Context;
using WebApplication.Models;

namespace WebApplication.DAL.Cadastros
{
    public class EspecieDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Especie> ObterEspeciesClassificadasPorId()
        {
            return context.Especies.OrderBy(b => b.EspecieId);
        }

        public Especie ObterEspeciePorId(long id)
        {
            return context.Especies.Where(c => c.EspecieId == id).First();
        }
        public void GravarEspecie(Especie especie)
        {
            if (especie.EspecieId == 0)
            {
                context.Especies.Add(especie);
            }
            else
            {
                context.Entry(especie).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Especie EliminarEspeciePorId(long id)
        {
            Especie especie = ObterEspeciePorId(id);
            context.Especies.Remove(especie);
            context.SaveChanges();
            return especie;
        }
    }
}