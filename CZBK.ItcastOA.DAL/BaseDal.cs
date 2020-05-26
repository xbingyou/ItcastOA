using CZBK.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.DAL
{
    public class BaseDal<T> where T:class,new()
    {
        DbContext Db = DBContextFactory.CreateDbContext();
        /// <summary>
        /// 添加
        /// </summary>
        public T AddEntity(T entity)
        {
            Db.Set<T>().Add(entity);
            //Db.SaveChanges();
            return entity;
        }
        /// <summary>
        /// 删除
        /// </summary>
        public bool DeleteEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            return true;
            //return Db.SaveChanges() > 0;
        }
        /// <summary>
        /// 更新
        /// </summary>
        public bool EditEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return true;
            //return Db.SaveChanges() > 0;
        }
        /// <summary>
        /// 查询过滤
        /// </summary>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where<T>(whereLambda);
        }
        /// <summary>
        /// 分页
        /// </summary>
        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderLambda, bool isAsc)
        {
            var temp = Db.Set<T>().Where<T>(whereLambda);
            totalCount = temp.Count();
            if (isAsc)//升序
                temp = temp.OrderBy<T, s>(orderLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            else//降序
                temp = temp.OrderByDescending<T, s>(orderLambda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            return temp;
        }
    }
}
