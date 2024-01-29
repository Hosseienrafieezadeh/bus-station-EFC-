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
    public class BusChairMap : IEntityTypeConfiguration<BusChair>
    {
        public void Configure(EntityTypeBuilder<BusChair> builder)
        {
            builder.HasKey(_=> _.Id);
            builder.Property(_ => _.Number).IsRequired();

            builder.HasOne(_=> _.Bus)
                   .WithMany(_ => _.BusChairs)
                   .HasForeignKey(_ => _.BusId);
            
            builder.HasOne(_ => _.Ticket).WithOne(_ => _.BusChair).HasForeignKey<BusChair>(_ => _.TicketId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(_ => _.Reservation).WithOne(_ => _.BusChair).HasForeignKey<BusChair>(_ => _.ReservId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
