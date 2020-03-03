using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest.DapperHelper
{
    public interface ISqlBuilderAction : IBuilderParameters
    {
        void Add(string sql, string paramName, object obj);

    }
}
