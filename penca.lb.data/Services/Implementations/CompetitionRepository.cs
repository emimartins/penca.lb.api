using System;
using Microsoft.EntityFrameworkCore;
using penca.lb.data.Context;
using penca.lb.data.Model;
using penca.lb.data.Repository;
using penca.lb.data.Repository.Interfaces;

namespace penca.lb.data.Services.Implementations
{
    public class CompetitionRepository : Repository<Competition>, ICompetitionRepository
    {
        //private readonly PencaContext context;
        public CompetitionRepository(PencaContext context) : base(context)
        {
        }
    }
}

