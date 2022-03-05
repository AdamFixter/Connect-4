using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Connect4.Models
{
    public class Game
    {
        public int ID { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public DateTime Time { get; set; }
    }
}
