using DapperTest.DapperHelper.Generic;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest.DapperHelper
{
    public class SqlBuilderSelect: ISqlBuilderAction
    {

        protected List<string> _sql = new List<string>();

        protected Dictionary<string, object> _dic = new Dictionary<string, object>();
        public void Add(string sql, string paramName, object obj)
        {
            _sql.Add(sql);
            _dic.Add(paramName, obj);
        }

        protected string SetSqlBuilder()
        {
            
            StringBuilder builder = new StringBuilder();
            var list = _sql;
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                    builder.Append(" Where " + list[i]);
                    continue;
                }
                builder.Append(" And " + list[i]);
            }
            return builder.ToString();
        }
        protected object SetParametersBuilder()
        {
            object obj = new ExpandoObject();
            foreach (KeyValuePair<string, object> item in _dic)
            {
                ((IDictionary<string, object>)obj).Add(item.Key, item.Value);
            }
            return obj;
        }
        public string Sql { get { return SetSqlBuilder(); } }


        public object Parameters { get { return SetParametersBuilder(); } }
    }
}
