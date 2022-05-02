using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
  public class Sistema
    {
        List<Cliente> Clientes = new List<Cliente>();
        List<Plato> Platos = new List<Plato>();
        List<Mozo> Mozos = new List<Mozo>();
        List<Repartidor> Repartidores = new List<Repartidor>();
        List<Servicio> Servicios = new List<Servicio>();

        
        public List<Cliente> GetClientes() 
        {
            Clientes.Sort();
            return Clientes; 
        }

        public List<Plato> GetPlatos() { return Platos; }
        public List<Mozo> GetMozos() { return Mozos; }
        public List<Repartidor> GetRepartido() { return Repartidores; }
        public List<Servicio> GetServicios() { return Servicios;}



        public Sistema()
        {
            PrecargarDatos();
        }

        public void ModificarPrecioMin(double precio)
        {
            Plato.PrecioMin = precio;
            foreach (Plato p in Platos)
            {
                if (p.Precio < precio)
                {
                    p.Precio = precio;
                }
            }
        }


        private void PrecargarDatos()
        {
            //PRECARGA DE DATOS
            //clientes
            Cliente cliente1 = new Cliente("alfredo", "Fuentes", "alfredofuentes@gmail.com", "Alfredito123");
            AltaCliente(cliente1);
            Cliente cliente2 = new Cliente("Juan", "Perez", "juanperez@gmail.com", "Juansito123");
            AltaCliente(cliente2);
            Cliente cliente3 = new Cliente("Ignacio", "Perez", "nachito@gmail.com", "Nachito123");
            AltaCliente(cliente3);
            Cliente cliente4 = new Cliente("Federico", "Caimi", "Caimi@gmail.com", "Caimi123");
            AltaCliente(cliente4);
            Cliente cliente5 = new Cliente("Nahuel", "Baridon", "Baridon@gmail.com", "Baridon123");
            AltaCliente(cliente5);
            // termina clientes 

            // mozos
            Mozo mozo1 = new Mozo("Diego", "Munioz");
            AltaMozo(mozo1);
            Mozo mozo2 = new Mozo("Carlos", "Rodriguez");
            AltaMozo(mozo2);
            Mozo mozo3 = new Mozo("Santiago", "Fernandez");
            AltaMozo(mozo3);
            Mozo mozo4 = new Mozo("Agustin", "Etchepare");
            AltaMozo(mozo4);
            Mozo mozo5 = new Mozo("Joaquin", "Ramirez");
            AltaMozo(mozo5);
            // terminamos mozo 

            // repartidores 
            Repartidor repartidor1 = new Repartidor("Ernesto", "Perez", Repartidor.Vehiculo.bici);
            AltaRepartidor(repartidor1);
            Repartidor repartidor2 = new Repartidor("Nicolas", "Varaldo", Repartidor.Vehiculo.apie);
            AltaRepartidor(repartidor2);
            Repartidor repartidor3 = new Repartidor("Christian", "Barrios", Repartidor.Vehiculo.moto);
            AltaRepartidor(repartidor3);
            Repartidor repartidor4 = new Repartidor("Ricardo", "Fort", Repartidor.Vehiculo.bici);
            AltaRepartidor(repartidor4);
            Repartidor repartidor5 = new Repartidor("Marcelo", "Tinelli", Repartidor.Vehiculo.bici);
            AltaRepartidor(repartidor5);
            // termina repartidores

            // platos

            Plato plato1 = new Plato("Hamburguesa", 250);
            AltaPlato(plato1);
            Plato plato2 = new Plato("Milanesa", 350);
            AltaPlato(plato2);
            Plato plato3 = new Plato("Chivito", 300);
            AltaPlato(plato3);
            Plato plato4 = new Plato("Pizzeta", 250);
            AltaPlato(plato4);
            Plato plato5 = new Plato("Sopa", 200);
            AltaPlato(plato5);
            Plato plato6 = new Plato("Papas cheddar", 250);
            AltaPlato(plato6);
            Plato plato7 = new Plato("Strogonoff", 250);
            AltaPlato(plato7);
            Plato plato8 = new Plato("Brazero asado", 450);
            AltaPlato(plato8);
            Plato plato9 = new Plato("Sorrentinos", 300);
            AltaPlato(plato9);
            Plato plato10 = new Plato("Pollo grille", 350);
            AltaPlato(plato10);


            // termiamos los platos.

            // Servicios
            List<CantidadPlatos> cantidadPlatos1 = new List<CantidadPlatos>();
            CantidadPlatos cantidadUno = new CantidadPlatos(plato1, 2);
            cantidadPlatos1.Add(cantidadUno);
            CantidadPlatos cantidadDos = new CantidadPlatos(plato2, 4);
            cantidadPlatos1.Add(cantidadDos);

            List<CantidadPlatos> cantidadPlatos2 = new List<CantidadPlatos>();
            CantidadPlatos cantidadTres = new CantidadPlatos(plato3, 1);
            cantidadPlatos2.Add(cantidadTres);
            CantidadPlatos cantidadCuatro = new CantidadPlatos(plato4, 3);
            cantidadPlatos2.Add(cantidadCuatro);

            List<CantidadPlatos> cantidadPlatos3 = new List<CantidadPlatos>();
            CantidadPlatos cantidadCinco = new CantidadPlatos(plato5, 3);
            cantidadPlatos3.Add(cantidadCinco);
            CantidadPlatos cantidadSeis = new CantidadPlatos(plato6, 1);
            cantidadPlatos3.Add(cantidadSeis);

            List<CantidadPlatos> cantidadPlatos4 = new List<CantidadPlatos>();
            CantidadPlatos cantidadSiete = new CantidadPlatos(plato7, 2);
            cantidadPlatos4.Add(cantidadSiete);
            CantidadPlatos cantidadOcho = new CantidadPlatos(plato8, 3);
            cantidadPlatos4.Add(cantidadOcho);

            List<CantidadPlatos> cantidadPlatos5 = new List<CantidadPlatos>();
            CantidadPlatos cantidadNueve = new CantidadPlatos(plato9, 2);
            cantidadPlatos5.Add(cantidadNueve);
            CantidadPlatos cantidadDiez = new CantidadPlatos(plato10, 1);
            cantidadPlatos5.Add(cantidadDiez);

            List<CantidadPlatos> cantidadPlatos6 = new List<CantidadPlatos>();
            CantidadPlatos cantidadOnce = new CantidadPlatos(plato3, 3);
            cantidadPlatos6.Add(cantidadOnce);
            CantidadPlatos cantidadDoce = new CantidadPlatos(plato6, 3);
            cantidadPlatos6.Add(cantidadDoce);

            List<CantidadPlatos> cantidadPlatos7 = new List<CantidadPlatos>();
            CantidadPlatos cantidadTrece = new CantidadPlatos(plato5, 1);
            cantidadPlatos7.Add(cantidadTrece);
            CantidadPlatos cantidadCatorce = new CantidadPlatos(plato10, 4);
            cantidadPlatos7.Add(cantidadCatorce);

            List<CantidadPlatos> cantidadPlatos8 = new List<CantidadPlatos>();
            CantidadPlatos cantidadQuince = new CantidadPlatos(plato7, 2);
            cantidadPlatos8.Add(cantidadQuince);
            CantidadPlatos cantidadDieciseis = new CantidadPlatos(plato2, 2);
            cantidadPlatos8.Add(cantidadDieciseis);

            List<CantidadPlatos> cantidadPlatos9 = new List<CantidadPlatos>();
            CantidadPlatos cantidadDiecisiete = new CantidadPlatos(plato5, 1);
            cantidadPlatos9.Add(cantidadDiecisiete);
            CantidadPlatos cantidadDieciocho = new CantidadPlatos(plato1, 2);
            cantidadPlatos9.Add(cantidadDieciocho);

            List<CantidadPlatos> cantidadPlatos10 = new List<CantidadPlatos>();
            CantidadPlatos cantidadDiecinueve = new CantidadPlatos(plato9, 2);
            cantidadPlatos10.Add(cantidadDiecinueve);
            CantidadPlatos cantidadVeinte= new CantidadPlatos(plato8, 3);
            cantidadPlatos10.Add(cantidadVeinte);

            Delivery s1d = new Delivery(cantidadPlatos1, new DateTime(2021 - 12 - 3), cliente1, 1, repartidor1);
            AltaDelivery(s1d);
            Delivery s2d = new Delivery(cantidadPlatos2, new DateTime(2021 - 11 - 4), cliente2, 1, repartidor2);
            AltaDelivery(s2d);
            Delivery s3d = new Delivery(cantidadPlatos3, new DateTime(2021 - 10 - 5), cliente3, 1, repartidor3);
            AltaDelivery(s3d);
            Delivery s4d = new Delivery(cantidadPlatos4, new DateTime(2021 - 9 - 6), cliente4, 1, repartidor4);
            AltaDelivery(s4d);
            Delivery s5d = new Delivery(cantidadPlatos5, new DateTime(2021 - 8 - 7), cliente5, 1, repartidor5);
            AltaDelivery(s5d);
            Local s6l = new Local(cantidadPlatos6, new DateTime(2022 - 1 - 8), cliente1, 1, mozo1, 6);
            AltaLocal(s6l);
            Local s7l = new Local(cantidadPlatos7, new DateTime(2022 - 2 - 9), cliente2, 2, mozo2, 5);
            AltaLocal(s7l);
            Local s8l = new Local(cantidadPlatos8, new DateTime(2022 - 3 - 10), cliente3, 3, mozo3, 4);
            AltaLocal(s8l);
            Local s9l = new Local(cantidadPlatos9, new DateTime(2022 - 4 - 11), cliente4, 4, mozo4, 3);
            AltaLocal(s9l);
            Local s10l = new Local(cantidadPlatos10, new DateTime(2022 - 5 - 1), cliente5, 5, mozo5, 5);
            AltaLocal(s10l);



        }



        public Cliente AltaCliente(Cliente c) {
            if (c.EsValido())
            {
                Clientes.Add(c);
                return c;
            }
           return null;
        }
        public Mozo AltaMozo(Mozo m) {
            if (m.EsValido())
            {
                Mozos.Add(m);
                return m;
            }
           return null;
        }
        public Repartidor AltaRepartidor(Repartidor r) {
            if (r.EsValido())
            {
                Repartidores.Add(r);
                return r;
            }
           return null;
        }
         public Plato AltaPlato(Plato p ) {
            if (p.EsValido())
            {
                Platos.Add(p);
                return p;
            }
           return null;
        }
         public Delivery AltaDelivery(Delivery d) {
            if (d.EsValido())
            {
                Servicios.Add(d);
                return d;
            }
           return null;
          }
        public Local AltaLocal(Local l)
        {
            if (l.EsValido())
            {
                Servicios.Add(l);
                return l;
            }
            return null;
        }
        public string MostrarPlatos()
        {
            string todosLosPlatos = "";
            foreach (Plato p in Platos)
            {
                todosLosPlatos += $"id:{p.id} nombre:{p.Nombre} precio:{p.Precio} {Environment.NewLine}";


            }
            return todosLosPlatos;
        }

        public List<Servicio> GetServiciosDelivery(List<Servicio> ss)
        {
            List<Servicio> ret = new List<Servicio>();
            foreach(Servicio s in ss)
            {
                if(s is Delivery)
                {
                    ret.Add(s);
                }
            }
            return ret;
        }

        public List<Servicio> GetServiciosDelireysMontoEntreFechas(Repartidor r, DateTime f1, DateTime f2)
        {
            if (f1 > f2)
            {
                DateTime aux = f1;
                f1 = f2;
                f2 = aux;

            }


            List<Servicio> ret = new List<Servicio>();
            foreach (Servicio s in Servicios)
            {
                if (s is Delivery && s.Fecha > f1 && s.Fecha < f2)
                {
                  //  if(s.Cliente && )

                    ret.Add(s);
                }
            }
            return ret;


        }
         

            public bool validarPaswword(Cliente c)
        {
            bool ret = false;
            if (c.Password.Length >= 6)
            {
              if (tieneNumero(c.Password) && tieneMayuscula(c.Password) && tieneMinuscula(c.Password))
                  {
                   ret = true;
                  }
            }
            return ret; 
        }
        private bool tieneNumero (string c)
        {
            bool ret = false;
            string numeros = "0123456789";
            for (int i = 0 ; i < c.Length && !ret ; i++)
            {
               for (int n = 0; n < numeros.Length && !ret ; n++)
                {
                    if (c[i].Equals(numeros[n])){
                        ret = true;
                    }
                }
            }
            return ret;
        }
        private bool tieneMayuscula(string c)
        {
            bool ret = false;
            string minuscula = c.ToLower();
            if (c != minuscula)
            {
                ret = true;
            }
            return ret;
        }
        private bool tieneMinuscula(string c)
        {
            bool ret = false;
            string mayuscula = c.ToUpper();
            if (c != mayuscula)
            {
                ret = true;
            }
            return ret;
        }


        



    }
}
