﻿// <auto-generated />
using System;
using AstralGroupVacancySearcher.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AstralGroupVacancySearcher.Migrations
{
    [DbContext(typeof(CurrentDbContext))]
    [Migration("20181212141047_removedEnumsFromLog")]
    partial class removedEnumsFromLog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AstralGroupVacancySearcher.Models.HHRestModels.Address", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("building");

                    b.Property<string>("city");

                    b.Property<double?>("lat");

                    b.Property<double?>("lng");

                    b.Property<string>("raw");

                    b.Property<string>("street");

                    b.HasKey("id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("AstralGroupVacancySearcher.Models.HHRestModels.Contacts", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("AstralGroupVacancySearcher.Models.HHRestModels.Employer", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("alternate_url");

                    b.Property<string>("name");

                    b.Property<bool>("trusted");

                    b.Property<string>("url");

                    b.Property<string>("vacancies_url");

                    b.HasKey("id");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("AstralGroupVacancySearcher.Models.HHRestModels.Item", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("addressid");

                    b.Property<string>("alternate_url");

                    b.Property<string>("apply_alternate_url");

                    b.Property<bool?>("archived");

                    b.Property<int?>("contactsid");

                    b.Property<DateTime>("created_at");

                    b.Property<string>("employerid");

                    b.Property<int?>("from");

                    b.Property<bool?>("has_test");

                    b.Property<long?>("logid");

                    b.Property<string>("name");

                    b.Property<bool?>("premium");

                    b.Property<DateTime>("published_at");

                    b.Property<bool?>("response_letter_required");

                    b.Property<int?>("to");

                    b.Property<string>("typeid");

                    b.Property<string>("url");

                    b.HasKey("id");

                    b.HasIndex("addressid");

                    b.HasIndex("contactsid");

                    b.HasIndex("employerid");

                    b.HasIndex("logid");

                    b.HasIndex("typeid");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("AstralGroupVacancySearcher.Models.HHRestModels.Phone", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Contactsid");

                    b.Property<string>("city");

                    b.Property<string>("comment");

                    b.Property<string>("country");

                    b.Property<string>("number");

                    b.HasKey("id");

                    b.HasIndex("Contactsid");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("AstralGroupVacancySearcher.Models.HHRestModels.Type", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("AstralGroupVacancySearcher.Models.Log", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime");

                    b.Property<bool?>("IsSuccess");

                    b.Property<string>("Message");

                    b.Property<long?>("Parentid");

                    b.HasKey("id");

                    b.HasIndex("Parentid");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("AstralGroupVacancySearcher.Models.HHRestModels.Item", b =>
                {
                    b.HasOne("AstralGroupVacancySearcher.Models.HHRestModels.Address", "address")
                        .WithMany()
                        .HasForeignKey("addressid");

                    b.HasOne("AstralGroupVacancySearcher.Models.HHRestModels.Contacts", "contacts")
                        .WithMany()
                        .HasForeignKey("contactsid");

                    b.HasOne("AstralGroupVacancySearcher.Models.HHRestModels.Employer", "employer")
                        .WithMany()
                        .HasForeignKey("employerid");

                    b.HasOne("AstralGroupVacancySearcher.Models.Log", "log")
                        .WithMany()
                        .HasForeignKey("logid");

                    b.HasOne("AstralGroupVacancySearcher.Models.HHRestModels.Type", "type")
                        .WithMany()
                        .HasForeignKey("typeid");
                });

            modelBuilder.Entity("AstralGroupVacancySearcher.Models.HHRestModels.Phone", b =>
                {
                    b.HasOne("AstralGroupVacancySearcher.Models.HHRestModels.Contacts")
                        .WithMany("phones")
                        .HasForeignKey("Contactsid");
                });

            modelBuilder.Entity("AstralGroupVacancySearcher.Models.Log", b =>
                {
                    b.HasOne("AstralGroupVacancySearcher.Models.Log", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("Parentid");
                });
#pragma warning restore 612, 618
        }
    }
}
