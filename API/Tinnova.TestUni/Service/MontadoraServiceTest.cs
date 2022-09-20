using AppCore.Entities;
using AppCore.Interface.Repositores;
using AppCore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tinova.Teste.Service
{
    [TestClass]
    public class MontadoraServiceTest
    {
        private readonly Mock<IMontadoraRepository> _mockRepo;
        public MontadoraServiceTest()
        {
            _mockRepo = new Mock<IMontadoraRepository>();
        }

        [TestMethod]
        public void GetIdOK()
        {

            var esperado = new AutomovelEntity
            {
                Ano = 2002,
                Cor = "preto",
                Veiculo = "teste",
                Marca = "ford"
            };


            _mockRepo.Setup(x => x.Get(It.IsAny<string>()))
                .Returns(Task.FromResult(esperado));

            var result = new MontadoraService(_mockRepo.Object).Get("");

            Assert.IsTrue(result.Result != null);
        }

        [TestMethod]
        public void GetIdErro()
        {

            var esperado = new AutomovelEntity
            {
                Ano = 2002,
                Cor = "preto",
                Veiculo = "teste",
                Marca = "ford"
            };


            _mockRepo.Setup(x => x.Get(It.IsAny<string>()))
                .ThrowsAsync(new Exception("Quero ver o erro"));

            var result = new MontadoraService(_mockRepo.Object).Get("");

            Assert.IsTrue(result.Exception.Message.Contains("Quero ver o erro"));
        }

        [TestMethod]
        public void GetParameiterOk()
        {

            var esperado = new List<AutomovelEntity>{ new AutomovelEntity
            {
                Ano = 2002,
                Cor = "preto",
                Veiculo = "teste",
                Marca = "ford"
            } };


            _mockRepo.Setup(x => x.GeAll())
                .Returns(Task.FromResult(esperado));

            var result = new MontadoraService(_mockRepo.Object).Get("", "", "");

            Assert.IsTrue(result.Result != null);
        }

        [TestMethod]
        public void GetParameiterErro()
        {
            _mockRepo.Setup(x => x.GeAll())
        .ThrowsAsync(new Exception("Quero ver o erro"));

            var result = new MontadoraService(_mockRepo.Object).Get("", "", "");

            Assert.IsTrue(result.Result.Message.Contains("Quero ver o erro"));
        }


        [TestMethod]
        public void GetAllOK()
        {

            var esperado = new List<AutomovelEntity>{ new AutomovelEntity
            {
                Ano = 2002,
                Cor = "preto",
                Veiculo = "teste",
                Marca = "ford"
            } };


            _mockRepo.Setup(x => x.GeAll())
                .Returns(Task.FromResult(esperado));

            var result = new MontadoraService(_mockRepo.Object).GetAll();

            Assert.IsTrue(result.Result.Value.Count > 0);
        }

        [TestMethod]
        public void GetAllErro()
        {
            _mockRepo.Setup(x => x.GeAll())
                 .ThrowsAsync(new Exception("Quero ver o erro"));

            var result = new MontadoraService(_mockRepo.Object).GetAll();

            Assert.IsTrue(result.Result.Message.Contains("Quero ver o erro"));
        }

        [TestMethod]
        public void InsertOK()
        {
            var info = new AutomovelEntity
            {
                Ano = 2002,
                Cor = "preto",
                Veiculo = "teste",
                Marca = "ford"
            };
            var esperado = new List<AutomovelEntity> { info };

            _mockRepo.Setup(x => x.GeAll())
             .Returns(Task.FromResult(esperado));
            _mockRepo.Setup(x => x.InsertAsync(It.IsAny<AutomovelEntity>()))
             .Returns(Task.FromResult(esperado));

            var result = new MontadoraService(_mockRepo.Object).InsertAsync(info);

            Assert.IsTrue(result.Result.Status);
        }

        [TestMethod]
        public void InsertErro()
        {
            var info = new AutomovelEntity
            {
                Ano = 2002,
                Cor = "preto",
                Veiculo = "teste",
                Marca = "ford"
            };
            _mockRepo.Setup(x => x.GeAll())
                 .ThrowsAsync(new Exception("when querying user existence"));

            var result = new MontadoraService(_mockRepo.Object).InsertAsync(info);

            Assert.IsTrue(result.Result.Message.Contains("when querying user existence"));
        }

        [TestMethod]
        public void UpdateOK()
        {
            var info = new AutomovelEntity
            {
                Ano = 2002,
                Cor = "preto",
                Veiculo = "teste",
                Marca = "ford"
            };


            _mockRepo.Setup(x => x.Get(It.IsAny<string>()))
             .Returns(Task.FromResult(info));

            _mockRepo.Setup(x => x.UpdateAsync(It.IsAny<AutomovelEntity>()))
             .Returns(Task.FromResult(info));

            var result = new MontadoraService(_mockRepo.Object).UpdateAsync(info);

            Assert.IsTrue(result.Result.Status);
        }

        [TestMethod]
        public void UpdatetErro()
        {
            var info = new AutomovelEntity
            {
                Ano = 2002,
                Cor = "preto",
                Veiculo = "teste",
                Marca = "ford"
            };
            _mockRepo.Setup(x => x.Get(It.IsAny<string>()))
          .ThrowsAsync(new Exception("Error: when querying user existence. Please try again"));

            var result = new MontadoraService(_mockRepo.Object).InsertAsync(info);

            Assert.IsTrue(result.Result.Message.Contains("Error: when querying user existence. Please try again"));
        }


        [TestMethod]
        public void DeleteIdOK()
        {

            var esperado = new AutomovelEntity
            {
                Ano = 2002,
                Cor = "preto",
                Veiculo = "teste",
                Marca = "ford"
            };


            _mockRepo.Setup(x => x.DeleteAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(true));

            var result = new MontadoraService(_mockRepo.Object).DeleteAsync("");

            Assert.IsTrue(result.Result.Value);
        }

        [TestMethod]
        public void DeleteErro()
        {

            var esperado = new AutomovelEntity
            {
                Ano = 2002,
                Cor = "preto",
                Veiculo = "teste",
                Marca = "ford"
            };


            _mockRepo.Setup(x => x.DeleteAsync(It.IsAny<string>()))
                .ThrowsAsync(new Exception("Quero ver o erro"));

            var result = new MontadoraService(_mockRepo.Object).DeleteAsync("");

            Assert.IsTrue(result.Result.Message.Contains("Quero ver o erro"));
        }

    }
}
