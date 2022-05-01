using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
   public class Repartidor:Persona
    {
        public Vehiculo Tipovehiculo { get; set; }
        public enum Vehiculo { moto =0, bici=1, apie=2 }

        public Repartidor(string nombre, string apellido, Vehiculo tipovehiculo) : base(nombre, apellido)
        {
            Tipovehiculo = tipovehiculo;
        } 

        public bool EnumValido(int  v)
        {
            bool ret = false;
            if(v.Equals((int)Vehiculo.apie) || v.Equals((int)Vehiculo.moto)|| v.Equals((int)Vehiculo.bici))
            {
                ret = true;
            }
            return ret;
        }

        public override bool EsValido()
        {

            return base.EsValido() && EnumValido((int)Tipovehiculo);
        }






    }
}
    