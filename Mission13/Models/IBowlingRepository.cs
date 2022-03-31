//Repository Method
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Mission13.Models
{
    public interface IBowlingRepository
    {
        IQueryable<Bowler> Bowlers { get; }

        IQueryable<Team> Teams { get; }

        //updated repository for creating, updating, and deleting bowlers
        public void UpdateBowler(Bowler b);
        public void CreateBowler(Bowler b);
        public void DeleteBowler(Bowler b);
    }
}

//REMEMBER! Interface is a template.
//Naming convention -- When we put an "I" before the variable name, that means that we are using an interface 