using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
  public  class CantidadPlatos
    {
        public Plato Plato { get; set; }
        public int Cantidad { get; set; }

        public CantidadPlatos(Plato plato, int cantidad)
        {
            Plato = plato;
            Cantidad = cantidad;
        }

        

    }
}
