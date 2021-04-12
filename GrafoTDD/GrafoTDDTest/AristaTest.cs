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
    public class AristaTest
    {
        [TestMethod]
        public void SiLasAristasTienenIgualOrigenYDestinoSonLaMisma()
        {
            Nodo montevideo = new Nodo() { Nombre = "Montevideo" };
            Nodo piriapolis = new Nodo() { Nombre = "Piriapolis" };
            Arista primerArista = new Arista() { Origen = montevideo, Destino = piriapolis };
            Arista segundaArista = new Arista() { Origen = montevideo, Destino = piriapolis };
            Assert.AreEqual(primerArista, segundaArista);
        }
    }
}
