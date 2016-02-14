using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace GameBacklog.Models
{
    public class GamesModel
    {
        [Key]
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string Platform { get; set; }
        public Nullable<DateTime> DateCompleted { get; set; }
    }

    public class GamesDBContext : DbContext
    {
        public DbSet<GamesModel> Games { get; set; }
    }
}