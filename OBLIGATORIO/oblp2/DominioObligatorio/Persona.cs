using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public abstract class Persona:IValidacion   
    {
        

        public  static int ultimoId{ get; set; }
        public int id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public Persona(string nombre, string apellido)
        {
            id = ultimoId;
            ultimoId++;
            Nombre = nombre;
            Apellido = apellido;
        }

        public Persona()
        {

        }
        /* public virtual bool EsNumero(string nombre, string apellido)
         {
             bool ret = false;
             int n;
             bool resultN = Int32.TryParse(nombre, out n);
             bool resultA = Int32.TryParse(apellido, out n);
             if (resultN && resultA)
             {
                 ret = true;
             }
             return ret;
         } */
        private bool tieneNumero(string c)
        {
            bool ret = false;
            string numeros = "0123456789";
            for (int i = 0; i < c.Length && !ret; i++)
            {
                for (int n = 0; n < numeros.Length && !ret; n++)
                {
                    if (c[i].Equals(numeros[n]))
                    {
                        ret = true;
                    }
                }
            }
            return ret;
        }

        public virtual bool EsValido()
        {
            return !String.IsNullOrEmpty(Nombre) && !tieneNumero(Nombre) && !tieneNumero(Apellido) && !String.IsNullOrEmpty(Apellido);
        }
    }
}
