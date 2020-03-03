using PagedList.Page.PageFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagedList.Page
{
    /// <summary>
    /// 方法实现类
    /// </summary>
   public static class PagedListController                                                                                                                                                                                     
    {
        public static IPagedList<T> ToPgedList<T>(string sql, string sort, int pageIndex, int pageSize, IDbConnection connection, object param = null)
        {
            return new PagedList<T>(sql, sort, pageIndex, pageSize, connection, param);
        }
    }
}
