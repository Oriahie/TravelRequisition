using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TravelRequisition.Core.Entities;

namespace TravelRequisition.Core.EFContext
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options)
        : base(options)
        {

        }

        public DbSet<TravelRequest> TravelRequest { get; set; }
    }
}
