using DapperTest.DapperHelper.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest.DapperHelper
{
   public class SqlBuilderFactory
    {

        public static ISqlBuilderAction CheckFactory<T>(SqlBuilderEnum builderEnum)
        {
            switch (builderEnum)
            {
                case SqlBuilderEnum.Select:
                    return new SqlBuilderSelect<T>();
                //case SqlBuilderEnum.Insert:
                //    return new SqlBuilderInsertOrUpdate<T>();
                default:
                    throw new NotSupportedException("Unsupported enumeration type！");
            }
        }
        public static ISqlBuilderAction CheckFactory(SqlBuilderEnum builderEnum)
        {
            switch (builderEnum)
            {
                case SqlBuilderEnum.Select:
                    return new SqlBuilderSelect();
                //case SqlBuilderEnum.Insert:
                //    return new SqlBuilderInsertOrUpdate();
                default:
                    throw new NotSupportedException("Unsupported enumeration type！");
            }
        }
    }


    public enum SqlBuilderEnum
    {
        Select = 0,
        Insert = 1
    }
}
