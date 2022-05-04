using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
 public class Plato:IValidacion
    {
        public static double PrecioMin { get; set; } = 150;
        public static int ultimoId { get; set; }
        public int id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        
        public Plato(string nombre, double precio)
        {
            id = ultimoId;
            ultimoId++;
            Nombre = nombre;
            Precio = precio;
            PrecioMin = PrecioMin;
        }

        public Plato()
        {

        }

        public override string ToString()
        {
            return $" id: {id} - Nombre: {Nombre} - Precio: {"$" + Precio}";
        }

        //Metodo de Validación
        public bool EsValido()
        {
            return !String.IsNullOrEmpty(Nombre) && Precio >=PrecioMin;
        }
        //termina Metodo de Validación

    }
}
       
        

