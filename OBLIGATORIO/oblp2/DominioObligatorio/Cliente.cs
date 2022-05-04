using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace DominioObligatorio
{
    public class Cliente : Persona,IComparable<Cliente>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public Cliente(string nombre, string apellido, string email, string password) : base(nombre, apellido)
        {
            Email = email;
            Password = password;
        }

        public Cliente()
        {

        }

        public override string ToString()
        {
            return $" Apellido: {Apellido} - Nombre: {Nombre} - Email: {Email}";
        }

        //Métodos de Validación
        public bool ValidarEmail(string e)
        {
            bool ret = false;

            if (!String.IsNullOrEmpty(e))
            {
                if (e.IndexOf("@") != -1)
                {
                    if (!e[0].Equals("@") && !e[e.Length - 1].Equals("@"))
                    {
                        ret = true;
                    }
                }

            }
            return ret;
        }

        public bool ValidarPassword(string pwd)
        {
            bool ret = false;
            if (!String.IsNullOrEmpty(pwd))
            {
                if (pwd.Length >= 6)
                {
                    if (TieneNumero(pwd) && TieneMayuscula(pwd) && TieneMinuscula(pwd))
                    {
                        ret = true;
                    }
                }
            }
            return ret;
        }

        public bool TieneMayuscula(string c)
        {
            bool ret = false;
            string minuscula = c.ToLower();
            if (c != minuscula)
            {
                ret = true;
            }
            return ret;
        }

        public bool TieneMinuscula(string c)
        {
            bool ret = false;
            string mayuscula = c.ToUpper();
            if (c != mayuscula)
            {
                ret = true;
            }
            return ret;
        }

        public override bool EsValido()
        {
            return base.EsValido() && ValidarEmail(Email) && ValidarPassword(Password);
        }
        //termina Métodos de Validación

        //Criterio de Ordenación
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
        //termina Criterio de Ordenación
    }
}