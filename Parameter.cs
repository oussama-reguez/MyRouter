using System;
using System.Collections.Generic;

namespace myRouter
{

    public class Parameter
    {

        public Parameter(string name , string value)
        {
            this.name = name;
            this.value = value;
        }

      private string name;
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

      private string value;

        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }

     public Parameter()
        {

        }
        public static implicit operator List<object>(Parameter v)
        {
            throw new NotImplementedException();
        }
    }
}