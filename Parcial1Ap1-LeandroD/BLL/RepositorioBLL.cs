using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parcial1Ap1_LeandroD.DAL;
using Parcial1Ap1_LeandroD.Entidades;

namespace Parcial1Ap1_LeandroD.BLL
{
    public class RepositorioBLL
    {
      public static bool Guardar(Empleados nuevo)
      {
            bool retorno = false;
            using (var conn = new Repositorio<Empleados>())
            {
                retorno = conn.Guardar(nuevo) != null;
            }
            return retorno;

      }  

      public static bool Eliminar(Empleados Id)
      {
            bool result = false;
            using (var conn = new Repositorio<Empleados>())
            {
                result = conn.Eliminar(Id) != null;
               
            }
            return result;
      }
    }
}
