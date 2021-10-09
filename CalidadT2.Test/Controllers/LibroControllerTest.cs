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
    public class LibroControllerTest
    {
        [Test]
        public void Caso1_VistaDetalleLibro()
        {
            var mockrepository = new Mock<ILibroRepositorio>();
            mockrepository.Setup(o => o.VistaLibroDetalle(1)).Returns(new Libro() { Id = 1 });

            var mockclaim = new Mock<IClaimService>();
            mockclaim.Setup(o => o.GetLoggedUser()).Returns(new Usuario()); ;

            var controller = new LibroController(mockrepository.Object, mockclaim.Object);
            var view = controller.Details(1) as ViewResult;
            Assert.AreEqual("Details", view.ViewName);
        }

        [Test]
        public void Caso2_AgregarComentarioLibro()
        {
            var mockrepository = new Mock<ILibroRepositorio>();
            mockrepository.Setup(o => o.GuardarComentario(new Comentario(), 1));

            var mockclaim = new Mock<IClaimService>();
            mockclaim.Setup(o => o.GetLoggedUser()).Returns(new Usuario() { Id = 1 }); ;

            var controller = new LibroController(mockrepository.Object, mockclaim.Object);
            var view = controller.AddComentario(new Comentario()) as RedirectToActionResult;
            Assert.AreEqual("Details", view.ActionName);
        }
    }
}
