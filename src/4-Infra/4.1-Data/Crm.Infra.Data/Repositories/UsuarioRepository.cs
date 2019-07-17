using Crm.Domain.Interfaces.Repositories;
using Crm.Domain.Models.Usuarios;
using Crm.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Crm.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CrmContext Db;

        public UsuarioRepository(CrmContext context)
        {
            Db = context;
        }

        public void Add(Usuario obj)
        {
            Db.Set<Usuario>().Add(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return Db.Usuarios
                .ToList();
        }

        public Usuario GetById(int id)
        {
            return Db.Set<Usuario>()
                .Find(id);
        }

        public Usuario GetByLogin(string login)
        {
            return Db
                .Set<Usuario>()
                .FirstOrDefault(x => x.Login == login);
        }

        public void Remove(Usuario obj)
        {
            Db.Remove(obj);
            Db.SaveChanges();
        }

        public void Update(Usuario obj)
        {
            Db.Update(obj);
            Db.SaveChanges();
        }
    }
}