using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace CourseWork
{
    [DataContract]
    public class Player
    {
        [DataMember]
        private string First_name { get; set; }
        [DataMember]
        private string Second_name { get; set; }
        [DataMember]
        private string Birth_date { get; set; }
        [DataMember]
        private string Player_status { get; set; }
        [DataMember]
        private string Health_status { get; set; }
        [DataMember]
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
        public string GetFirstName()
        {
            return First_name;
        }
        public void SetFirstName(string fisrt_name)
        {
            First_name = fisrt_name;
        }
        public string GetSecondName()
        {
            return Second_name;
        }
        public void SetSecondName(string second_name)
        {
            Second_name = second_name;
        }
        public string GetBirthDate()
        {
            return Birth_date;
        }
        public void SetBirthDate(string birth_date)
        {
            Birth_date = birth_date;
        }
        public string GetPlayerStatus()
        {
            return Player_status;
        }
        public void SetPlayerStatus(string player_status)
        {
            Player_status = player_status;
        }
        public string GetHealthStatus()
        {
            return Health_status;
        }
        public void SetHealthStatus(string health_status)
        {
            Health_status = health_status;
        }
        public string GetSalary()
        {
            return Salary;
        }
        public void SetSalary(string salary)
        {
            Salary = salary;
        }
        public string Show_player_info()
        {
            string show_player_info = string.Format("First name : {0},\n Second name: {1},\n Birth date: {2},\n Player status: {3},\n Health status : {4},\n Salary : {5}\n", First_name, Second_name, Birth_date, Player_status, Health_status, Salary);
            return show_player_info;
        }

    }
}
