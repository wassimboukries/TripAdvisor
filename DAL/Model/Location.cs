
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
        public string linkPicture { get; set; }
        public List<Opinion> OpinionList { get; set; }

        public Location()
        {
            OpinionList = new List<Opinion>();
        }

        public void addOpinion(Opinion newOpinion)
        {
            OpinionList.Add(newOpinion);
        }
    }
}