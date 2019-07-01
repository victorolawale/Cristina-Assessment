using GraduationTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Services
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId> 
        where TEntity : BaseEntity<TId> where TId : struct
    {
        public TEntity GetById(TId id)
        {
           // var expression = CreateEqualityExpressionForId(id);

            return GetAll()
                .FirstOrDefault(x=>x.Id.ToString() == id.ToString());
        }

        protected abstract IEnumerable<TEntity> GetAll();

        //protected bool CreateEqualityExpressionForId(TEntity entity)
        //{
        //    var lambdaParam = Expression.Parameter(typeof(TEntity));

        //    var lambdaBody = Expression.Equal(
        //      Expression.PropertyOrField(lambdaParam, "Id"),
        //      Expression.Constant(entity.Id, typeof(TId))
        //      );

        //    return

        //}
       


        //protected  Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TId id)
        //{
        //    var lambdaParam = Expression.Parameter(typeof(TEntity));

        //    var lambdaBody = Expression.Equal(
        //        Expression.PropertyOrField(lambdaParam, "Id"),
        //        Expression.Constant(id, typeof(TId))
        //        );

        //    return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        //}
    }
}
