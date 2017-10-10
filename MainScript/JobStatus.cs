using MindTouch.Dream;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MainScript
{
    class JobStatus
    {
        public String response { get; set; }
        public int exportStatus { get; set; }
        public String jobId { get; set; }
        public String type { get; set; }
        public String status { get; set; }
        public String dateSubmitted { get; set; }
        public String lastModified { get; set; }
        public JobStatus(String id, Plug p)
        {
            jobId = id;
            
            XElement e = retrieveXml(p);

            if (e != null)
            {
                parseOutput(e);
                exportStatus = 0;
            }
            else
            {
                exportStatus = 1;
            }
        }
        //Retrieve the xml for the check status call
        public XElement retrieveXml(Plug language)
        {

            DreamMessage msg;

            try
            {
                msg = language.WithHeader("X-Deki-Token", APIKeys.GenerateTokenEn()).At("site", "jobs", jobId, "status").Get();
               
            }
            catch (DreamResponseException ex)
            {
                response = ex.Response.ToText().ToString();
                return null;
            }
            XElement output = XElement.Parse(msg.ToText().ToString());
            return output;

        }
        //This function parses the xml output from the call to check satus and sets the values accordingly
        public void parseOutput(XElement output)
        {

            //set the type 
            type = (output.Attribute("type").Value.ToString());

            //set the status
            status = (output.Attribute("status").Value.ToString());

            //To retrieve date submitted and date last modified and data we must retrieve the descendents
            IEnumerable<XElement> descendents = output.Descendants();

            //Set the submitted date
            dateSubmitted = descendents.ElementAt(0).Value.ToString();

            //Set the last modified date
            lastModified = descendents.ElementAt(1).Value.ToString();

            return;
        }
    }
}
