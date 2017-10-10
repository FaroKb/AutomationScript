using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MindTouch.Dream;
using MindTouch.Xml;
using System.Xml.Linq;

namespace MainScript
{
    class GenerateArticleList
    {

        public static ArrayList RetrieveArticleList(int date, Plug language)
        {
            ArrayList articleList = new ArrayList();

            Console.WriteLine("Retrieving article paths from Software section...");
            articleList.AddRange(ParseXmlAddFromDate(20170901, language, "4848"));
            Console.WriteLine("Retrieved article paths from Software complete.");
            Console.WriteLine("Retrieving article paths from Hardware section...");
            articleList.AddRange(ParseXmlAddFromDate(20170901, language, "4806"));
            Console.WriteLine("Retrieved article paths from Hardware complete.");
            Console.WriteLine("Retrieveing article paths from Essentials section...");
            articleList.AddRange(ParseXmlAddFromDate(20170901, language, "20037"));
            Console.WriteLine("Retrieved article paths from Essentials complete.");
            Console.WriteLine("Total new articles retrieved: " + articleList.Count);
            return articleList;
        }
        public static ArrayList DynamicParseXmlAddFromDate(int date, IEnumerable<XElement> page)
        {
            ArrayList list = new ArrayList();
            int pagesCount = page.Count();
   
            //A loop will be performed on the amount of pages there are below this level
            for (int i = 0; i < pagesCount; i++)
            {

                if (dateConverter(page.ElementAt(i).Element("date.created").Value.ToString()) > date)
                {    
                    list.Add(page.ElementAt(i).Element("path").Value.ToString());
                }

                if (containsSubpages(page.ElementAt(i)))
                {
                   list.AddRange(DynamicParseXmlAddFromDate(date, page.ElementAt(i).Element("subpages").Elements()));
                }
                else
                {
                    return list;
                }
            }
            return list;
        }

        public static ArrayList ParseXmlAddFromDate(int date, Plug language, string pageId)
        {
            ArrayList articleList = new ArrayList();

            XElement xmlparse = XElement.Parse((language.At("pages", pageId, "tree").With("format", "xml").Get().ToText()));
           
            articleList.AddRange(DynamicParseXmlAddFromDate(date, xmlparse.Element("page").Element("subpages").Elements()));

            return articleList;
            
        }

        public static Boolean containsSubpages(XElement page)
        {
            XElement storage;

            try
            {
                storage = page.Element("subpages");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int dateConverter(string date)
        {
            int dateInt = (Convert.ToInt32(date.Replace("-", "").Remove(8)));

            return dateInt;

        }

    }
}
