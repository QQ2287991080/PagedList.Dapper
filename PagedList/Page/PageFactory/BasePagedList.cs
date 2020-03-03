using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagedList.Page.PageFactory
{
    /// <summary>
    /// 逻辑实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BasePagedList<T> : PagedListMetaData, IPagedList<T>
    {
        /// <summary>
        /// 初始化数据容器
        /// </summary>
        protected  List<T> Subset = new List<T>();

        public T this[int index]
        {
            get { return this.Subset[index]; }
        }

        public virtual int Count { get { return this.Subset.Count; } }
        protected internal BasePagedList()
        {
        }
        public virtual void GetPagedList(int pageIndex,int pageSize,int  totalItemCount)
        {
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(string.Format("pageNumber = {0}. PageIndex cannot be below 1.", pageIndex));
            }
            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException(string.Format("pageSize = {0}. PageSize cannot be less than 1.", pageSize));
            }
            if (totalItemCount < 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("totalItemCount = {0}. TotalItemCount cannot be less than 0.", totalItemCount));
            }
            base.TotalItemCount = totalItemCount;
            base.PageSize = pageSize;
            base.PageIndex = pageIndex;
            base.PageCount = ((base.TotalItemCount > 0) ? ((int)Math.Ceiling((double)base.TotalItemCount / (double)base.PageSize)) : 0);
            bool flag = base.PageCount > 0 && base.PageIndex <= base.PageCount;
            base.HasPreviousPage = (flag && base.PageIndex > 1);
            base.HasNextPage = (flag && base.PageIndex < base.PageCount);
            base.IsFirstPage = (flag && base.PageIndex == 1);
            base.IsLastPage = (flag && base.PageIndex == base.PageCount);
            int num = (base.PageIndex - 1) * base.PageSize + 1;
            base.FirstItemOnPage = (flag ? num : 0);
            int num2 = num + base.PageSize - 1;
            base.LastItemOnPage = (flag ? ((num2 > base.TotalItemCount) ? base.TotalItemCount : num2) : 0);
        }
       
        public IEnumerator<T> GetEnumerator()
        {
            return this.Subset.GetEnumerator();
        }

        public PagedListMetaData GetMetaData()
        {
            return new PagedListMetaData(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
          return  this.GetEnumerator();
        }
    }
}
