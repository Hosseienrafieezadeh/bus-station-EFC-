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
    public class ReservationEntitisMap : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(_=> _.Id);

            
   
            builder.Property(_ => _.ReservationDate)
                   .IsRequired();
            builder.HasOne(_ => _.Passenger)
          .WithMany(_ => _.Reservation)
          .HasForeignKey(_ => _.PassengerId)
          .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(_ => _.BusChair)
    .WithOne(_ => _.Reservation)
    .HasForeignKey<Reservation>(_ => _.BusChirId)
    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(_ => _.Bus)
                .WithMany(_ => _.Reservations)
                .HasForeignKey(_ => _.BusId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
