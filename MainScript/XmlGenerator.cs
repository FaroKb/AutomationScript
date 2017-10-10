using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MainScript
{
    class XmlGenerator
    {
        public static MindTouch.Xml.XDoc CreateExportDoc(String email, String[,] paths)
        {
            XElement point = new XElement("pages");

            XDocument exp = new XDocument(new XElement("job",
                                                                   new XElement("notification",
                                                                                                  new XElement("email", email)),
                                                                  point));

            for (int i = 0; i < paths.GetLength(0); i++)
            {
                point.Add(new XElement("page", new XAttribute("includesubpages", paths[i, 1])
                                                                , new XElement("path", paths[i, 0])));

            }

            MindTouch.Xml.XDoc xml = new MindTouch.Xml.XDoc(ToXmlDocument(exp));

            return xml;

        }

        public static MindTouch.Xml.XDoc CreateImportDoc(String email, String archiveUrl)
        {

            archiveUrl = System.Web.HttpUtility.HtmlDecode(archiveUrl);

            XDocument imp = new XDocument(new XElement("job",
                                                                      new XElement("notification",
                                                                                                    new XElement("email", email)),
                                                                      new XElement("archive",
                                                                                                    new XElement("url", archiveUrl))));
            MindTouch.Xml.XDoc xml = new MindTouch.Xml.XDoc(ToXmlDocument(imp));

            return xml;
        }

        public static XmlDocument ToXmlDocument(XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

    }
}
