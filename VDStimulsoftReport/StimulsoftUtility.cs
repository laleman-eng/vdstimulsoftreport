using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Stimulsoft.Report;
using System.IO;
using System.Windows;
using System.Data;
using System.Xml;


namespace VDStimulsoftReport
{
    public class StimulsoftUtility 
    {
        public string openReportStimulsoft(XmlDocument xml)
        {
            
            var report = StiReport.CreateNewReport();

            try
            {
               // report.Load("C:\\ReportTest.mrt");
                report.Load("C:\\33_VisualK_CL.mrt");
                report.Dictionary.Databases.Clear();
                var ds = ConvertXMLToDataSet(xml.InnerXml);

                report.RegData(ds);
                report.Render();
                report.ExportDocument(StiExportFormat.Pdf, "38Report.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion " + ex.Message);
            }

            return "";

        }

        public DataSet ConvertXMLToDataSet(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);
                // Load the XmlTextReader from the stream
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        }// Use this function to get XML string from a dataset

        public StimulsoftUtility()
        {
            global::Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHn6T1QyRLNg9ob5/AoMlKpfD06YlnbaK+apLpkPGy58/hwEVP" +
                                            "JFLu2ahVXhoRuQ6rqqr2dmiE1sVk+HoFVWz15idNVym7+T9lWeQUbd8FI/gJCJVd9zEPTA3yfhJpZx1s2ZXumj8n0P" +
                                            "FAahfNUT8qlOCjmeZ2admzNVdRlTcH/uN3Ms51HIix2g7C0cuupRUJOYBM36vuEOSXp1B07rV6NwU0iACQHiUQ/Y4c" +
                                            "Gx2SVSiZdVGKY4hVgfWDeHCTr5MaqXWo6p6EOSVB0bM3Y421Tv2qitJ3Utj/zcYDVbW5nSwhahuygT3ZCY5iftNvzw" +
                                            "gwIEjS2LnGME3QghFEWnC04Vld/zxSQyxGcMyK7/03VkqfHlBN8jIVHEjFT0YQUhPAbiC2pfFKa6MIgJqvXTJDNQgn" +
                                            "6y8c9RwfwPdC6PJjL/9c0kEpaG198A2R0mVZNzjvXHpG/mEUIeWN2zmWJMJNm5fgySzlV9BLUwKlM1jpv4rQcf5MR/" +
                                            "/ZONmx6qqmjYcSASNmW/ICM72fwSsJE7F7chh1Q0VMkOe6sriXsdhkqC3lV5yTifwCK3JYM9i08XF1HXDMeNF6/tss" +
                                            "wdMaaCVQDGJJp3stA8KlSyAeLFvRo5uMFl/5vvCuK3lV275SRgStTvS4uAu2yWIkUMnxMey6mZ";
        }

    }
}
