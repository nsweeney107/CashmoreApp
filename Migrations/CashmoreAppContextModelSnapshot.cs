﻿// <auto-generated />
using CashmoreApp.Data;
using CashmoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CashmoreApp.Migrations
{
    [DbContext(typeof(CashmoreAppContext))]
    partial class CashmoreAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("CashmoreApp.Models.Contract", b =>
                {
                    b.Property<int>("ContractID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ContractEndDate");

                    b.Property<string>("ContractProductLine")
                        .IsRequired();

                    b.Property<string>("ContractPurchaseOrder")
                        .IsRequired();

                    b.Property<DateTime>("ContractStartDate");

                    b.Property<string>("ContractStatus");

                    b.Property<decimal>("ContractValue");

                    b.HasKey("ContractID");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("CashmoreApp.Models.Entity", b =>
                {
                    b.Property<int>("EntityID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EntityAddress1")
                        .IsRequired();

                    b.Property<string>("EntityAddress2");

                    b.Property<string>("EntityCity")
                        .IsRequired();

                    b.Property<string>("EntityCountry")
                        .IsRequired();

                    b.Property<string>("EntityName")
                        .IsRequired();

                    b.Property<string>("EntityPhoneNumber")
                        .IsRequired();

                    b.Property<string>("EntityState")
                        .IsRequired();

                    b.Property<int>("EntityType");

                    b.Property<string>("EntityZipcode")
                        .IsRequired();

                    b.HasKey("EntityID");

                    b.ToTable("Entity");
                });

            modelBuilder.Entity("CashmoreApp.Models.EntityToContract", b =>
                {
                    b.Property<int>("EntityID");

                    b.Property<int>("ContractID");

                    b.HasKey("EntityID", "ContractID");

                    b.HasIndex("ContractID");

                    b.ToTable("EntityToContract");
                });

            modelBuilder.Entity("CashmoreApp.Models.Signatures", b =>
                {
                    b.Property<int>("SignaturesID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContractID");

                    b.Property<int>("ContractType");

                    b.Property<int?>("HospitalSignatureUserID");

                    b.Property<int?>("VendorSignatureUserID");

                    b.HasKey("SignaturesID");

                    b.HasIndex("ContractID");

                    b.HasIndex("HospitalSignatureUserID");

                    b.HasIndex("VendorSignatureUserID");

                    b.ToTable("Signatures");
                });

            modelBuilder.Entity("CashmoreApp.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EntityID");

                    b.Property<int>("UserAccessLevel");

                    b.Property<string>("UserEmail")
                        .IsRequired();

                    b.Property<string>("UserFirstName")
                        .IsRequired()
                        .HasColumnName("First Name")
                        .HasMaxLength(50);

                    b.Property<string>("UserLastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserPassword")
                        .IsRequired();

                    b.HasKey("UserID");

                    b.HasIndex("EntityID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CashmoreApp.Models.EntityToContract", b =>
                {
                    b.HasOne("CashmoreApp.Models.Contract", "Contract")
                        .WithMany("ContractEntities")
                        .HasForeignKey("ContractID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CashmoreApp.Models.Entity", "Entity")
                        .WithMany("EntityContracts")
                        .HasForeignKey("EntityID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CashmoreApp.Models.Signatures", b =>
                {
                    b.HasOne("CashmoreApp.Models.Contract", "BaseContract")
                        .WithMany("ContractSignatures")
                        .HasForeignKey("ContractID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CashmoreApp.Models.User", "HospitalSignature")
                        .WithMany()
                        .HasForeignKey("HospitalSignatureUserID");

                    b.HasOne("CashmoreApp.Models.User", "VendorSignature")
                        .WithMany()
                        .HasForeignKey("VendorSignatureUserID");
                });

            modelBuilder.Entity("CashmoreApp.Models.User", b =>
                {
                    b.HasOne("CashmoreApp.Models.Entity", "UserEntity")
                        .WithMany("EntityUsers")
                        .HasForeignKey("EntityID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
