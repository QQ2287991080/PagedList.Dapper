using AutoMapper;
using Dapper;
using PagedList.Page;
using PagedList.Page.PageFactory;
using SqlBuilderTool;
using SqlBuilderTool.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
//using X.PagedList;

namespace PagedList
{
    class Program
    {
        static void Main(string[] args)
        {


            {
                //List<OR_Person> oRs = new List<OR_Person>();
                //IPagedList xx = oRs.ToPagedList();
                //var obj = new
                //{
                //    Data = xx

                //};
                //Console.WriteLine(obj);
            }
            {

                Expression<Func<OR_Person, bool>> expression = null ;
                OR_Person oR_Person = new OR_Person()
                {
                    CodeDepartment = "1",
                    Name = "555",
                    PsnNum = "2222"
                };

                Func<OR_Person, (string,object)> func = p =>
                {
                    
                    var type = p.GetType();
                    StringBuilder builder = new StringBuilder($"Insert into  {type.Name} ");
                    List<string> column = new List<string>();
                    List<string> value = new List<string>();
                   
                    var obj = new DynamicParameters();
                    foreach (var item in type.GetProperties())
                    {   
                        if (item.Name =="Id")
                        {
                            continue;
                        }
                        column.Add(" " + item.Name + " ");
                        value.Add(" @" + item.Name + " ");
                        obj.Add(item.Name, item.GetValue(p));
                    }
                   
                    builder.Append(" ( "+string.Join(",",column)+" ) ");
                    builder.Append("values ( "+string.Join(",",value)+" )");
                    return (builder.ToString(),obj);

                };
                {
                    var re = func.Invoke(oR_Person);
                    string sql = "select * from OR_Person  ";

                    IPagedList<OR_Person> list = PagedListController.ToPgedList<OR_Person>(sql, "Id", 1, 15, new SqlConnection("Data Source=.;Initial Catalog=YiFang_CustomerComplaint;User ID=sa;Password=123456;"));

                }
                {
                    ISqlBuilderFuncation xx = SqlBuilderFactory.CreateBuilder<OR_Person>();
                    var sql = xx.Sql;
                    IPagedList<OR_Person> list = PagedListController.ToPgedList<OR_Person>(sql, "Id", 1, 15, new SqlConnection("Data Source=.;Initial Catalog=YiFang_CustomerComplaint;User ID=sa;Password=123456;"));
                    foreach (var item in list)
                    {
                        Console.WriteLine(item.Id);
                    }
                }
                //foreach (var item in list)
                //{
                //    Console.WriteLine(item.Id);

                //}
                //var mapper = new MapperConfiguration(c =>
                //{
                //    c.CreateMap<OR_Person, OR_PersonEntity>();
                //    c.CreateMap<OR_PersonEntity, OR_Person>();
                //});
                //mapper.AssertConfigurationIsValid();
                //IMapper mapper1 = new Mapper(mapper);
                //mapper1.Map<OR_PersonEntity>(list[0]);
                //var entityList = mapper1.Map<List<OR_PersonEntity>>(list);
                //foreach (var item in entityList)
                //{
                //    Console.WriteLine(item.Id);
                //}
                //Console.WriteLine(list.PageCount);
                //Console.WriteLine(list);
            }
            Console.ReadKey();
        }
    }

    public class OR_Person
    {
        public decimal Id { get; set; }
        public string PsnNum { get; set; }
        public string Name { get; set; }
        public string CodeDepartment { get; set; }
        public string LeaveDate { get; set; }
    }


    public class OR_PersonEntity
    {
        public decimal Id { get; set; }
        public string PsnNum { get; set; }
        public string Name { get; set; }
        public string CodeDepartment { get; set; }
        public string LeaveDate { get; set; }
    }
}
