using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;


namespace Core.DataAccess
{
    //CLASS : REFERENS TIP
    //GENERIC CONSTRAINT = GENEL KISITLAMA
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new() : NEW'LENEBİLİR OLMALI ( !! IEntity newlenemez interfacedir ))
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
