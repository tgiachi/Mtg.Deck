﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mtg.Deck.Database.Context;

#nullable disable

namespace Mtg.Deck.Database.Migrations
{
    [DbContext(typeof(DeckDatabaseContext))]
    [Migration("20220611142123_ModifiedCardsColors")]
    partial class ModifiedCardsColors
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("Mtg.Deck.Database.Entities.CardEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CardName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CardTypeId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ManaCost")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("MtgId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalManaCosts")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CardTypeId");

                    b.ToTable("cards");
                });

            modelBuilder.Entity("Mtg.Deck.Database.Entities.CardTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CardType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("card_types");
                });

            modelBuilder.Entity("Mtg.Deck.Database.Entities.ColorCardEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CardId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ColorId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("ColorId");

                    b.ToTable("CardColors");
                });

            modelBuilder.Entity("Mtg.Deck.Database.Entities.ColorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("colors");
                });

            modelBuilder.Entity("Mtg.Deck.Database.Entities.CardEntity", b =>
                {
                    b.HasOne("Mtg.Deck.Database.Entities.CardTypeEntity", "CardType")
                        .WithMany("Cards")
                        .HasForeignKey("CardTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardType");
                });

            modelBuilder.Entity("Mtg.Deck.Database.Entities.ColorCardEntity", b =>
                {
                    b.HasOne("Mtg.Deck.Database.Entities.CardEntity", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mtg.Deck.Database.Entities.ColorEntity", "Color")
                        .WithMany("ColorCards")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Card");

                    b.Navigation("Color");
                });

            modelBuilder.Entity("Mtg.Deck.Database.Entities.CardTypeEntity", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("Mtg.Deck.Database.Entities.ColorEntity", b =>
                {
                    b.Navigation("ColorCards");
                });
#pragma warning restore 612, 618
        }
    }
}
