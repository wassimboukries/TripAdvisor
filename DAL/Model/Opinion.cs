using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Opinion
    {
        public int id { get; set; }
        public string Content { get; set; }
        public string ClientID { get; set; }

        public Opinion(int id, string Content, string ClientID)
        {
            this.id = id;
            this.Content = Content;
            this.ClientID = ClientID;
        }
    }
}
