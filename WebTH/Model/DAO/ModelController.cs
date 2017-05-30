using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using System.Data.Entity;
using PagedList;
namespace Model
{
    public abstract class ModelController<model>  where model : class, new() 
    {
        protected DbSet<model> Execute;

        private object GetEF()
        {
            model m = new model();

            if (m is BaiHoc)
                return Base.Instance.BaiHoc;
            else if (m is BinhLuan)
                return Base.Instance.BinhLuan;
            else if (m is BaiHocTag)
                return Base.Instance.BaiHocTag;
            else if (m is Like)
                return Base.Instance.Like;
            else if (m is LoaiBaiHoc)
                return Base.Instance.LoaiBaiHoc;
            else if (m is Tag)
                return Base.Instance.Tag;
            else if (m is User)
                return Base.Instance.User;
            else if (m is Credential)
                return Base.Instance.Credential;
            else if (m is UserGroup)
                return Base.Instance.UserGroup;
            else if (m is Role)
                return Base.Instance.Role;
            else
                return null;
        }

        public ModelController()
        {
            if(Execute == null)
                Execute = GetEF() as DbSet<model>;
        }

        #region Common Excution
        public List<model> EncuteQuery(string Query)
        {
            return Execute.SqlQuery(Query).ToList();
        }
        #endregion

        #region Insert
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Insert(model obj)
        {
            Execute.Add(obj);
            return (Base.Instance.SaveChanges() > 0);
        }

        /// <summary>
        /// Insert list
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public bool Insert(List<model> objs)
        {
            Execute.AddRange(objs);

            try
            {
                Base.Instance.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete with where
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool DeleteWhere(String index)
        {
            Execute.RemoveRange(Execute.AsQueryable().Where(index).ToList());
            try
            {
                Base.Instance.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// delete with object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Delete(model obj)
        {
            Execute.Attach(obj);
            Execute.Remove(obj);
            try
            {
                Base.Instance.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Delete(List<model> list)
        {
            foreach (var item in list)
            {
                Execute.Attach(item);
                Execute.Remove(item);
            }
            try
            {
                Base.Instance.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region select

        /// <summary>
        /// Select where with directory
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public List<model> SelectWhere(string st)
        {
            var ls = Execute.AsQueryable().Where(st).ToList();
            return ls;

        }


        public List<model> SelectOrderWhere(string where, string order)
        {
            var ls = Execute.AsQueryable().Where(where).OrderBy(order).ToList();
            return ls;
        }
        /// <summary>
        /// Select get all obj
        /// </summary>
        /// <param name="sl"></param>
        /// <returns></returns>
        public List<model> SelectAll()
        {
            return Execute.ToList();
        }

        /// <summary>
        /// select all order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<model> SelectAll(string order)
        {
            return Execute.OrderBy(order).ToList();
        }
        /// <summary>
        /// Select top with number
        /// </summary>
        /// <param name="nub"></param>
        /// <returns></returns>
        public List<model> SelectTop(int nub)
        {
            return Execute.Take(nub).ToList();
        }
        /// <summary>
        /// select top order with number select
        /// </summary>
        /// <param name="nub"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<model> SelectTop(int nub, string order)
        {
            return Execute.Take(nub).OrderBy(order).ToList();
        }

        #endregion

        #region Update
        /// <summary>
        /// Update with obj
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool Update(model e)
        {
            Execute.Attach(e);
            Base.Instance.Entry(e).State = EntityState.Modified;
            return (Base.Instance.SaveChanges() > 0);
        }

        public bool Update(model e, model b)
        {
            Base.Instance.Entry(b).CurrentValues.SetValues(e);
            return (Base.Instance.SaveChanges() > 0);
        }


        public bool Update(List<model> list)
        {
            foreach (var e in list)
            {
                Execute.Attach(e);
                Base.Instance.Entry(e).State = EntityState.Modified;
            }
            try
            {
                Base.Instance.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion




    }
}
