using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EsportsProphetAPI.Models
{
    public class Team
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public int LogoId { get; private set; }
        public TeamLogo Logo { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }

        public Team()
        {
            Tournaments = new Collection<Tournament>();
        }
    }
}