using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PagedList.Page.PageFactory
{
   public  class PagedList<T>:BasePagedList<T>
    {
		public PagedList(string sql, string sort, int pageIndex, int pageSize, IDbConnection connection, object param = null)
		{

            GetPagedListToSql(sql, sort,pageIndex,pageSize,connection,param);
        }
        protected  void GetPagedListToSql(string sql, string sort, int pageIndex, int pageSize, IDbConnection connection, object param = null)
        {
            string pageSql = @"SELECT TOP {0} * FROM (SELECT ROW_NUMBER() OVER (ORDER BY {1}) _row_number_,*  FROM 
              ({2})temp )temp1 WHERE temp1._row_number_>{3} ORDER BY _row_number_";
            string execSql = string.Format(pageSql, pageSize, sort, sql, pageSize * (pageIndex - 1));

            string totalSql = @"SELECT Count(*)  FROM (SELECT ROW_NUMBER() OVER (ORDER BY {0}) _row_number_,*  FROM 
              ({1})temp )temp1";
            string execSql2 = string.Format(totalSql, sort, sql);
            using (IDbConnection conn = connection)
            {
                conn.Open();
                TotalItemCount = conn.Query<int>(execSql2, param, commandTimeout: 30).Single();
                //PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(TotalItemCount) / Convert.ToDecimal(pageSize)));
                //PageSize = pageSize;
                //PageIndex = pageIndex;
                var list= conn.Query<T>(execSql, param, commandTimeout: 30).ToList();
                base.GetPagedList(pageIndex, pageSize, TotalItemCount);
                base.Subset.AddRange(list);
            }
        }
    }
}
