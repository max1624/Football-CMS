using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CourseWork
{
    [DataContract]
    public class Stadium
    {
        [DataMember]
        private string Name { get; set; }
        [DataMember]
        private string  Count_of_places { get; set; }
        [DataMember]
        private string Place_price { get; set; }

        
        public Stadium() { }
        public Stadium (string Name, string Count_of_places, string Place_price)
        {
            this.Name = Name;
            this.Count_of_places = Count_of_places;
            this.Place_price = Place_price;
        }
        public string GetName()
        {
            return Name;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public string GetCountOfPlaces()
        {
            return Count_of_places;
        }
        public void SetCountOfPlaces(string countOfPlaces)
        {
            Count_of_places = countOfPlaces;
        }
        public string GetPrice()
        {
            return Place_price;
        }
        public void SetPrice(string Price)
        {
            Place_price = Price;
        }
        public string Show_stadium_info()
        {
            string show_stadium_info = String.Format("Name : {0},\n Count of places : {1},\n Place price : {2}\n",Name, Count_of_places, Place_price);
            return show_stadium_info;
        }
    }
}
