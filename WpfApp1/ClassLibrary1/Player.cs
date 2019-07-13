using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CourseWork
{
    
    public class Player
    {
        
        public int Id { get; set; }
        private string First_name { get; set; }
        private string Second_name { get; set; }
        private string Birth_date { get; set; }
        private string Player_status { get; set; }
        private string Health_status { get; set; }
        private string Salary { get; set; }
        public Player() { }
        public Player(string First_name, string Second_name, string Birth_date,string Player_status, string Health_status, string Salary)
        {
            this.First_name = First_name;
            this.Second_name = Second_name;
            this.Birth_date = Birth_date;
            this.Player_status = Player_status;
            this.Health_status = Health_status;
            this.Salary = Salary;
        }
        public string Show_player_info()
        {
            string show_player_info = string.Format("First name : {0}, Second name: {1}, Birth date: {2}, Player status: {3}, Health status : {4}, Salary : {5}", First_name, Second_name, Birth_date, Player_status, Health_status, Salary);
            return show_player_info;
        }

    }
}
