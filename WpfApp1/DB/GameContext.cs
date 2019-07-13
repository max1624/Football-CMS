using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CourseWork;
using System.Runtime.Serialization;
using System.IO;

namespace CourseWork
{
    public class GameContext
    {
        public GameContext() { }
        public void Serialize(List<Game> list)
        {
            NetDataContractSerializer formatter = new NetDataContractSerializer();

            using (FileStream fs = new FileStream("Games.xml", FileMode.Create))
            {
                formatter.Serialize(fs, list);
            }
        }
        public List<Game> Deserialize()
        {
            NetDataContractSerializer formatter = new NetDataContractSerializer();
            using (FileStream fs = new FileStream("Games.xml", FileMode.OpenOrCreate))
            {
                List<Game> deserilizedata;
                try
                {
                    deserilizedata = (List<Game>)formatter.Deserialize(fs);
                    return deserilizedata;
                }
                catch { }
                List<Game> deserilizedata2 = new List<Game>();
                return deserilizedata2;
            }
        }
    }
}
