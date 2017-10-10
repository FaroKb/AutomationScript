using MindTouch.Dream;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainScript
{
    class Program
    {

        private static Plug[] LanguagePlugs = new Plug[] {

            Plug.New("https://knowledge.faro.com/@api/deki"),
            Plug.New("https://de-knowledge.faro.com/@api/deki"),
            Plug.New("https://es-knowledge.faro.com/@api/deki"),
            Plug.New("https://fr-knowledge.faro.com/@api/deki"),
            Plug.New("https://it-knowledge.faro.com/@api/deki"),
            Plug.New("https://ja-knowledge.faro.com/@api/deki"),
            Plug.New("https://pt-knowledge.faro.com/@api/deki"),
            Plug.New("https://zh-knowledge.faro.com/@api/deki"),
            Plug.New("https://translate-faro.mindtouch.us/@api/deki")
            };

        static void Main(string[] args)
        {
            MainAsync().Wait();
            Console.ReadLine();

            return;
        }
        static async Task MainAsync()
        {
           

            AuthenticatePlugs();
            ArrayList articleList = new ArrayList();
            articleList = GenerateArticleList.RetrieveArticleList(3, LanguagePlugs[0]);
            await Export.ExportAsync(articleList, LanguagePlugs[0]);

            return;
        }

        //Authenticates language sites with FaroImport Credentials
        private static void AuthenticatePlugs()
        {
            Console.WriteLine("Autheniticating Language sites with FAROImport Credentials...");
            for (int i = 0; i < 9; i++)
            {

                try
                {
                    DreamMessage msg = LanguagePlugs[i].At("users", "authenticate").WithCredentials("JamalR", "Donecom.8292").Get();
                }
                catch
                {
                    Console.WriteLine("Authentication has failed, please check that login credentials for FaroImport are valid.");
                    return;
                }

            }
            Console.WriteLine("Authentication is complete");

        }
    }
}
