﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SolverChallengue.DataAccess.DbContext;

namespace SolverChallengue.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20201018012924_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SolverChallengue.DataAccess.Entities.Record", b =>
                {
                    b.Property<Guid>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("ExecDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("RecordId");

                    b.ToTable("Records");
                });
#pragma warning restore 612, 618
        }
    }
}