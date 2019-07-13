using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CourseWork;

namespace CourseWork
{
    public class Stadium
    {
        private int Count_of_places { get; set; }
        private int Place_price { get; set; }
        public Stadium() { }
        public Stadium (int Count_of_places, int Place_price)
        {
            this.Count_of_places = Count_of_places;
            this.Place_price = Place_price;
        }
        public string Show_stadium_info()
        {
            string show_stadium_info = String.Format("Count of places : {0}, Place price : {1}", Count_of_places, Place_price);
            return show_stadium_info;
        }
    }
}
