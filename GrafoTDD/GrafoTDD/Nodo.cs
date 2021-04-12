using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoTDD
{
    public class Nodo
    {
        public string Nombre { get; set; }

        public override bool Equals(object obj)
        {
            Nodo nodo = obj as Nodo;

            if (nodo == null) return false;

            return this.Nombre.Equals(nodo.Nombre);
        }
    }
}
