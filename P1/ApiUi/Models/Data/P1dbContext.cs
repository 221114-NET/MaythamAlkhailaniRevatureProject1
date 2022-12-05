using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiUi.Models.Data
{
    public class P1dbContext : DbContext
    {

        //Injects the P1dbContext DbService Solution into the controller so you can talk to our database.
        public P1dbContext(DbContextOptions options) : base(options)
        {
        }
            // Import from Models. And se the "database".
        public DbSet<ReimbursementList> ReimbursementLists { get; set; }



    }
}