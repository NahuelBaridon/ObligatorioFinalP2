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

        public virtual bool EsValido()
        {
            return !String.IsNullOrEmpty(Nombre) && !String.IsNullOrEmpty(Apellido);
        }
    }
}
