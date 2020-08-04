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
using IDAutomation.Windows.Forms.PDF417Barcode;
using System.Drawing;


namespace VDStimulsoftReport
{
    public class StimulsoftUtility 
    {
        public string getStimulsoftReportBase64(string path, XmlDocument xml)
        {
            
            var report = StiReport.CreateNewReport();

            try
            {

                string codigoBarra = "asdddddddddddddddddddddddddddddddddddddddddddasdastrf345435345345435";

                using (var pdf417Bar = new IDAutomation.Windows.Forms.PDF417Barcode.PDF417Barcode())
                {
                    pdf417Bar.DataToEncode = codigoBarra;
                    pdf417Bar.PDFMode = IDAutomation.Windows.Forms.PDF417Barcode.PDF417Barcode.PDF417Modes.Binary;
                    pdf417Bar.PDFColumns = 12;
                    pdf417Bar.Resolution = IDAutomation.Windows.Forms.PDF417Barcode.PDF417Barcode.Resolutions.Custom;
                    pdf417Bar.ResolutionCustomDPI = 120;
                    pdf417Bar.Height = 160;
                    pdf417Bar.Width = 190;
                    pdf417Bar.XtoYRatio = 4;
                    pdf417Bar.PDFErrorCorrectionLevel = 1;
                    pdf417Bar.RefreshImage();
                    MemoryStream myMemoryStream = new MemoryStream();
                    pdf417Bar.Picture.Save(myMemoryStream, System.Drawing.Imaging.ImageFormat.Png);

                    report.Load(path);
                    report.Dictionary.Databases.Clear();
                    var ds = ConvertXMLToDataSet(xml.InnerXml);
                    report.RegData(ds);

                    Image imagenTimbre = System.Drawing.Image.FromStream(myMemoryStream);
                    try
                    {
                        report.Dictionary.Variables["codigoBarra"].ValueObject = imagenTimbre;
                    }
                    catch { }

                }
                
                
                
                // report.Load("C:\\ReportTest.mrt");
               

   
                report.Dictionary.Variables["Variabletest"].ValueObject = "Envio Desde c#";
                report.Render();
                report.ExportDocument(StiExportFormat.Pdf, "40Report.pdf");

                MemoryStream oStream = new MemoryStream();
                report.ExportDocument(StiExportFormat.Pdf, oStream);
                byte[] b1 = new byte[oStream.Length];
                oStream.Seek(0, System.IO.SeekOrigin.Begin);
                oStream.Read(b1, 0, Convert.ToInt32(oStream.Length));



                return Convert.ToBase64String(b1);
     
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
