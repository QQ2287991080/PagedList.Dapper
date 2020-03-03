using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagedList.Page
{
    /// <summary>
    /// 分页抽象类
    /// </summary>
    public interface IPagedList
    {
        // 数据总条数
        int TotalItemCount { get; }
        // 总页数
        int PageCount { get; }
        // 每页显示数量
        int PageSize { get; }
        // 页码
        int PageIndex { get; }
        /// <summary>
        /// 有上一页?
        /// </summary>
        bool HasPreviousPage { get; }
        /// <summary>
        /// 有下一页?
        /// </summary>
        bool HasNextPage { get; }
        /// <summary>
        /// 是否是第一页
        /// </summary>
        bool IsFirstPage { get; }
        /// <summary>
        /// 是否是最后一页
        /// </summary>
        bool IsLastPage { get; }
        /// <summary>
        /// 第一项
        /// </summary>
        int FirstItemOnPage { get; }
        /// <summary>
        /// 最后一项
        /// </summary>
        int LastItemOnPage { get; }

    }
}
