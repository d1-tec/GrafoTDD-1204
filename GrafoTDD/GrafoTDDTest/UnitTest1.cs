using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GrafoTDD;

namespace GrafoTDDTest
{
    [TestClass]
    public class UnitTest1
    {
        private Grafo grafo;
        private Nodo montevideo = new Nodo() { Nombre = "Montevideo" };
        private Nodo piriapolis = new Nodo() { Nombre = "Piriapolis" };

        [TestInitialize]
        public void Setup()
        {
            grafo = new Grafo();
        }

        [TestCleanup]
        public void Cleanup()
        {
            grafo = null;
        }

        public void AgregarNodosMontevideoYPiriapolis()
        {
            grafo.AgregarNodo(montevideo);
            grafo.AgregarNodo(piriapolis);
        }

        [TestMethod]
        public void CuandoCreoUnGrafoInicialmenteEsVacio()
        {
            Assert.IsTrue(grafo.EsVacio());
        }

        [TestMethod]
        public void UnGrafoQueTieneUnNodoNoEsVacio()
        {
            grafo.AgregarNodo(new Nodo() { Nombre = "Montevideo" });
            Assert.IsFalse(grafo.EsVacio());
        }

        [TestMethod]
        public void UnNodoQueNoFueAgregadoNoExiste()
        {
            bool elNodoExiste = grafo.ExisteNodo(new Nodo() { Nombre = "Montevideo" });
            Assert.IsFalse(elNodoExiste);
        }

        [TestMethod]
        public void UnNodoQueFueAgregadoExiste()
        {
            grafo.AgregarNodo(new Nodo() { Nombre = "Montevideo" });
            bool elNodoExiste = grafo.ExisteNodo(new Nodo() { Nombre = "Montevideo" });
            Assert.IsTrue(elNodoExiste);
        }

        [TestMethod]
        [ExpectedException(typeof(ElNodoNoExisteException))]
        public void SiElNodoNoExisteNodosAdyacentesDevuelveError()
        {
            grafo.SonAdyacentes(montevideo, piriapolis);
        }

        [TestMethod]
        public void SiNoExistenAristasLosNodosNoSonAdyacentes()
        {
            AgregarNodosMontevideoYPiriapolis();
            Assert.IsFalse(grafo.SonAdyacentes(montevideo, piriapolis));
        }

        [TestMethod]
        public void SiExisteLaAristaInversaLosNodosNoSonAdyacentes()
        {
            AgregarNodosMontevideoYPiriapolis();
            grafo.AgregarArista(piriapolis, montevideo);
            Assert.IsFalse(grafo.SonAdyacentes(montevideo, piriapolis));
        }

        [TestMethod]
        public void SiExisteLaAristaCorrectaLosNodosSonAdyacentes()
        {
            AgregarNodosMontevideoYPiriapolis();
            grafo.AgregarArista(montevideo, piriapolis);
            Assert.IsTrue(grafo.SonAdyacentes(montevideo, piriapolis));
        }

        [TestMethod]
        public void SiNoExisteUnaAristaDirectaPeroEstanConectadosSonAdyacentes()
        {
            AgregarNodosMontevideoYPiriapolis();
            Nodo laPaloma = new Nodo() { Nombre = "La Paloma" };
            grafo.AgregarNodo(laPaloma);
            grafo.AgregarArista(montevideo, piriapolis);
            grafo.AgregarArista(piriapolis, laPaloma);
            Assert.IsTrue(grafo.SonAdyacentes(montevideo, laPaloma));
        }

        [TestMethod]
        public void SiNoExisteUnaAristaDirectaYSusAdyacentesNoEstanConectados()
        {
            AgregarNodosMontevideoYPiriapolis();
            Nodo laPaloma = new Nodo() { Nombre = "La Paloma" };
            grafo.AgregarNodo(laPaloma);
            grafo.AgregarArista(montevideo, piriapolis);
            Assert.IsFalse(grafo.SonAdyacentes(montevideo, laPaloma));
        }

        [TestMethod]
        public void SiEstaConectadoConMultiplesAristasEsAdyacente()
        {
            AgregarNodosMontevideoYPiriapolis();
            Nodo laPaloma = new Nodo() { Nombre = "La Paloma" };
            Nodo puntaDelDiablo = new Nodo() { Nombre = "Punta del Diablo" };
            grafo.AgregarNodo(laPaloma);
            grafo.AgregarNodo(puntaDelDiablo);
            grafo.AgregarArista(montevideo, piriapolis);
            grafo.AgregarArista(piriapolis, laPaloma);
            grafo.AgregarArista(laPaloma, puntaDelDiablo);
            Assert.IsTrue(grafo.SonAdyacentes(montevideo, puntaDelDiablo));
        }
    }
}
