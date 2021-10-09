using CalidadT2.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositories
{
    public interface IHomeRepositorio
    {
        List<Libro> TodosLibros();
    }
    public class HomeRepositorio : IHomeRepositorio
    {
        private IAppBibliotecaContext BibContext;

        public HomeRepositorio(IAppBibliotecaContext BibContext)
        {
            this.BibContext = BibContext;
        }

        public List<Libro> TodosLibros()
        {
            var libros = BibContext.Libros.Include(o => o.Autor).ToList();
            return libros;
        }
    }
}
