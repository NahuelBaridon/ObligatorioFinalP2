using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
  public class Sistema
    {
        //Listas
        List<Persona> Personas = new List<Persona>(); 
        List<Plato> Platos = new List<Plato>();
        List<Servicio> Servicios = new List<Servicio>();

        // Get de listas
        public List<Cliente> GetClientes() 
        {
            List<Cliente> ret = new List<Cliente>();
            foreach (Persona p in Personas)
            {
                if (p is Cliente)
                {
                    Cliente aux = p as Cliente;
                    ret.Add(aux);
                }
            }
            ret.Sort();
            return ret;
        }

        public List<Mozo> GetMozos()
        {
            List<Mozo> ret = new List<Mozo>();
            foreach (Persona p in Personas)
            {
                if (p is Mozo)
                {
                    Mozo aux = p as Mozo;
                    ret.Add(aux);
                }
            }            
            return ret;
        }

        public List<Repartidor> GetRepartidores()
        {
            List<Repartidor> ret = new List<Repartidor>();
            foreach (Persona p in Personas)
            {
                if (p is Repartidor)
                {
                    Repartidor aux = p as Repartidor;
                    ret.Add(aux);
                }
            }
            return ret;
        }

        public List<Plato> GetPlatos() { return Platos; }
        public List<Servicio> GetServicios() { return Servicios;}

        public List<Delivery> GetDeliverys()
        {
            List<Delivery> ret = new List<Delivery>();
            foreach (Servicio ser in Servicios)
            {
                if (ser is Delivery)
                {
                    Delivery aux = ser as Delivery;
                    ret.Add(aux);
                }
            }
            return ret;

        }

        public List<Local> GetLocales()
        {
            List<Local> ret = new List<Local>();
            foreach (Servicio ser in Servicios)
            {
                if (ser is Local)
                {
                    Local aux = ser as Local;
                    ret.Add(aux);
                }
            }
            return ret;
        }

            //Get Deliverys con restricciones
            public List<Delivery> GetDelireysMontoEntreFechas(string del, DateTime d1, DateTime d2)
            {
                List<Delivery> ret = new List<Delivery>();
                if (d1 > d2)
                {
                    DateTime aux = d1;
                    d1 = d2;
                    d2 = aux;
                }
                foreach (Delivery d in GetDeliverys())
                {
                    if (del.Equals(d.Repartidor.Nombre) && (d.Fecha >= d1 && d.Fecha <= d2))
                    {
                        ret.Add(d);
                    }
                }
                return ret;
            }
            //termina Get Deliverys con restricciones
        //termina Get de listas

        public Sistema()
        {
            PrecargarDatos();
        }

        //Altas
        public Cliente AltaCliente(Cliente c) {
            if (c.EsValido())
            {
                Personas.Add(c as Persona);
                GetClientes().Add(c);
                return c;
            }
           return null;
        }
        public Mozo AltaMozo(Mozo m) {
            if (m.EsValido())
            {
                Personas.Add(m as Persona);
                GetMozos().Add(m);
                return m;
            }
           return null;
        }
        public Repartidor AltaRepartidor(Repartidor r) {
            if (r.EsValido())
            {
                Personas.Add(r as Persona);
                GetRepartidores().Add(r);
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
        //termina Altas

        //Método Modificación
        public bool ModificarPrecioMin(string precio)
        {
            bool ret = false;
            Plato.PrecioMin = Int32.Parse(precio);
            foreach (Plato p in Platos)
            {
                if (p.Precio < Int32.Parse(precio))
                {
                    ret = true;
                    p.Precio = Int32.Parse(precio);
                }
            }
            return ret; 
        }

        //Métodos de Validación
        public bool TieneNumero (string c)
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

        public bool EsFecha(string f)
        {
            bool ret = false;
            DateTime d;
            if (DateTime.TryParse(f, out d))
            {
                ret = true;
            }
            return ret;
        }
        //termina Métodos de Validación

        //Stringify Lista de Platos
        public string MostrarPlatos()
        {
            string todosLosPlatos = "";
            foreach (Plato p in Platos)
            {
                todosLosPlatos += $" + {p} {Environment.NewLine}";

            }
            return todosLosPlatos;
        }
        //termina Stringify Lista de Platos

        //Stringify Lista de Clientes
        public string MostrarClientes()
        {
            string todosLosClientes = "";
            foreach (Cliente c in GetClientes())
            {
                todosLosClientes += $" + {c} {Environment.NewLine}";

            }
            return todosLosClientes;
        }
        //termina Stringify Lista Clientes

        //Stringify de Lista de Deliverys con restricciones
        public string MostrarDeliverys(List<Delivery> deliverys)
        {
            string todosLosDelivery = "";
            foreach (Delivery d in deliverys)
            {
                todosLosDelivery += $"Delivery:{d} {Environment.NewLine}";
            }
            return todosLosDelivery;
        }
        //termina Stringify de Lista de Deliverys con restricciones
        
        //Método Existe Repartidor
        public bool ExisteRepartidor(string r)
        {
            bool res = false;
            for(int i=0; i<GetRepartidores().Count && res==false; i++)
            {
                string  filtro = GetRepartidores()[i].Nombre.ToUpper();
                if (filtro.Equals(r.ToUpper()))
                {
                    res = true;
                }
            }
            return res;
        }
        //termina Método Existe Repartidor

        //PRECARGA DE DATOS
        private void PrecargarDatos()
        {
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
            Repartidor repartidor2 = new Repartidor("Nicolas", "Varaldo", Repartidor.Vehiculo.a_pie);
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


            //Carritos
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
            CantidadPlatos cantidadVeinte = new CantidadPlatos(plato8, 3);
            cantidadPlatos10.Add(cantidadVeinte);

            //termina Carritos

            // Servicios
            Delivery s1d = new Delivery(cantidadPlatos1, new DateTime(2021, 12, 3), cliente1, 1, repartidor1);
            AltaDelivery(s1d);
            Delivery s2d = new Delivery(cantidadPlatos2, new DateTime(2021, 12, 8), cliente2, 2.5, repartidor2);
            AltaDelivery(s2d);
            Delivery s3d = new Delivery(cantidadPlatos3, new DateTime(2021, 10, 5), cliente3, 5, repartidor2);
            AltaDelivery(s3d);
            Delivery s4d = new Delivery(cantidadPlatos4, new DateTime(2021, 9, 6), cliente4, 8, repartidor4);
            AltaDelivery(s4d);
            Delivery s5d = new Delivery(cantidadPlatos5, new DateTime(2021, 8, 7), cliente5, 10, repartidor5);
            AltaDelivery(s5d);
            Local s6l = new Local(cantidadPlatos6, new DateTime(2022, 1, 8), cliente1, 1, mozo1, 6);
            AltaLocal(s6l);
            Local s7l = new Local(cantidadPlatos7, new DateTime(2022, 2, 9), cliente2, 2, mozo2, 5);
            AltaLocal(s7l);
            Local s8l = new Local(cantidadPlatos8, new DateTime(2022, 3, 10), cliente3, 3, mozo3, 4);
            AltaLocal(s8l);
            Local s9l = new Local(cantidadPlatos9, new DateTime(2022, 4, 11), cliente4, 4, mozo4, 3);
            AltaLocal(s9l);
            Local s10l = new Local(cantidadPlatos10, new DateTime(2022, 5, 1), cliente5, 5, mozo5, 5);
            AltaLocal(s10l);
            //termina Servicios

        }
    }
}
