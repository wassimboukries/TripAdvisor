using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Opinion
    {
        public int id { get; set; }
        public string Content { get; set; }
        public int ClientID { get; set; }

        public Opinion()
        {

        }

        public Opinion(int id, string Content, int ClientID)
        {
            this.id = id;
            this.Content = Content;
            this.ClientID = ClientID;
        }
    }
}
