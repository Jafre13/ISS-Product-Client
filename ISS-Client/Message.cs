using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISS_Client
{
    class Message
    {
        public String Text { get; set; }

        //Work, Personal, Spam, Urgent
        public List<Boolean> Classes{ get; set; }
        public DateTime Created { get; set; }
        public DateTime Scheduled { get; set; }

        public Message()
        {
            this.Text = "";
            this.Classes = new List<Boolean>();
            this.Created = DateTime.Now;
            

        }
        public Message(String text, List<Boolean> classes)
        {
            this.Text = text;
            this.Classes = classes;
            this.Created = DateTime.Now;
        }

        public string classestostring()
        {
            string t = String.Join(", ", Classes);
            return t;

        }
    }
}
