using HospitalManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Infrastructure.Data.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(d => d.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(d => d.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(d => d.Specialization)
                .IsRequired();

            builder.HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.OwnsOne(d => d.Address, address =>
            {
                address.Property(a => a.Street)
                .HasColumnName("Street")
                .HasMaxLength(200)
                .IsRequired();

                address.Property(a => a.City)
                .HasColumnName("City")
                .HasMaxLength(100)
                .IsRequired();

                address.Property(a => a.Governorate)
                .HasColumnName("Governorate")
                .HasMaxLength(100)
                .IsRequired();

                address.Property(a => a.Country)
                .HasColumnName("Country")
                .HasMaxLength(100)
                .IsRequired();

                address.Property(a => a.PostalCode)
                .HasColumnName("PostalCode")
                .HasMaxLength(20)
                .IsRequired();
            });


            builder.OwnsOne(d => d.WorkingHours, workingHours =>
            {
                workingHours.Property(w => w.StartTime)
                .HasColumnName("WorkingHoursStartTime")
                .IsRequired();

                workingHours.Property(w => w.EndTime)
               .HasColumnName("WorkingHoursEndTime")
               .IsRequired();
            });

        }
    }
}
