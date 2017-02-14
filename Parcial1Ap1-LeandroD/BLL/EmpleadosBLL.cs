using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parcial1Ap1_LeandroD.DAL;
using Parcial1Ap1_LeandroD.Entidades;

namespace Parcial1Ap1_LeandroD.BLL
{
    public class EmpleadosBLL
    {
        public static bool Guardar(Empleados nuevo)
        {
            using (var guardado = new Parcial1Db())
            {
                try
                {
                    if (Buscar(nuevo.EmpleadoId) == null)
                    {
                        guardado.empleado.Add(nuevo);
                        guardado.SaveChanges();
                        return true;
                    }
                    else
                    {
                        guardado.Entry(nuevo).State = System.Data.Entity.EntityState.Modified;
                        guardado.SaveChanges();
                        return true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return false;
            }
        }
        public static Empleados Buscar(int usuario)
        {
            var conn = new Empleados();
            using (var buscado = new Parcial1Db())
            {
                try
                {
                    conn = buscado.empleado.Find(usuario);
                }
                catch (Exception)
                {

                    throw;
                }
                return conn;
            }
        }

        public static bool Eliminar(Empleados usuario)
        {
            using (var eliminado = new Parcial1Db())
            {
                try
                {
                    eliminado.Entry(usuario).State = System.Data.Entity.EntityState.Deleted;
                    eliminado.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
                return false;
            }
        }

        public static List<Empleados>GetListNombre(string nombre)
        {
            List<Empleados> lista = new List<Empleados>();
            using (var conn = new Parcial1Db())
            {
                try
                {
                    lista = conn.empleado.Where(p => p.Nombres == nombre).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                return lista;
            }
        }
        public static List<Empleados> GetListFecha(DateTime desde,DateTime hasta)
        {
            List<Empleados> lista = new List<Empleados>();
            using (var conn = new  Parcial1Db())
            {
                try
                {
                    lista = conn.empleado.Where(p => p.FechaNacimiento >= desde.Date && p.FechaNacimiento <= hasta.Date).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                return lista;
            }
        }
    }
}
