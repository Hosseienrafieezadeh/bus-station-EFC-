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
    public class TiketEntitsMap : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.HasOne(_ => _.Passenger)
           .WithMany(_ => _.Tickets)
           .HasForeignKey(_ => _.PassengerId)
           .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(_ => _.BusChair)
    .WithOne(_ => _.Ticket)
    .HasForeignKey<Ticket>(_ => _.BusChirId)  
    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(_ => _.Bus)
                .WithMany(_ => _.Tickets)
                .HasForeignKey(_ => _.BusId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
