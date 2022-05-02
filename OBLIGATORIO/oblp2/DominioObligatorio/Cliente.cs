using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace DominioObligatorio
{
    public class Cliente : Persona, IComparable<Cliente>
    {
        public Cliente(string nombre, string apellido, string email, string password) : base(nombre, apellido)
        {
            Email = email;
            Password = password;

        }

        public string Email { get; set; }

        public string Password { get; set; }



        public override bool EsValido()
        {
            return base.EsValido() && !String.IsNullOrEmpty(Email) && !String.IsNullOrEmpty(Password);
        }

        public bool ValidarEmail(string e)
        {
            bool ret = false;

            if (e.IndexOf("@") != -1)
            {
                if (!e[0].Equals("@") && !e[e.Length - 1].Equals("@"))
                {
                    ret = true;
                }
            }
            return ret;
        }
        public int CompareTo([AllowNull] Cliente other)
        {
            if (Apellido.CompareTo(other.Apellido) > 0)
            {
                return 1;
            }
            else if (Apellido.CompareTo(other.Apellido) < 0)
            {
                return -1;
            }
            else
            {
                if (Nombre.CompareTo(other.Nombre) > 0)
                {
                    return 1;
                }
                else if (Nombre.CompareTo(other.Nombre) < 0)
                {
                    return -1;
                }
                else
                {
                    return 0;

                }

            }
        }
    }
}