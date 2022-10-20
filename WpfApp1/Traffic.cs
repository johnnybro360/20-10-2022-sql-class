using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Traffic
    {
        public int ID { get; set; }
        public string PlateName { get; set; }
        public int Speed { get; set; }
        public int Limit { get; set; }

        public Traffic(int id, string plate, int speed, int limit)
        {
            ID = id;
            PlateName = plate;
            Speed = speed;
            Limit = limit;
        }
        public override string ToString()
        {
            return $"{ID} // {PlateName} // {Speed} // {Limit}";

        }
    }

  
}
