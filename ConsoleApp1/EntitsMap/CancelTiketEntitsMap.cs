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
    public class CancelTiketEntitsMap : IEntityTypeConfiguration<CancelTicket>
    {
        public void Configure(EntityTypeBuilder<CancelTicket> builder)
        {
            builder.HasKey(_ => _.Id); 
            builder.Property(_ => _.CancellationDate).IsRequired();
            builder.Property(_=> _.CancellationReason).HasMaxLength(1000);


            builder.HasOne(_ => _.Reservation)
       .WithOne()
       .HasForeignKey<CancelTicket>(_ => _.ReservId)
       .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(_ => _.Ticket)
       .WithOne()
       .HasForeignKey<CancelTicket>(_ => _.ticketId)
       .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
