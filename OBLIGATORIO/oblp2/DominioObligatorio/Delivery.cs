using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public  class Delivery : Servicio
    {
        public Delivery(List<CantidadPlatos> platos, DateTime fecha, Cliente cliente,int distancia , Repartidor repartidor) : base(fecha, cliente)
        {
            Platos = platos;
            Repartidor = repartidor;
            Distancia = distancia;
        }
        public Delivery()
        {

        }

        public override string ToString()
        {
            return $"Orden:{Platos} Fecha:{Fecha.ToString("yyyy-MM-dd")} Cliente:{Cliente} Distancia:{Distancia} Repartidor:{Repartidor}";
        }

        private List<CantidadPlatos> Platos { get; set; }

        public int Distancia { get; set; }
        public Repartidor Repartidor { get; set; }

        public List<CantidadPlatos> getCarrito()
        {
            return Platos;
        }

        public override double calcularPrecio()
        {
            double precioEnvio = 0;

            if(Distancia<2000)
            {
                precioEnvio = 50;
            }

           else  if(Distancia>=2000 && Distancia>= 5000)
            {
                precioEnvio += Distancia / 100;


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

        public override bool EsValido()
        {
            return base.EsValido() && Platos.Count>0 && !Repartidor.Equals(null) && Distancia > 0;
        }
    }
}
