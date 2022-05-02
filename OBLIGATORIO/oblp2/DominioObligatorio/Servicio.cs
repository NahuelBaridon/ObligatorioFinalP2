using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
   public abstract class Servicio:IValidacion
    {
        
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }

        public Servicio(DateTime fecha, Cliente cliente)
        {
            Fecha = fecha;
            Cliente = cliente;
        }
        public Servicio()
        {

        }

        public override string ToString()
        {
            return $"Fecha:{Fecha.ToString("yyyy-MM-dd")} Cliente:{Cliente.Nombre+" "+Cliente.Apellido}";
        }



        public abstract double calcularPrecio();

        public virtual bool EsValido()
        {
            return Fecha <= DateTime.Now && !Cliente.Equals(null);
        }


    }

    
}
