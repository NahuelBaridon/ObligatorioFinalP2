using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
   public abstract class Servicio:IValidacion
    {
        private List<CantidadPlatos> Platos { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }

        public Servicio(List<CantidadPlatos> platos, DateTime fecha, Cliente cliente)
        {
            Platos = platos;
            Fecha = fecha;
            Cliente = cliente;
        }
        public Servicio()
        {

        }
        public override string ToString()
        {
            return $" Orden: {MostrarPlatos(Platos)} - Fecha: {Fecha} - Cliente: {Cliente}";
        }

        //Stringify del Carrito
        public string MostrarPlatos(List<CantidadPlatos> Carrito)
        {
            string todosLosPlatos = "";
            foreach (CantidadPlatos p in Carrito)
            {
                todosLosPlatos += " +" + p;
            }
            return todosLosPlatos;
        }
        //termina Stringify del Carrito


        //Get Carrito
        public List<CantidadPlatos> getCarrito()
        {
            return Platos;
        }
        //termina Get Carrito

        //firma de Método de cálculo
        public abstract double calcularPrecio();
        //termina firma de Método de cálculo

        //Método de Validación
        public virtual bool EsValido()
        {
            return Fecha <= DateTime.Now && !Cliente.Equals(null);
        }
        //termina Método de Validación
    }
}

