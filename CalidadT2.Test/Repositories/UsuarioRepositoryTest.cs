using System;
using System.Collections.Generic;
using System.Text;
using CalidadT2.Models;
using CalidadT2.Repositories;
using CalidadT2.Test.Repositories.Mocks;
using Moq;
using NUnit.Framework;

namespace CalidadT2.Test.Repositories
{
    public class UsuarioRepositoryTest
    {
        private Mock<AppBibliotecaContext> mockContext;

        [SetUp]
        public void SetUp()
        {
            mockContext = AplicationContextMock.GetApplicationContextMock();
        }

        [Test]
        public void TestGetAllCaso01()
        {
            var respository = new UsuarioRepository(mockContext.Object);
            var users = respository.GetAll();

            Assert.AreEqual(6, users.Count);
        }
    }
}
