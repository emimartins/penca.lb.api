using System;
using System.Collections.Generic;

namespace penca.lb.data.Model
{
    public class Round : Entity
    {
        public long StageId { get; set; }
        public Stage Stage { get; set; }
        public IEnumerable<Match> Matches;
        public Round()
        {
        }
    }
}

