using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISS_Client
{
    class query
    {
        public string TextMessage { get; set; }

        public query(string message)
        {
            this.TextMessage = message; 
        }
    }
}
