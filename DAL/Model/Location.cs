using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Location
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Opinion> OpinionList { get; set; }

        public Location(int id, string name)
        {
            this.id = id;
            this.name = name;
            OpinionList = new List<Opinion>();
        }

        public void addOpinion(Opinion newOpinion)
        {
            OpinionList.Add(newOpinion);
        }
    }
}
