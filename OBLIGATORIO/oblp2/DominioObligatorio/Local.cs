using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
  public  class Local:Servicio
    {
        
        public int NroMesa { get; set; }
        public Mozo Mozo { get; set; }
        public int Comenzales { get; set; }
        public static double PrecioCubierto { get; set; } = 5; //preguntar 

        public Local(List<CantidadPlatos> platos, DateTime fecha, Cliente cliente,int nroMeza,Mozo mozo,int comenzales) : base(platos, fecha, cliente)
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
            return $" {Environment.NewLine} Platos: {MostrarPlatos(getCarrito())} {Environment.NewLine} Precio: {"$" + calcularPrecio()} - Fecha: {Fecha.ToString("yyyy-MM-dd")}{Environment.NewLine} Cliente: {Cliente} - Mesa: {NroMesa} - Comenzales: {Comenzales} {Environment.NewLine} Mozo: {Mozo}";
        }
        
        //Metodo de calculo
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
        //termina Metodo de calculo


        //Metodo de Validación
        public override bool EsValido()
        {
            return base.EsValido() && getCarrito().Count>0 && !Mozo.Equals(null) && Comenzales > 0;
        }
        //termina Metodo de Validación

    }
}



