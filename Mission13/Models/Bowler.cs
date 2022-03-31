//Bowler Model
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Mission13.Models
{
    public class Bowler
    {
        [Key]
        [Required]
        public int BowlerID { get; set; }

        public string BowlerLastName { get; set; }

        public string BowlerFirstName { get; set; }

        [MaxLength(1)]
        public string BowlerMiddleInit { get; set; }

        public string BowlerAddress { get; set; }

        public string BowlerCity { get; set; }

        [MaxLength(2)]
        public string BowlerState { get; set; }

        public string BowlerZip { get; set; }

        public string BowlerPhoneNumber { get; set; }

        //Build foreign key relationship
        public int TeamID { get; set; }
        public Team Team { get; set; }
    }
}

//Read-Only variables {get;}
