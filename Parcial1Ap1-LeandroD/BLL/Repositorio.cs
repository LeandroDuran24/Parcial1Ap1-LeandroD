using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Parcial1Ap1_LeandroD.DAL;
using Parcial1Ap1_LeandroD.Entidades;

namespace Parcial1Ap1_LeandroD.DAL
{
    public class Repositorio <TEntity> : IRepository1<TEntity> where TEntity : class
    {
        Parcial1Db context = null;

        public Repositorio()
        {
            context = new Parcial1Db();
        }

        private DbSet <TEntity>EntitySet
        {
            get
            {
                return context.Set<TEntity>();
            }
        }

        public TEntity Guardar(TEntity nuevo)
        {
            TEntity result = null;
            try
            {
                EntitySet.Add(nuevo);
                context.SaveChanges();
                result = nuevo;

            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public TEntity Buscar(Expression<Func<TEntity, bool>> Id)
        {
            TEntity result = null;
            try
            {
                result = EntitySet.FirstOrDefault(Id);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool Eliminar(TEntity Id)
        {
            bool result = false;
            try
            {
                EntitySet.Attach(Id);
                EntitySet.Remove(Id);
                result = context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public  List<TEntity>GetList()
        {
          
            try
            {
                return  EntitySet.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
            
        public  List<TEntity>GetListNombre(Expression<Func<TEntity, bool>> nombre)
        {
            try
            {
                return EntitySet.Where(nombre).ToList();
            }
            catch (Exception)
            {

                throw;
            }
           
            
        }

        public List<TEntity>GetListFecha(Expression<Func<TEntity, bool>> fecha)
        {
            try
            {
                return EntitySet.Where(fecha).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
           if(context!=null)
           {
                context.Dispose();
           }
        }
    }
}
