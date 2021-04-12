using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrafoTDD;

namespace GrafoTDDTest
{
    [TestClass]
    public class NodoTest
    {
        [TestMethod]
        public void SiLosNodosTienenNombresDiferentesSonDistintosNodos()
        {
            Nodo primerNodo = new Nodo() { Nombre = "primero" };
            Nodo segundoNodo = new Nodo() { Nombre = "segundo" };
            Assert.AreNotEqual(primerNodo, segundoNodo);
        }

        [TestMethod]
        public void SiLosNodosTienenElMismoNombreSonIguales()
        {
            Nodo primerNodo = new Nodo() { Nombre = "primero" };
            Nodo segundoNodo = new Nodo() { Nombre = "primero" };
            Assert.AreEqual(primerNodo, segundoNodo);
        }
    }
}
