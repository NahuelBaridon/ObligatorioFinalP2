using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public  class Delivery : Servicio
    {
        public double Distancia { get; set; }
        public Repartidor Repartidor { get; set; }

        public Delivery(List<CantidadPlatos> platos, DateTime fecha, Cliente cliente, double distancia , Repartidor repartidor) : base(platos, fecha, cliente)
        {
            Repartidor = repartidor;
            Distancia = distancia;
            
        }
        public Delivery()
        {

        }

        public override string ToString()
        {
            return $" {Environment.NewLine} Platos: {MostrarPlatos(getCarrito())} {Environment.NewLine} Precio: {"$"+calcularPrecio()} - Fecha: {Fecha.ToString("yyyy-MM-dd")}  {Environment.NewLine} Cliente: {Cliente} - Distancia: {Distancia} {Environment.NewLine} Repartidor: {Repartidor}";
        }


        //Metodo de calculo
        public override double calcularPrecio()
        {
            double precioEnvio = 0;
            double dist = Math.Truncate(Distancia);

            if (dist <= 2)
            {
                precioEnvio = 50;
            }
            else if(dist <= 7)
            {
                precioEnvio += 10*(dist-2);
            }
            else
            {
                precioEnvio = 100;
            }

            double precio = precioEnvio;

            foreach (CantidadPlatos n in getCarrito())
            {
                precio += n.Plato.Precio * n.Cantidad;

            }
            return precio;


        }
        //termina Metodo de calculo

        //Metodo de Validación
        public override bool EsValido()
        {
            return base.EsValido() && getCarrito().Count>0 && !Repartidor.Equals(null) && Distancia > 0;
        }
        //termina Metodo de Validación

    }
}


