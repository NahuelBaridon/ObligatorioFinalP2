using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
  public  class Local:Servicio
    {
        public Local(List<CantidadPlatos> platos, DateTime fecha, Cliente cliente,int nroMeza,Mozo mozo,int comenzales) : base(fecha, cliente)
        {
            NroMesa = nroMeza;
            Mozo = mozo;
            Comenzales = comenzales;
           
        }

        private List<CantidadPlatos> Platos { get; set; }
        public int NroMesa { get; set; }
        public Mozo Mozo { get; set; }
        public int Comenzales { get; set; }
        public static double PrecioCubierto { get; set; } = 5; //preguntar 

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
