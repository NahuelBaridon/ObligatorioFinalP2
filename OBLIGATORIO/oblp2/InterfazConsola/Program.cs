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
                Console.Clear();
                Console.WriteLine("1 - Listar Platos");
                Console.WriteLine("2 - Listar Clientes ordenado por apellido / nombre");
                Console.WriteLine("3 - Listar servicios entregados por un repartidor en un rango de fechas");
                Console.WriteLine("4 - Modificar el valor del precio minimo");
                Console.WriteLine("5 - Alta mozo");
                Console.WriteLine("6 - Salir");
                int opcion = Int32.Parse(Console.ReadLine());
                if (opcion.Equals(6))
                {
                    op = 0;
                   
                }
                else if (opcion.Equals(1))
                {
                    Console.WriteLine("Lista de platos:");
                    Console.WriteLine(s.MostrarPlatos());
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (opcion.Equals(2))
                {
                    Console.Clear();
                }
                else if (opcion.Equals(3))
                {
                    Console.Clear();
                }
                else if (opcion.Equals(4))
                {
                    Console.Clear();
                    Console.WriteLine("ingrese nuevo precio minimo");
                    double NuevoPrecioMin = Int32.Parse(Console.ReadLine());
                    s.ModificarPrecioMin(NuevoPrecioMin);
                    
                }
                else if (opcion.Equals(5))
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese el nombre del mozo:");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el apellido del mozo:");
                    string apellido = Console.ReadLine();
                    Mozo nMozo = new Mozo(nombre, apellido);
                    nMozo = s.AltaMozo(nMozo);
                    if (!nMozo.Equals(null))
                    {
                        Console.WriteLine("El mozo fue dado de alta con exito");
                    }
                    else
                    {
                        Console.WriteLine("No se pudo agregar al mozo, cheque los datos ingresados.");
                    }
                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opcion no valida, el numero ingresado debe estar entre el 1 y el 6");
                }
                Console.ReadKey(); 
            }
        }
    }
}
