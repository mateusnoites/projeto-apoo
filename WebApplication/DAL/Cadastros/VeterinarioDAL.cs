using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Context;
using WebApplication.Models;

namespace WebApplication.DAL.Cadastros
{
    public class VeterinarioDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Veterinario> ObterVeterinariosClassificadosPorCrmv()
        {
            return context.Veterinarios.OrderBy(b => b.Crmv);
        }
        public Veterinario ObterVeterinarioPorId(long id)
        {
            return context.Veterinarios.Where(f => f.UsuarioId == id).First();
        }
        public void GravarVeterinario(Veterinario veterinario)
        {
            if (veterinario.UsuarioId == 0)
            {
                context.Veterinarios.Add(veterinario);
            }
            else
            {
                context.Entry(veterinario).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Veterinario EliminarVeterinarioPorId(long id)
        {
            Veterinario veterinario = ObterVeterinarioPorId(id);
            context.Veterinarios.Remove(veterinario);
            context.SaveChanges();
            return veterinario;
        }
    }
}