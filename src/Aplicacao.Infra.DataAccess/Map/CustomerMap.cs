﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Aplicacao.Domain.Model;
using System;

namespace Aplicacao.Infra.DataAccess.Map
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Cliente");

            builder
                .HasKey(pk => pk.Id)
                .HasName("ClienteId");

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(n => n.Name)
                .HasColumnName("nomeCompleto")
                .HasMaxLength(300)
                .HasColumnType<string>("varchar(300)")
                .IsRequired();

            builder
                .Property(n => n.BirthDate)
                .HasColumnName("dataNascimento")
                .HasMaxLength(10)
                .HasColumnType<DateTime>("datetime")
                .IsRequired();

            builder
                .Property(n => n.Email)
                .HasColumnName("email")
                .HasMaxLength(100)
                .HasColumnType<string>("varchar(100)")
                .IsRequired();

            builder
                .Property(n => n.RegistrationDate)
                .HasColumnName("dataCadastro")
                .HasMaxLength(30)
                .HasColumnType<DateTime>("datetime")
                .IsRequired();

            builder
               .HasMany(c => c.Address)
               .WithOne(c => c.Customer)
               .OnDelete(DeleteBehavior.Cascade);

            //builder
            //    .HasMany(a => a.Address).WithOne("Customers").HasForeignKey("CustomerId");

            //builder
            //    .Property(n => n.Name)
            //    .HasColumnName("nome")
            //    .HasMaxLength(300)
            //    .HasColumnType<string>("varchar(300)")
            //    .IsRequired();

            //builder
            //    .Property(n => n.RegistrationDate)
            //    .HasColumnName("cadastro")
            //    .HasDefaultValue(DateTime.Now)
            //    .HasColumnType<DateTime>("datetime")
            //    .IsRequired();

            //builder
            //    .Property(n => n.Document)
            //    .HasColumnName("documento")
            //    .HasMaxLength(300)
            //    .HasColumnType<string>("varchar(300)")
            //    .IsRequired();

            //builder
            //    .HasOne(e => e.Address);
            //        .HasForeignKey(e => e.FKCountry);

            //builder
            //    .Ignore(n => n.Address);
        }
    }
}
