using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
   public class Repartidor:Persona
    {
        public Vehiculo Tipovehiculo { get; set; }
        public enum Vehiculo { moto, bici, a_pie }

        public Repartidor(string nombre, string apellido, Vehiculo tipovehiculo) : base(nombre, apellido)
        {
            Tipovehiculo = tipovehiculo;
        }
        public Repartidor()
        {

        }

        public override string ToString()
        {
            return $" Apellido: {Apellido} - Nombre: {Nombre} - Vehículo: {Tipovehiculo}";
        }

        //Metodo de Validación
        public override bool EsValido()
        {
            return base.EsValido();
        }
        //termina Metodo de Validación
    }
}






    