using CalidadT2.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace CalidadT2.Test.Controllers
{
    public class HomeControllerTest
    {

        [Test]
        public void TestIndexCase01()
        {
            var loggerMock = new Mock<ILogger<HomeController>>();

            var controller = new HomeController(loggerMock.Object);
            var view = controller.Index();
            Assert.IsInstanceOf<ViewResult>(view);
        }
    }
}
