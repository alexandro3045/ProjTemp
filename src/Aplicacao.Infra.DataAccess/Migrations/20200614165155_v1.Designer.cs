﻿// <auto-generated />
using System;
using Aplicacao.Infra.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aplicacao.Infra.DataAccess.Migrations
{
    [DbContext(typeof(AplicacaoContext))]
    [Migration("20200614165155_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aplicacao.Domain.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("cidade")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Complement")
                        .HasColumnName("complemento")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnName("pais")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnName("bairro")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnName("numero")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(300);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnName("estado")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnName("rua")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnName("cep")
                        .HasColumnType("varchar(8)")
                        .HasMaxLength(300);

                    b.HasKey("Id")
                        .HasName("EnderecoId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Aplicacao.Domain.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("dataNascimento")
                        .HasColumnType("datetime")
                        .HasMaxLength(10);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("nomeCompleto")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnName("dataCadastro")
                        .HasColumnType("datetime")
                        .HasMaxLength(30);

                    b.HasKey("Id")
                        .HasName("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Aplicacao.Domain.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("CompraId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("Aplicacao.Domain.Model.OrderItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("CompraItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("CompraItem");
                });

            modelBuilder.Entity("Aplicacao.Domain.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("descricao")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<decimal>("Price")
                        .HasColumnName("preco")
                        .HasColumnType("decimal(10,2)")
                        .HasMaxLength(300);

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnName("sku")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<double>("Weight")
                        .HasColumnName("peso")
                        .HasColumnType("float")
                        .HasMaxLength(300);

                    b.HasKey("Id")
                        .HasName("ProdutoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Aplicacao.Domain.Model.Address", b =>
                {
                    b.HasOne("Aplicacao.Domain.Model.Customer", "Customer")
                        .WithMany("Address")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aplicacao.Domain.Model.Order", b =>
                {
                    b.HasOne("Aplicacao.Domain.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Aplicacao.Domain.Model.OrderItems", b =>
                {
                    b.HasOne("Aplicacao.Domain.Model.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aplicacao.Domain.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
