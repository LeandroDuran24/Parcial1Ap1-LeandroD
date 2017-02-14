using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parcial1Ap1_LeandroD
{
    public class Utilitarios
    {
        public static int TOINT (string nombre)
        {
                int numero;
                int.TryParse(nombre, out numero);
                return numero;
        }
    }
}
