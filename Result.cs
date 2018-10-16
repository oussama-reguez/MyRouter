using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myRouter
{


   public  class Result
    {
        private int columnNumber;
        private int lineNumber;
        private int length;
        private string value;
        private String regex;
        private string name;



        public String Name
        {
            get { return name; }
            set { this.name = value; }
        }


        public String Regex
        {
            get { return regex; }
            set { this.regex = value; }
        }

        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public int ColumnNumber
        {
            get { return columnNumber; }
            set { this.columnNumber = value; }
        }

        public int LineNumber
        {
            get { return lineNumber; }
            set { this.lineNumber = value; }
        }

        public int Length
        {
            get { return length; }
            set { this.length = value; }
        }
        

        public Result(int line , int column , string regex,int length)
        {
            LineNumber = line;
            columnNumber = column;
            this.regex = regex;
        }

        public Result()
        {

        }
    }
}
