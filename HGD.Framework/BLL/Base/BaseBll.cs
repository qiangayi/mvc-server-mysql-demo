using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HGD.Framework.Orm;

namespace HGD.Framework.BLL.Base
{
    public class BaseBllL<T> where T : class, new()
    {
        public static HGDContext db => new HGDContext();
        public static T Add(T entity)
        {
            db.Set<T>().Add(entity);
            //db.SaveChanges();
            return entity;
        }

        public static bool Del(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Deleted;
            return true;
        }

        public static bool Update(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Modified;
            return true;
        }

        public static IQueryable<T> List(Expression<Func<T, bool>> whereLambda)
        {
            return db.Set<T>().Where<T>(whereLambda);
        }

        public static IQueryable<T> ListPage<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderByLambda, bool isAsc)
        {
            var temp = db.Set<T>().Where<T>(whereLambda);
            totalCount = temp.Count();
            if (isAsc)
            {
                temp = temp.OrderBy<T, s>(orderByLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderByLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;
        }
        public static int Count()
        {
            return db.Set<T>().Count();
        }
    }
}
