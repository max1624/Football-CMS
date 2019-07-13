using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using CourseWork;
using System.IO;
using System.Runtime.Serialization;

namespace CourseWork
{

    public class PlayerContext
    {
        public PlayerContext() { }
        public void Serialize(List<Player> list)
        {
            NetDataContractSerializer formatter = new NetDataContractSerializer();
            
            using (FileStream fs = new FileStream("Players.xml", FileMode.Create))
            {
                formatter.Serialize(fs, list);
            }
        }
        public List<Player> Deserialize()
        {
            NetDataContractSerializer formatter = new NetDataContractSerializer();
            using (FileStream fs = new FileStream("Players.xml", FileMode.OpenOrCreate))
            { 
                List<Player> deserilizedata;
                try
                {
                    deserilizedata = (List<Player>)formatter.Deserialize(fs);
                    return deserilizedata;
                }
                catch { }
                    List <Player> deserilizedata2 = new List<Player>();
                    return deserilizedata2;
            }
        }
    }
}
