using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Context;
using WebApplication.Models;

namespace WebApplication.DAL.Cadastros
{
    public class ClienteDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Cliente> ObterClientesClassificadosPorCpf()
        {
            return context.Clientes.OrderBy(b => b.Cpf);
        }
        public Cliente ObterClientePorId(long id)
        {
            return context.Clientes.Where(f => f.UsuarioId == id).First();
        }
        public void GravarCliente(Cliente cliente)
        {
            if (cliente.UsuarioId == 0)
            {
                context.Clientes.Add(cliente);
            }
            else
            {
                context.Entry(cliente).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Cliente EliminarClientePorId(long id)
        {
            Cliente cliente = ObterClientePorId(id);
            context.Clientes.Remove(cliente);
            context.SaveChanges();
            return cliente;
        }
    }
}