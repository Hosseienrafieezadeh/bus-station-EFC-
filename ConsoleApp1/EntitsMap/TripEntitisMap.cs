using ConsoleApp1.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.EntitsMap
{
    class TripEntitisMap: IEntityTypeConfiguration<Trip>
    {


        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.HasMany(_=> _.Buses)
                   .WithOne(_ => _.Trip)
                   .HasForeignKey(_ => _.TripId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
