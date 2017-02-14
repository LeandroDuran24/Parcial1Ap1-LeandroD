using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Parcial1Ap1_LeandroD.Entidades;

namespace Parcial1Ap1_LeandroD.DAL
{
    public class Parcial1Db:DbContext
    {
        public Parcial1Db():base("ConStr")
        {

        }
        public DbSet <Empleados> empleado { get; set; }
    }
}
