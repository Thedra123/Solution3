﻿// <auto-generated />
using Concat.API.Infraction.Conctret;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Concat.API.Infraction.Migrations.HospitalNo
{
    [DbContext(typeof(HospitalNoDbContext))]
    partial class HospitalNoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Concat.API.Model.HospitalNo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Hospitalname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hospitalno")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HospitalNo");
                });
#pragma warning restore 612, 618
        }
    }
}
