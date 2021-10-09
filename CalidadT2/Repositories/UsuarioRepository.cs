using CalidadT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositories
{
    public interface IUsuarioRepository {
        List<Usuario> GetAll(bool? isDeleted = null);
        void Create(Usuario usuario);
        Usuario FindUserByCredentials(string username, string password);
        List<Usuario> GetAllUserByQuery(string username);
  

    }
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly AppBibliotecaContext context;

        public UsuarioRepository(AppBibliotecaContext context)
        {
            this.context = context;
        }
        public void Create(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario FindUserByCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetAll(bool? isDeleted = null)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetAllUserByQuery(string username)
        {
            throw new NotImplementedException();
        }
    }
}
