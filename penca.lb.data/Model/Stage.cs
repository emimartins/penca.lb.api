using System;
using System.Collections.Generic;

namespace penca.lb.data.Model
{
    public class Stage : Entity
    {
        public long CompetitionId { get; set; }
        public Competition Competition { get; set; }
        public string Description { get; set; }
        public IEnumerable<Round> Rounds { get; set; }

        public Stage()
        {
        }
    }
}

