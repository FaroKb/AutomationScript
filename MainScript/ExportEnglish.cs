using MindTouch.Dream;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MainScript
{
    class Export
    {
        public static async Task<string> ExportAsync(ArrayList list, Plug language)
        {
            
            String id = "";
            try
            {
                DreamMessage ms = language.WithHeader("X-Deki-Token", APIKeys.GenerateTokenEn()).At("site").At("jobs").At("export").Post(XmlGenerator.CreateExportDoc("Jamal.Roberts@faro.com", pathsToArray(list)));
                XElement job = XElement.Parse(ms.ToText().ToString());
                id = job.Attribute("id").Value;
            }
            catch(DreamResponseException ex)
            {

                Console.WriteLine(ex.ToString());

            }

            JobStatus js = new JobStatus(id, language);

            while (js.status != "COMPLETED")
            {
                js = new JobStatus(id, language);
                Console.WriteLine(js.status.ToString());
                await Task.Delay(1000);
            }
            Console.WriteLine("Complete");
            return "test";

        }
        private static String[,] pathsToArray(ArrayList list)
        {

            String[,] paths = new String[list.Count, 2];
            
            for (int i = 0; i < list.Count; i++)
            {

                paths[i, 0] = list[i].ToString();

              
                paths[i, 1] = "true";
                

            }

            return paths;

        }

    }
}
