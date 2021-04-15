using System;
using System.Text.RegularExpressions;
namespace BDentity588
{
    class Validaciones
    {
        public bool Vacio(string texto)
        {
            if (texto.Equals(""))
            {
                Console.SetCursorPosition(40, 22); Console.Write(" El texto no puede ser vacio");
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TipoNumero(string Numero)
        {
            Regex regla = new Regex("[0-9]{1,9}(\\.[0-9]{0,2})?$");

            if (regla.IsMatch(Numero))
                return true;

            else
            {
                Console.SetCursorPosition(40, 22); Console.Write(" La Entrada debe ser numerica");
                return false;
            }
        }

        public bool TipoTexto(string texto)
        {
            Regex regla = new Regex("^[a-zA-Z ]*$");

            if (regla.IsMatch(texto))
            {
                return true;
            }
            else
            {
                Console.SetCursorPosition(40, 23); Console.Write(" La Entrada debe ser texto");
                return false;
            }
        }
        public bool TipoCorreo(string Correo)
        {
            //Regex regla = new Regex("\\w+([-+.']\\w+)@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");

            //if (regla.IsMatch(Correo))
            //    return true;

            //else
            //{
            //    Console.SetCursorPosition(40, 22); Console.Write(" La Entrada debe ser correo ");
            //    return false;
            //}
            //string regla = @" ^\w+([-+.']\w+)@\w+([-.]\w+)\.\w+([-.]\w+)*$";
            string regla = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            bool aux = false;

            if (Regex.IsMatch(Correo, regla))
            {
                aux = true;
            }
            else 
            {
                Console.SetCursorPosition(40, 23); Console.Write("La Entrada debe ser correo");
       
            }
            return aux;
        }

    }
}

