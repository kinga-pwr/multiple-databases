﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultipleDatabases.DAL.ProviderContexts;

namespace MultipleDatabases.DAL.Migrations.SqlServer
{
    [DbContext(typeof(SqlServerTestDbContext))]
    partial class SqlServerTestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MultipleDatabases.DAL.Models.TestOne", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Condition")
                        .HasColumnType("bit");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TestOnes");
                });

            modelBuilder.Entity("MultipleDatabases.DAL.Models.TestTwo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Test")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TestOneId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TestOneId");

                    b.ToTable("TestTwos");
                });

            modelBuilder.Entity("MultipleDatabases.DAL.Models.TestTwo", b =>
                {
                    b.HasOne("MultipleDatabases.DAL.Models.TestOne", null)
                        .WithMany("Elems")
                        .HasForeignKey("TestOneId");
                });
#pragma warning restore 612, 618
        }
    }
}