using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            Nombre = nombre.ToUpper();
            Apellido = apellido.ToUpper();
        }

        public Persona()
        {

        }

        public override string ToString()
        {
            return $" Apellido: {Apellido} - Nombre: {Nombre} ";
        }

        //Métodos de Validación
        public bool TieneNumero(string c)
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
            return !String.IsNullOrEmpty(Nombre) && !TieneNumero(Nombre) && !String.IsNullOrEmpty(Apellido) && !TieneNumero(Apellido);
        }
        //termina Método de Validación
    }
}