using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CourseWork;
using System.Runtime.Serialization;
using System.IO;

namespace CourseWork
{
    public class StadiumContext
    {
        public StadiumContext() { }
        public void Serialize(List<Stadium> list)
        {
            NetDataContractSerializer formatter = new NetDataContractSerializer();

            using (FileStream fs = new FileStream("Stadiums.xml", FileMode.Create))
            {
                formatter.Serialize(fs, list);
            }
        }
        public List<Stadium> Deserialize()
        {
            NetDataContractSerializer formatter = new NetDataContractSerializer();
            using (FileStream fs = new FileStream("Stadiums.xml", FileMode.OpenOrCreate))
            {
                List<Stadium> deserilizedata;
                try
                {
                    deserilizedata = (List<Stadium>)formatter.Deserialize(fs);
                    return deserilizedata;
                }
                catch { }
                List<Stadium> deserilizedata2 = new List<Stadium>();
                return deserilizedata2;
            }
        }
    }
}
