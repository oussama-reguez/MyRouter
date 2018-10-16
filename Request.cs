using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myRouter
{

   public class Request
    {
       private  string type;
        private  List<Result> results;



        public List<Result> Results
        {
            get { return results; }
            set { results = value; }

        }


        public string Type
        {
            get { return type; }
            set { type = value; }

        }

        List<Parameter> parameters;

        public List<Parameter> Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }


        private  string url;

        public String Url
        {
            get { return url; }
            set { url = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Request() { }
    }
}
