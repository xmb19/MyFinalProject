using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity>
        where TEntity:class, IEntity, new()
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of C#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); //kategoride product category oluyor, customer'da customer oluyor bu kod değişmiyor.
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList(); // filtre null mı? evet -> tümünü getir. hayır -> filtrele.
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}









//Aşağıdaki kodu kopyaladık, Product yerine TEntity NorthwindContext yerine TContext yazdık.



//public void Add(Product entity)
//{
//    //IDisposable pattern implementation of C#
//    using (NorthwindContext context = new NorthwindContext())
//    {
//        var addedEntity = context.Entry(entity);
//        addedEntity.State = EntityState.Added;
//        context.SaveChanges();
//    }
//}

//public void Delete(Product entity)
//{
//    using (NorthwindContext context = new NorthwindContext())
//    {
//        var deletedEntity = context.Entry(entity);
//        deletedEntity.State = EntityState.Deleted;
//        context.SaveChanges();
//    }
//}

//public Product Get(Expression<Func<Product, bool>> filter)
//{
//    using (NorthwindContext context = new NorthwindContext())
//    {
//        return context.Set<Product>().SingleOrDefault(filter); //kategoride product category oluyor, customer'da customer oluyor bu kod değişmiyor.
//    }
//}

//public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
//{
//    using (NorthwindContext context = new NorthwindContext()) 
//    {
//        return filter == null 
//            ? context.Set<Product>().ToList() 
//            : context.Set<Product>().Where(filter).ToList(); // filtre null mı? evet -> tümünü getir. hayır -> filtrele.
//    }
//}

//public void Update(Product entity) 
//{
//    using (NorthwindContext context = new NorthwindContext())
//    {
//        var updatedEntity = context.Entry(entity);
//        updatedEntity.State = EntityState.Modified;
//        context.SaveChanges();
//    }
//}
