using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsProphetAPI.Models
{
    public class Tournament
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Team> Teams { get; set; }
        public double PrizePoolUSD { get; set; }

        public Tournament()
        {
            Teams = new Collection<Team>();
        }
    }
}
