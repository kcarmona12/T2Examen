using CalidadT2.Constantes;
using CalidadT2.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositories
{
    public interface IBibliotecaRepositorio
    {
        List<Biblioteca> GetBibliotecas(int Id);
        Biblioteca Bibliotec(int libroId, int Id);

        void AgregarBiblioteca(int libro, int Id);

        void Leer(Biblioteca bibliotec);

        void Culminado(Biblioteca bibliotec);
    }
    public class BibliotecaRepositorio : IBibliotecaRepositorio
    {
        private IAppBibliotecaContext BibContext;

        public BibliotecaRepositorio(IAppBibliotecaContext BibContext)
        {
            this.BibContext = BibContext;
        }

        public void AgregarBiblioteca(int libro, int Id)
        {
            var biblioteca = new Biblioteca
            {
                LibroId = libro,
                UsuarioId = Id,
                Estado = ESTADO.POR_LEER
            };

            BibContext.Bibliotecas.Add(biblioteca);
            BibContext.SaveChanges();
        }

        public List<Biblioteca> GetBibliotecas(int Id)
        {
            var model = BibContext.Bibliotecas
                .Include(o => o.Libro.Autor)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == Id)
                .ToList();

            return model;
        }

        public void Leer(Biblioteca bibliotec)
        {
            bibliotec.Estado = ESTADO.LEYENDO;
            BibContext.SaveChanges();
        }

        public void Culminado(Biblioteca bibliotec)
        {
            bibliotec.Estado = ESTADO.LEYENDO;
            BibContext.SaveChanges();
        }

        public Biblioteca Bibliotec(int libroId,int Id)
        {
            var libro = BibContext.Bibliotecas
                .Where(o => o.LibroId == libroId && o.UsuarioId == Id)
                .FirstOrDefault();
            return libro;
        }
    }
}
