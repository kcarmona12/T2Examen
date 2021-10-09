using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalidadT2.Test.Repositories.Mocks
{
    public static class AplicationContextMock
    {
        public static Mock<AppBibliotecaContext> GetApplicationContextMock()
        {
            IQueryable<Usuario> UsuarioData = GetUsuarioData();

            var mockDbSetUsuario = new Mock<DbSet<Usuario>>();
            mockDbSetUsuario.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(UsuarioData.Provider);
            mockDbSetUsuario.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(UsuarioData.Expression);
            mockDbSetUsuario.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(UsuarioData.ElementType);
            mockDbSetUsuario.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(UsuarioData.GetEnumerator());
            mockDbSetUsuario.Setup(m => m.AsQueryable()).Returns(UsuarioData);


             

            var mockContext = new Mock<AppBibliotecaContext>(new DbContextOptions<AppBibliotecaContext>());
            mockContext.Setup(c => c.Usuarios).Returns(mockDbSetUsuario.Object);
          

            return mockContext;
        }

        private static IQueryable<Usuario> GetUsuarioData()
        {
            return new List<Usuario>
            {
                new Usuario { Id = 1, Username = "admin", Password = "admin",       Nombres = "Nombre 1 "},
                new Usuario { Id = 2, Username = "Usuario1", Password = "Usuario1", Nombres = "Nombre 2"  },
                new Usuario { Id = 3, Username = "Usuario2", Password = "Usuario2", Nombres = "Nombre 3"  },
                new Usuario { Id = 4, Username = "Usuario3", Password = "Usuario3", Nombres = "Nombre 4"  },
                new Usuario { Id = 5, Username = "Usuario4", Password = "Usuario4", Nombres = "Nombre 5"  },
                new Usuario { Id = 6, Username = "admin2", Password = "admin2",     Nombres = "Nombre 6"},
            }.AsQueryable();                                                                  
        }
        private static IQueryable<Usuario> GetLibroData()
        {
            return new List<Usuario>
            {
                new Usuario { Id = 1, Username = "admin", Password = "admin",       Nombres = "Nombre 1 "},
                new Usuario { Id = 2, Username = "Usuario1", Password = "Usuario1", Nombres = "Nombre 2"  },
                new Usuario { Id = 3, Username = "Usuario2", Password = "Usuario2", Nombres = "Nombre 3"  },
                new Usuario { Id = 4, Username = "Usuario3", Password = "Usuario3", Nombres = "Nombre 4"  },
                new Usuario { Id = 5, Username = "Usuario4", Password = "Usuario4", Nombres = "Nombre 5"  },
                new Usuario { Id = 6, Username = "admin2", Password = "admin2",     Nombres = "Nombre 6"},
            }.AsQueryable();
        }

    }
}
