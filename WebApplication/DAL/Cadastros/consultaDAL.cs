using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Context;
using WebApplication.Models;

namespace WebApplication.DAL.Cadastros
{
    public class ConsultaDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Consulta> ObterConsultasClassificadasPorId()
        {
            return context.Consultas.OrderBy(b => b.ConsultaId).Include(e => e.Pet).Include(c => c.Veterinario);
        }

        public Consulta ObterConsultaPorId(long id)
        {
            return context.Consultas.Where(c => c.ConsultaId == id).Include(f => f.Pet).Include(c => c.Veterinario).First();
        }
        public void GravarConsulta(Consulta consulta)
        {
            if (consulta.ConsultaId == 0)
            {
                context.Consultas.Add(consulta);
            }
            else
            {
                context.Entry(consulta).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Consulta EliminarConsultaPorId(long id)
        {
            Consulta consulta = ObterConsultaPorId(id);
            context.Consultas.Remove(consulta);
            context.SaveChanges();
            return consulta;
        }
    }
}