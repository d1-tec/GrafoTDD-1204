using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoTDD
{
    public class Grafo
    {
        private List<Nodo> nodos;
        private List<Arista> aristas;

        public Grafo()
        {
            this.nodos = new List<Nodo>();
            this.aristas = new List<Arista>();
        }

        public bool EsVacio()
        {
            return this.nodos.Count == 0;
        }

        public void AgregarNodo(Nodo nodo)
        {
            this.nodos.Add(nodo);
        }

        public bool ExisteNodo(Nodo nodo)
        {
            return this.nodos.Contains(nodo);
        }

        public bool SonAdyacentes(Nodo origen, Nodo destino)
        {
            if (!this.ExisteNodo(origen) || !this.ExisteNodo(destino)) throw new ElNodoNoExisteException();

            Arista arista = new Arista() { Origen = origen, Destino = destino };

            bool tieneAristaDirecta = this.aristas.Contains(arista);
            bool elOrigenEstaConectadoConAlguien = this.aristas.Any(a => a.Origen.Equals(origen));

            if (tieneAristaDirecta)
            {
                return true;
            }
            else if (!elOrigenEstaConectadoConAlguien)
            {
                return false;
            }
            else
            {
                List<Arista> aristasDelOrigen = this.aristas.Where(a => a.Origen.Equals(origen)).ToList();

                return aristasDelOrigen.Any(a => this.SonAdyacentes(a.Destino, destino));
            }
        }

        public void AgregarArista(Nodo origen, Nodo destino)
        {
            this.aristas.Add(new Arista() { Origen = origen, Destino = destino });
        }
    }
}
