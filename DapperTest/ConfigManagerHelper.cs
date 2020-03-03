using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DapperTest
{
  public  class ConfigManagerHelper: ConfigurationBuilder
    {
        public override XmlNode ProcessRawXml(XmlNode rawXml)
        {

            string rawXmlString = rawXml.OuterXml;

            if (String.IsNullOrEmpty(rawXmlString))
            {
                return rawXml;
            }
            rawXmlString = Environment.ExpandEnvironmentVariables(rawXmlString);

            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.LoadXml(rawXmlString);
            return doc.DocumentElement;
        }

        public override ConfigurationSection ProcessConfigurationSection(ConfigurationSection configSection)
          => configSection;
        //static ConfigManagerHelper()
        //{
        //    var builder = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json");

        //    IConfigurationRoot configuration = builder.Build();
        //    _SqlConnectionStringCustom = configuration["ConnectionStrings:Customers"];
        //}
        //private static string _SqlConnectionStringCustom = null;
        //public static string SqlConnectionStringCustom
        //{
        //    get
        //    {
        //        return _SqlConnectionStringCustom;
        //    }
        //}
    }
}
