﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhyndDemo_v2.Data;

namespace PhyndDemo_v2.Migrations
{
    [DbContext(typeof(phynd2Context))]
    [Migration("20210920135829_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("PhyndDemo_v2.Model.Efmigrationshistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("MigrationId")
                        .HasName("PRIMARY");

                    b.ToTable("__efmigrationshistory");
                });

            modelBuilder.Entity("PhyndDemo_v2.Model.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<string>("Action")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("action");

                    b.Property<DateTime?>("ActionTime")
                        .HasColumnType("datetime")
                        .HasColumnName("actionTime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("createdBy");

                    b.Property<string>("OnDatabase")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("onDatabase");

                    b.Property<string>("Query")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("query");

                    b.HasKey("Id");

                    b.ToTable("history");
                });

            modelBuilder.Entity("PhyndDemo_v2.Model.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("addressLine1");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("addressLine2");

                    b.Property<string>("AddressLine3")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("addressLine3");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("country");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("state");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("zipCode");

                    b.HasKey("Id");

                    b.ToTable("hospital");
                });

            modelBuilder.Entity("PhyndDemo_v2.Model.Program", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("createdOn")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("isDeleted");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("modifiedOn")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<int?>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.ToTable("program");
                });

            modelBuilder.Entity("PhyndDemo_v2.Model.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("createdOn")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("firstName");

                    b.Property<int?>("HospitalId")
                        .HasColumnType("int(11)")
                        .HasColumnName("hospitalId");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("isDeleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("lastName");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("middleName");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("modifiedOn")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int?>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "HospitalId" }, "provider_ibfk_1");

                    b.ToTable("provider");
                });

            modelBuilder.Entity("PhyndDemo_v2.Model.Providerprogram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("createdOn")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("isDeleted");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("modifiedOn")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int?>("ProgramId")
                        .HasColumnType("int(11)")
                        .HasColumnName("programId");

                    b.Property<int?>("ProviderId")
                        .HasColumnType("int(11)")
                        .HasColumnName("providerId");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProgramId" }, "providerprogram_ibfk_1");

                    b.HasIndex(new[] { "ProviderId" }, "providerprogram_ibfk_2");

                    b.ToTable("providerprogram");
                });

            modelBuilder.Entity("PhyndDemo_v2.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("isDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("PhyndDemo_v2.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("createdOn")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("firstName");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("isDeleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("lastName");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("modifiedOn")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("password");

                    b.Property<int>("UserHospitalId")
                        .HasColumnType("int(11)")
                        .HasColumnName("userHospitalId");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserHospitalId" }, "userHospitalId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("PhyndDemo_v2.Model.Userrole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int>("RoleId")
                        .HasColumnType("int(11)")
                        .HasColumnName("roleId");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleId" }, "roleId");

                    b.HasIndex(new[] { "UserId" }, "userId");

                    b.ToTable("userrole");
                });

            modelBuilder.Entity("PhyndDemo_v2.Model.Provider", b =>
                {
                    b.HasOne("PhyndDemo_v2.Model.Hospital", "Hospital")
                        .WithMany("Providers")
                        .HasForeignKey("HospitalId")
                        .HasConstraintName("provider_ibfk_1");

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("PhyndDemo_v2.Model.Providerprogram", b =>
                {
                    b.HasOne("PhyndDemo_v2.Model.Program", "Program")
                        .WithMany("Providerprograms")
                        .HasForeignKey("ProgramId")
                        .HasConstraintName("providerprogram_ibfk_1");

                    b.HasOne("PhyndDemo_v2.Model.Provider", "Provider")
                        .WithMany("Providerprograms")
                        .HasForeignKey("ProviderId")
                        .HasConstraintName("providerprogram_ibfk_2");

                    b.Navigation("Program");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("PhyndDemo_v2.Model.Userrole", b =>
                {
                    b.HasOne("PhyndDemo_v2.Model.Role", "Role")
                        .WithMany("Userroles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("userrole_ibfk_1")
                        .IsRequired();

                    b.HasOne("PhyndDemo_v2.Model.User", "User")
                        .WithMany("Userroles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("userrole_ibfk_2")
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PhyndDemo_v2.Model.Hospital", b =>
                {
                    b.Navigation("Providers");
                });

            modelBuilder.Entity("PhyndDemo_v2.Model.Program", b =>
                {
                    b.Navigation("Providerprograms");
                });

            modelBuilder.Entity("PhyndDemo_v2.Model.Provider", b =>
                {
                    b.Navigation("Providerprograms");
                });

            modelBuilder.Entity("PhyndDemo_v2.Model.Role", b =>
                {
                    b.Navigation("Userroles");
                });

            modelBuilder.Entity("PhyndDemo_v2.Model.User", b =>
                {
                    b.Navigation("Userroles");
                });
#pragma warning restore 612, 618
        }
    }
}
