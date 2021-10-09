using CalidadT2.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositories
{
    public interface IAuthRepositorio
    {
        Usuario ObtenerUsuario(string nombreusario, string contrasenia);
    }
    public class AuthRepositorio : IAuthRepositorio
    {
        private IAppBibliotecaContext BibContext;
        public AuthRepositorio(IAppBibliotecaContext BibContext)
        {
            this.BibContext = BibContext;
        }

        public Usuario ObtenerUsuario(string nombreusario, string contrasenia)
        {
            var usuario = BibContext.Usuarios.Where(o => o.Username == nombreusario && o.Password == contrasenia).FirstOrDefault();
            return usuario;
        }
    }
}
