﻿// <auto-generated />
using API_EF_NET7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_EF_NET7.Migrations
{
    [DbContext(typeof(WCDbContext))]
    [Migration("20231012102005_InitialDNB")]
    partial class InitialDNB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_EF_NET7.Models.Confederation", b =>
                {
                    b.Property<int>("ConfederationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ConfederationId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConfederationId"));

                    b.Property<string>("ConfederationName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .HasColumnName("ConfederationName")
                        .IsFixedLength();

                    b.HasKey("ConfederationId");

                    b.ToTable("Confederation", (string)null);
                });

            modelBuilder.Entity("API_EF_NET7.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TeamId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"));

                    b.Property<int>("ConfederationId")
                        .HasColumnType("int")
                        .HasColumnName("ConfederationId");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nchar(255)")
                        .HasColumnName("CountryName")
                        .IsFixedLength();

                    b.HasKey("TeamId");

                    b.HasIndex("ConfederationId");

                    b.ToTable("Team", (string)null);
                });

            modelBuilder.Entity("API_EF_NET7.Models.Team", b =>
                {
                    b.HasOne("API_EF_NET7.Models.Confederation", "Confederation")
                        .WithMany()
                        .HasForeignKey("ConfederationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Confederation");
                });
#pragma warning restore 612, 618
        }
    }
}
