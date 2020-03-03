using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest.DapperHelper
{
  public interface IBuilderParameters
    {
        string Sql { get; }
        object Parameters { get; }
    }
}
