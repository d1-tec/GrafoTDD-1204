using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoTDD
{
    public class Arista
    {
        public Nodo Origen { get; set; }
        public Nodo Destino { get; set; }

        public override bool Equals(object obj)
        {
            Arista arista = obj as Arista;

            if (arista == null) return false;

            return this.Origen.Equals(arista.Origen) && this.Destino.Equals(arista.Destino);
        }
    }
}
