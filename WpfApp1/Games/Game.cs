using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CourseWork;
using System.Runtime.Serialization;

namespace CourseWork
{
    [DataContract]
    public class Game
    {
        
        
        [DataMember]
        private List<Player> players_list = new List<Player>();
        [DataMember]
        private int Day { get; set; }
        [DataMember]
        private int Month { get; set; }
        [DataMember]
        private int Year { get; set; }
        [DataMember]
        private string Game_date { get; set; }
        [DataMember]
        private string Game_place { get; set; }
        [DataMember]
        private string Count_of_visitors { get; set; }
        [DataMember]
        private short Game_result { get; set; }

        public Game() { }
        public Game (List<Player> players_list, int Day, int Month, int Year, string Game_place, string Count_of_visitors)
        {
            this.players_list = players_list;
            this.Day = Day;
            this.Month = Month;
            this.Year = Year;
            this.Game_place = Game_place;
            this.Count_of_visitors = Count_of_visitors;
            this.Game_date = Day + "." + Month + "." + Year;
        }
        public void SetResult(short result)
        {
            Game_result = result;
        }
        public short GetResult()
        {
            return Game_result;
        }
        public void SetGameDate(int day, int month, int year)
        {
            Game_date = day + "." + month + "." + year;
        }
        public string GetCoutOfVisitors()
        {
            return Count_of_visitors;
        }
        public void SetCountOfVisitors(string CountOfVisitors)
        {
            Count_of_visitors = CountOfVisitors;
        }
        public string GetPlace()
        {
            return Game_place;
        }
        public void SetPlace(string Place)
        {
            Game_place = Place;
        }
        public List<Player> GetPlayers()
        {
            return players_list;
        }
        public void SetPlayers(List<Player> playerlist)
        {
            players_list = playerlist;
        }
        public int GetDay()
        {
            return Day;
        }
        public void SetDay(int day)
        {
            Day = day;
        }
        public int GetMonth()
        {
            return Month;
        }
        public void SetMonth(int month)
        {
            Month = month;
        }
        public int GetYear()
        {
            return Year;
        }
        public void SetYear(int year)
        {
            Year = year;
        }
        public string GetGameDate()
        {
            return Game_date;
        }
        public string Show_game_info()
        {
            string players = "";
            foreach (var player in players_list)
            {
                players += player.GetFirstName()+ " " + player.GetSecondName() + ", \n";
            }
            string Message = String.Format("Дата проведення гри: {0},\nГравці: {1}Місце проведення: {2},\nКількість глядачів: {3}", Game_date, players, Game_place, Count_of_visitors);
            return Message;
        }
    }
}
