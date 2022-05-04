using System;
using DominioObligatorio;

namespace InterfazConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Sistema s = new Sistema();

            int op = -1;
            while (op != 0)
            {
                //MENÚ
                Console.Clear();
                Console.WriteLine("--MENÚ--");
                Console.WriteLine("1 - Listar Platos");
                Console.WriteLine("2 - Listar Clientes ordenado por apellido / nombre");
                Console.WriteLine("3 - Listar servicios entregados por un repartidor en un rango de fechas");
                Console.WriteLine("4 - Modificar el valor del precio minimo");
                Console.WriteLine("5 - Alta Mozo");
                Console.WriteLine("6 - Salir");
                //termina MENÚ

                int opcion = Int32.Parse(Console.ReadLine());

                //Salír
                if (opcion.Equals(6))
                {
                    op = 0;
                }
                //Listar Platos
                else if (opcion.Equals(1))
                {
                    Console.Clear();
                    Console.WriteLine("Lista de platos:");
                    string listaP = s.MostrarPlatos();
                    if (!String.IsNullOrEmpty(listaP))
                    {
                        Console.WriteLine(listaP);
                    }
                    else
                    {
                        Console.WriteLine("No hay platos registrados por el momento.");
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                //Listar Clientes
                else if (opcion.Equals(2))
                {
                    Console.Clear();
                    Console.WriteLine("Lista de clientes ordenados por Apellido / nombre:");
                    string listaC = s.MostrarClientes();
                    if (!String.IsNullOrEmpty(listaC))
                    {
                        Console.WriteLine(listaC);
                    }
                    else
                    {
                        Console.WriteLine("No hay clientes registrados por el momento.");
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                //Listar Deliverys con restricciones
                else if (opcion.Equals(3))
                {
                    Console.Clear();
                    Console.WriteLine("Lista de deliverys entregados por un repartidor en un rango de fechas:");
                    Console.WriteLine("Ingrese el nombre del repartidor a filtrar");
                    string d = Console.ReadLine().ToUpper();
                    if (!s.TieneNumero(d) && !String.IsNullOrEmpty(d))
                    {
                        Console.WriteLine("Ingrese la fecha inicial para el filtro");
                        string s1 = (Console.ReadLine());
                        Console.WriteLine("Ingrese la fecha final para el filtro");
                        string s2 = (Console.ReadLine());
                        if (s.EsFecha(s1) && s.EsFecha(s2))
                        {
                            DateTime d1 = DateTime.Parse(s1);
                            DateTime d2 = DateTime.Parse(s2);
                            string filtro = (s.MostrarDelivery(s.GetDeliverys(), d, d1, d2));
                            if (!String.IsNullOrEmpty(filtro))
                            {
                                Console.WriteLine(filtro);
                            }
                            else
                            {
                                Console.WriteLine("No hay pedidos que cumplan con las condiciones del filtro");
                            }
                        }
                        else
                        {
                            Console.WriteLine("las fechas ingresadas no fueron validas.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El nombre no es valido");
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                //Modificar precio mínimo
                else if (opcion.Equals(4))
                {
                    Console.Clear();
                    Console.WriteLine("Modificar el valor del precio minimo:");
                    Console.WriteLine("ingrese nuevo precio minimo");
                    string NuevoPrecioMin = Console.ReadLine();
                    if (int.TryParse(NuevoPrecioMin, out int num )) 
                    {
                    bool precioValido = s.ModificarPrecioMin(NuevoPrecioMin);
                    if (precioValido)
                    {
                        Console.WriteLine("Nuevo precio minimo: $" + Plato.PrecioMin);
                    }
                    else
                    {
                        Console.WriteLine("No se pudo cambiar el precio minimo.");
                    }
                    Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("No se ingresó un valor numérico");
                        Console.ReadKey();
                    }
                }
                //Alta Mozo
                else if (opcion.Equals(5))
                {
                    Console.Clear();
                    Console.WriteLine("Alta de un Mozo");
                    Console.WriteLine("Ingrese el nombre del mozo:");
                    string nombre = Console.ReadLine();
                    if (!s.TieneNumero(nombre) && !String.IsNullOrEmpty(nombre))
                    {
                        Console.WriteLine("Ingrese el apellido del mozo:");
                        string apellido = Console.ReadLine();
                        if (!s.TieneNumero(apellido) && !String.IsNullOrEmpty(apellido))
                        {
                            Mozo nMozo = new Mozo(nombre, apellido);
                            nMozo = s.AltaMozo(nMozo);
                            if (nMozo != null)
                            {
                                Console.WriteLine("El mozo fue dado de alta con exito");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("No se pudo agregar al mozo, cheque los datos ingresados (estos deben ser de tipo string).");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("El apellido no es valido");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("El nombre no es valido");
                        Console.ReadKey();
                    }

                }
                //Error de opción no válida
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opcion no valida, el numero ingresado debe estar entre el 1 y el 6");
                }
            }
        }
    }
}
