using ConsoleApp1.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.EntitsMap
{
    public class BusEntitsMaps : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_=> _.Price).HasColumnType("decimal(18,2)");
            builder.Property(_ => _.CanBuy).IsRequired();
            builder.Property(_=> _.CanReserve).IsRequired();
            
            
            builder.HasOne(_=> _.Trip)
                .WithMany(_ => _.Buses)
                .HasForeignKey(_ => _.TripId)
                .OnDelete(DeleteBehavior.Cascade);
            

            

            builder.HasMany(_ => _.BusChairs)
                   .WithOne()
                   .HasForeignKey(_ => _.BusId);

            

            builder.HasMany(_ => _.Tickets)
                   .WithOne(_ => _.Bus)
                   .HasForeignKey(_ => _.Id);

            builder.HasMany(_ => _.Reservations)
                   .WithOne(_ => _.Bus)
                   .HasForeignKey(_ => _.Id);

        }
    }
}
