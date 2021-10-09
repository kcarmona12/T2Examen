using CalidadT2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadT2.Test.Controllers
{
    [TestFixture]
    public class AuthTest
    {
        [Test]
        public void Caso1_InicioSesionBien()
        {
            var controller = new AuthController(null, null);
            var vista = controller.Login() as ViewResult;

            Assert.AreEqual("Login", vista.ViewName);
        }

        [Test]
        public void Caso2_InicioSesionMal()
        {
            var Mockrepository = new Mock<IAuthRepositorio>();
            Mockrepository.Setup(o => o.ObtenerUsuario(null, null)).Returns(new Models.Usuario());

            var Mockservice = new Mock<IClaimService>();

            var controller = new AuthController(Mockrepository.Object, Mockservice.Object);
            var view = controller.Login("Hola", "Mundo") as ViewResult;

            Assert.AreEqual("Login", view.ViewName);
        }

        [Test]
        public void Caso3_LogueadoExitoso()
        {
            var Mockrepository = new Mock<IAuthRepositorio>();

            var Mockservice = new Mock<IClaimService>();
            Mockservice.Setup(o => o.Logueado());

            var controller = new AuthController(Mockrepository.Object, Mockservice.Object);
            var view = controller.Logout() as RedirectToActionResult;

            Assert.AreEqual("Login", view.ActionName);
        }
    }
}
