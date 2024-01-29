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
    public class PassengerEntitiesMap : IEntityTypeConfiguration<Passenger>
    {
        
        
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_=> _.FullName).IsRequired().HasMaxLength(50);
           
            builder.Property(_ => _.NationalCode).IsRequired().HasMaxLength(10).IsFixedLength();
            builder.Property(_ => _.PhoneNumber).IsRequired().HasMaxLength(12).IsFixedLength();

            

            builder.HasMany(_ => _.Tickets).WithOne(_=>_.Passenger).HasForeignKey(_=>_.Id);
            builder.HasMany(_ => _.Reservation)
           .WithOne(_ => _.Passenger)
           .HasForeignKey(_ => _.Id);


        }
    }
}