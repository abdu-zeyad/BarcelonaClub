using System.Collections.Generic;

namespace Barcelona.Models
{
    public class Sport
    {
        public int Id { get; set; }
        public string SportName { get; set; }
        public List<Player> Players { get; set; }

    }
}
