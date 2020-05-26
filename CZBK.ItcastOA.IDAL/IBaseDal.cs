using CZBK.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.IDAL
{
    public interface IBaseDal<T>where T:class,new()
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereLambda">查询条件</param>
        /// <returns></returns>
        IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 封装的分页的方法
        /// </summary>
        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount,
            System.Linq.Expressions.Expression<Func<T, bool>> whereLambda,
            System.Linq.Expressions.Expression<Func<T, s>> orderLambda, bool isAsc);
        /// <summary>
        /// 删除
        /// </summary>
        bool DeleteEntity(T entity);
        /// <summary>
        /// 编辑
        /// </summary>
        bool EditEntity(T entity);
        /// <summary>
        /// 添加
        /// </summary>
        T AddEntity(T entity);
    }
}
