using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Parcial1Ap1_LeandroD.DAL
{
    public interface IRepository1 <TEntity> : IDisposable where TEntity : class
    {
        TEntity Guardar(TEntity nuevo);
        bool Eliminar(TEntity Id);
        TEntity Buscar(Expression<Func<TEntity, bool>> Id);
        List<TEntity> GetList();
        List<TEntity> GetListNombre(Expression<Func<TEntity, bool>> nombre);
        List<TEntity> GetListFecha(Expression<Func<TEntity, bool>> fecha);
    }
}
