using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUi.Models
{
    public class ReimbursementList
    {
        [Key]
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Name { get; set;}
        public string Email { get; set;}
        public string TimeOff { get; set;}
        public long BusinessTravelCost { get; set;}

        

    }
}