using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Context;
using WebApplication.Models;

namespace WebApplication.DAL.Cadastros
{
    public class SecretarioDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Secretario> ObterSecretariosClassificadosPorDataAdmissao()
        {
            return context.Secretarios.OrderBy(b => b.Dt_admissao);
        }
        public Secretario ObterSecretarioPorId(long id)
        {
            return context.Secretarios.Where(f => f.UsuarioId == id).First();
        }
        public void GravarSecretario(Secretario secretario)
        {
            if (secretario.UsuarioId == 0)
            {
                context.Secretarios.Add(secretario);
            }
            else
            {
                context.Entry(secretario).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Secretario EliminarSecretarioPorId(long id)
        {
            Secretario secretario = ObterSecretarioPorId(id);
            context.Secretarios.Remove(secretario);
            context.SaveChanges();
            return secretario;
        }
    }
}