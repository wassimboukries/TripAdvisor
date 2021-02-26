
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
        public List<Opinion> opinionList { get; set; }

        public Location()
        {

            opinionList = new List<Opinion>();
            for(int i= 0; i < 5; i++)
            {
                addOpinion(new Opinion(i, "Pas content", 4533 + i));
            }
        }

        public void addOpinion(Opinion newOpinion)
        {
            opinionList.Add(newOpinion);
        }
    }
}