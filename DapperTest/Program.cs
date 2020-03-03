using Dapper;
using DapperTest.DapperHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DapperTest
{
    class Program
    {
        private const string SQL_SELECT = "select * from OR_Person where Name like @Name ";
        static void Main(string[] args)
        {

            var constr = ConfigurationManager.ConnectionStrings["YF"].ToString();
            IDbConnection connection = new SqlConnection(constr);
            

            var obj = new List<decimal>() { 491,494,511,525,531,577,763};
            ISqlBuilderAction builder = SqlBuilderFactory.CheckFactory<OR_Person>(SqlBuilderEnum.Select);
            //builder.Add("Id in @Id", "Id", obj);
            builder.Add("Name like @Name", "Name", "%张%");
            var list = connection.Query<OR_Person>(builder.Sql, builder.Parameters).ToList();
            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
            //conn.Open();
            //var count =conn.ExecuteScalarAsync<int>("SELECT count(1) FROM[dbo].[tag] a");
            //conn.Close();

            //conn = new SqlConnection("Data Source=.;Integrated Security=True;Initial Catalog=cms;Pooling=true;Max Pool Size=11");
            //conn.Open();
            //var items =conn.QueryAsync("SELECT TOP 20 a.[id], a.[parent_id], a.[name] FROM[dbo].[tag] a");
            //conn.Close();


            //System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            //watch.Start();  //开始监视代码运行时间                          

            //watch.Stop();  //停止监视
            //TimeSpan timespan = watch.Elapsed;  //获取当前实例测量得出的总时间
            //timespan.Seconds.ToString();
            //Console.WriteLine(timespan.TotalMilliseconds.ToString());
            //Select(new OR_Person());
            Console.ReadKey();

        }

        static void Select(OR_Person person)
        {
            StringBuilder stringBuilder = new StringBuilder();
            //object obj = new { Name = "%张%" };
            stringBuilder.AppendFormat(SQL_SELECT);
            //stringBuilder.AppendFormat(" WHERE  Name LIKE @NAME");
            var constr = ConfigurationManager.ConnectionStrings["YF"].ToString();
            

            object obj = new ExpandoObject();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            //dic.Add("Name", "%张%");
            IDbConnection connection = new SqlConnection(constr);
            foreach (KeyValuePair<string, object> item in dic)
            {
                ((IDictionary<string, object>)obj).Add(item.Key, item.Value);
            }
            var roles = connection.Query<OR_Person>(stringBuilder.ToString(), obj);
            foreach (var item in roles)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
        }
    }


    public class SqlHelper
    { 
    
    
    }
      
    public class AC_SysRoles
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class OR_Person
    {
        public decimal Id { get; set; }
        public string PsnNum { get; set; }
        public string Name { get; set; }
        public string CodeDepartment { get; set; }
        public string LeaveDate { get; set; }
    }
}
