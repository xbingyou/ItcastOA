using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CZBK.ItcastOA.DALFactory;
using CZBK.ItcastOA.IDAL;

namespace CZBK.ItcastOA.BLL
{
    /// <summary>
    /// 在业务基类中完成DBSession的调用，然后将业务层中的方法定义在基类中，
    /// 但是这些方法不知道通过DBSession来获取哪个数据操作类的实例。
    /// 所以将该业务基类定义成抽象类，加上一个抽象方法，加上一个IBaseDal的属性，
    /// 并且让基类的构造方法调用抽象方法目的是在表现层new具体的业务子类，
    /// 父类的构造方法被调用，这时执行抽象方法，但是执行的是子类中具体的实现。
    /// 业务子类知道通过DBSession获取哪个数据操作类的实例。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseService<T> where T:class,new()
    {
        public IDBSession CurrentDBSession
        {
            get
            {
                return DBSessionFactory.CreateDBSession();
            }
        }
        public IBaseDal<T> CurrentDal { get; set; }
        public abstract void SetCurrentDal();
        public BaseService()
        {
            SetCurrentDal();//子类一定要实现抽象方法
        }
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.LoadEntities(whereLambda);
        }
        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderLambda, bool isAsc)
        {
            return CurrentDal.LoadPageEntities<s>(pageIndex, pageSize, out totalCount,
                whereLambda, orderLambda, isAsc);
        }
        /// <summary>
        /// 删除
        /// </summary>
        public bool DeleteEntity(T entity)
        {
            CurrentDal.DeleteEntity(entity);
            return CurrentDBSession.SaveChanges();
        }
        /// <summary>
        /// 更新
        /// </summary>
        public bool EditEntity(T entity)
        {
            CurrentDal.EditEntity(entity);
            return CurrentDBSession.SaveChanges();
        }
        /// <summary>
        /// 添加
        /// </summary>
        public T AddEntity(T entity)
        {
            CurrentDal.AddEntity(entity);
            CurrentDBSession.SaveChanges();
            return entity;
        }
    }
}
