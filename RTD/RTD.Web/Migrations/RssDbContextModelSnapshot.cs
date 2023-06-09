﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RTD.Web.Engine.EF;

#nullable disable

namespace RTD.Web.Migrations
{
    [DbContext(typeof(RssDbContext))]
    partial class RssDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("RTD.Web.Engine.EF.AdminUser", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("AdminUsers");
                });

            modelBuilder.Entity("RTD.Web.Engine.EF.DiscordHook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("HookUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DiscordHooks");
                });

            modelBuilder.Entity("RTD.Web.Engine.EF.RssEntry", b =>
                {
                    b.Property<Guid>("RssEntryInternalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ItemDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("RssSourceId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RssEntryInternalId");

                    b.HasIndex("RssSourceId");

                    b.ToTable("RssEntries");
                });

            modelBuilder.Entity("RTD.Web.Engine.EF.RssSource", b =>
                {
                    b.Property<Guid>("RssSourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateChecked")
                        .HasColumnType("TEXT");

                    b.Property<string>("RssName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RssSourceId");

                    b.ToTable("RssSources");
                });

            modelBuilder.Entity("RTD.Web.Engine.EF.RssEntry", b =>
                {
                    b.HasOne("RTD.Web.Engine.EF.RssSource", null)
                        .WithMany("RssEntries")
                        .HasForeignKey("RssSourceId");
                });

            modelBuilder.Entity("RTD.Web.Engine.EF.RssSource", b =>
                {
                    b.Navigation("RssEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
