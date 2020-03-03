using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest.DapperHelper.Generic
{
    public interface IBuilderParameters<out T> : ISqlBuilderAction
    {

    }
}
