using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using CalidadT2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
 

namespace CalidadT2.Test.Controllers
{
    [TestFixture]
    public class BibliotecaControllerTest
    {
        [Test]
        public void Caso1_MostrarTodosLosLibrosConAutor()
        {

            var Mockrepo = new Mock<IBibliotecaRepositorio>();
            Mockrepo.Setup(o => o.GetBibliotecas(1)).Returns(new List<Biblioteca>());

            var Mockclaim = new Mock<IClaimService>();
            Mockclaim.Setup(o => o.GetLoggedUser()).Returns(new Usuario() { Id = 1 });

            var controller = new BibliotecaController(Mockrepo.Object, Mockclaim.Object);
            var view = controller.Index() as ViewResult;
            Assert.AreEqual("Index", view.ViewName);
        }

        [Test]
        public void Caso2_AgregarLibroBiblioteca()
        {

            var Mockrepo = new Mock<IBibliotecaRepositorio>();
            Mockrepo.Setup(o => o.AgregarBiblioteca(1, 1));

            var Mockclaim = new Mock<IClaimService>();
            Mockclaim.Setup(o => o.GetLoggedUser()).Returns(new Usuario() { Id = 1 });


            var controller = new BibliotecaController(Mockrepo.Object, Mockclaim.Object);
            var view = controller.Add(1) as RedirectToActionResult;
            Assert.AreEqual("Index", view.ActionName);
        }

        [Test]
        public void Caso4_LibroLeyendo()
        {

            var Mockrepo = new Mock<IBibliotecaRepositorio>();
            Mockrepo.Setup(o => o.Bibliotec(1, 1)).Returns(new Biblioteca() { Id = 1 });
            Mockrepo.Setup(o => o.Leer(new Biblioteca()));

            var Mockclaim = new Mock<IClaimService>();
            Mockclaim.Setup(o => o.GetLoggedUser()).Returns(new Usuario() { Id = 1 });

            var controller = new BibliotecaController(Mockrepo.Object, Mockclaim.Object);
            var view = controller.MarcarComoLeyendo(1) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }

        [Test]
        public void Caso3_LibroTerminado()
        {
            var Mockrepo = new Mock<IBibliotecaRepositorio>();
            Mockrepo.Setup(o => o.Bibliotec(1, 1)).Returns(new Biblioteca() { Id = 1 });
            Mockrepo.Setup(o => o.Culminado(new Biblioteca()));

            var Mockclaim = new Mock<IClaimService>();
            Mockclaim.Setup(o => o.GetLoggedUser()).Returns(new Usuario() { Id = 1 });

            var controller = new BibliotecaController(Mockrepo.Object, Mockclaim.Object);
            var view = controller.MarcarComoTerminado(1) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }
    }
}
