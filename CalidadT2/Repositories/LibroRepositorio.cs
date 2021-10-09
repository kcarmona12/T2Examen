using CalidadT2.Models;
 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositories
{
    public interface ILibroRepositorio
    {
        Libro VistaLibroDetalle(int id);
        void GuardarComentario(Comentario comentario, int usuarioId);
    }
    public class LibroRepositorio : ILibroRepositorio
    {
        private readonly IAppBibliotecaContext BibContext;

        public LibroRepositorio(IAppBibliotecaContext BibContext)
        {
            this.BibContext = BibContext;
        }

        public void GuardarComentario(Comentario comentario, int usuarioId)
        {
            comentario.UsuarioId = usuarioId;
            comentario.Fecha = DateTime.Now;
            BibContext.Comentarios.Add(comentario);

            var libro = BibContext.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

            BibContext.SaveChanges();
        }

        public Libro VistaLibroDetalle(int id)
        {
            var model = BibContext.Libros
                .Include("Autor")
                .Include("Comentarios.Usuario")
                .Where(o => o.Id == id)
                .FirstOrDefault();
            return model;
        }
    }
}
