using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
  public  class Local:Servicio
    {
        private List<CantidadPlatos> Platos { get; set; }
        public int NroMesa { get; set; }
        public Mozo Mozo { get; set; }
        public int Comenzales { get; set; }
        public static double PrecioCubierto { get; set; } = 5; //preguntar 

        public Local(List<CantidadPlatos> platos, DateTime fecha, Cliente cliente,int nroMeza,Mozo mozo,int comenzales) : base(fecha, cliente)
        {
            NroMesa = nroMeza;
            Mozo = mozo;
            Comenzales = comenzales;
           
        }
        public Local()
        {

        }


        public override string ToString()
        {
            return $"Orden:{Platos} Fecha:{Fecha.ToString("yyyy-MM-dd")} Cliente:{Cliente} Mesa:{NroMesa} Mozo:{Mozo} Comenzals:{Comenzales}";
        }

        public List<CantidadPlatos> getCarrito()
        {
            return Platos;
        }



        public override double calcularPrecio()
        {
            double precioCubierto = PrecioCubierto*Comenzales;

            double precio = precioCubierto;

            foreach(CantidadPlatos n in getCarrito())
            {
                precio += n.Plato.Precio * n.Cantidad;
               
            }
            return precio*1.1;

        }

        

        public override bool EsValido()
        {
            return base.EsValido() && !Mozo.Equals(null) && Comenzales > 0;
        }
    }
}
