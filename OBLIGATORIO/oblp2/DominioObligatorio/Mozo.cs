using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
  public  class Mozo:Persona
    {
        public int NroFuncionario { get; set; }
        public static int ultimoNroFuncionario { get; set; }

        public Mozo(string nombre, string apellido) : base(nombre, apellido)
        {
            NroFuncionario = ultimoNroFuncionario;
            ultimoNroFuncionario++;
        }
        public Mozo()
        {

        }

        public override string ToString()
        {
            return $"Nombre:{Nombre}Apellido:{Apellido} NroFuncionario:{NroFuncionario}";
        }

        

        public override bool EsValido()
        {

            return base.EsValido() &&  !NroFuncionario.Equals(null);
        } 




    }
}
