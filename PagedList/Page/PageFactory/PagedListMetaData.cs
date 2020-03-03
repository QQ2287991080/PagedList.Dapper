using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagedList.Page.PageFactory
{
    /// <summary>
    /// 实现抽象类
    /// </summary>
    public class PagedListMetaData : IPagedList
    {
        public int TotalItemCount { get; protected set; }

        public int PageCount { get; protected set; }

        public int PageSize { get; protected set; }

        public int PageIndex { get; protected set; }

        public bool HasPreviousPage { get; protected set; }

        public bool HasNextPage { get; protected set; }

        public bool IsFirstPage { get; protected set; }

        public bool IsLastPage { get; protected set; }

        public int FirstItemOnPage { get; protected set; }

        public int LastItemOnPage { get; protected set; }

        /// <summary>
        /// 实现IPagedList有参构造函数
        /// </summary>
        /// <param name="pagedList"></param>

        public PagedListMetaData(IPagedList pagedList)
        {
            this.PageCount = pagedList.PageCount;
            this.PageIndex = pagedList.PageIndex;
            this.PageSize = pagedList.PageSize;
            this.TotalItemCount = pagedList.TotalItemCount;
            this.IsFirstPage = pagedList.IsFirstPage;
            this.IsLastPage = pagedList.IsLastPage;
            this.HasNextPage = pagedList.HasNextPage;
            this.HasPreviousPage = pagedList.HasPreviousPage;
            this.FirstItemOnPage = pagedList.FirstItemOnPage;
            this.LastItemOnPage = pagedList.LastItemOnPage;
        }
        protected PagedListMetaData()
        { 
        
        }
    }
}
