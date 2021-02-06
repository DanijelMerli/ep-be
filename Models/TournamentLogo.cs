using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsProphetAPI.Models
{
    public class TournamentLogo : Photo
    {
        public Tournament Tournament { get; set; }
    }
}
