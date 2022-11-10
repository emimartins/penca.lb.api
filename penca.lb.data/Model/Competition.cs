using System;
using System.Collections.Generic;

namespace penca.lb.data.Model
{
    public class Competition : Entity
    {
        public string Name { get; set; }
        public IEnumerable<Stage> Stages { get; set; }
        public IEnumerable<CompetitionTeam> CompetitionTeams { get; set; }

        public Competition()
        {
        }

    }
}

