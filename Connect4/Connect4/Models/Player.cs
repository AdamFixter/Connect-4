using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Connect4.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TotalWins { get; set; }
        public int GamesPlayed { get; set; }

    }
}
