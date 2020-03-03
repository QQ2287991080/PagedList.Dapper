using System;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperTestApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InsertTest()
        {
            OR_Person r_Person = new OR_Person
            {
                CodeDepartment = "1",
                Name = "哈哈哈",
                PsnNum = "123456789"
            };
            var str = DapperHelper.ExecuteInsert(r_Person);
            Console.WriteLine(str);
            Assert.IsNotNull(str);
        }
        [TestMethod]
        public void ListPageTest()
        {
            string sql = "select * from or_person";
            var list = DapperHelper.ExecutePageList<OR_Person>(sql, "Id desc", 1, 15);
            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
            Assert.IsNotNull(list);
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
}
