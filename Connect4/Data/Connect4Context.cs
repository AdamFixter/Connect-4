using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Connect4.Models
{
    public class Connect4Context : DbContext
    {
        public Connect4Context (DbContextOptions<Connect4Context> options)
            : base(options)
        {
        }

        public DbSet<Game> Game { get; set; }
    }
}
