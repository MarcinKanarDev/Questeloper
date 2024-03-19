﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Questeloper.Infrastructure.Persistence;

#nullable disable

namespace Questeloper.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(QuesteloperDbContext))]
    partial class QuesteloperDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CategoryQuestion", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionsId")
                        .HasColumnType("integer");

                    b.HasKey("CategoriesId", "QuestionsId");

                    b.HasIndex("QuestionsId");

                    b.ToTable("CategoryQuestion");
                });

            modelBuilder.Entity("Questeloper.Domain.Entities.Battle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BattleDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EnemyId")
                        .HasColumnType("integer");

                    b.Property<int?>("EnemyId1")
                        .HasColumnType("integer");

                    b.Property<int>("HeroId")
                        .HasColumnType("integer");

                    b.Property<int?>("HeroId1")
                        .HasColumnType("integer");

                    b.Property<int>("Result")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EnemyId");

                    b.HasIndex("EnemyId1");

                    b.HasIndex("HeroId");

                    b.HasIndex("HeroId1");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("Questeloper.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Questeloper.Domain.Entities.Enemy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("HealthPoints")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasMaxLength(100)
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.ToTable("Enemies");
                });

            modelBuilder.Entity("Questeloper.Domain.Entities.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<int>("HealthPoints")
                        .HasColumnType("integer");

                    b.Property<string>("HeroClass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HeroName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("Level")
                        .HasMaxLength(100)
                        .HasColumnType("integer");

                    b.Property<int>("ManaPoints")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("Questeloper.Domain.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EnemyId")
                        .HasColumnType("integer");

                    b.Property<string>("QuestionType")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("character varying(34)");

                    b.HasKey("Id");

                    b.HasIndex("EnemyId");

                    b.ToTable("Questions");

                    b.HasDiscriminator<string>("QuestionType").HasValue("Question");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Questeloper.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("NickName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Questeloper.Domain.Entities.MultipleChoiceQuestion", b =>
                {
                    b.HasBaseType("Questeloper.Domain.Entities.Question");

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OptionA")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OptionB")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OptionC")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OptionD")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("MultipleChoiceQuestion");
                });

            modelBuilder.Entity("Questeloper.Domain.Entities.TextAnswerQuestion", b =>
                {
                    b.HasBaseType("Questeloper.Domain.Entities.Question");

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("Questions", t =>
                        {
                            t.Property("CorrectAnswer")
                                .HasColumnName("TextAnswerQuestion_CorrectAnswer");
                        });

                    b.HasDiscriminator().HasValue("TextAnswerQuestion");
                });

            modelBuilder.Entity("CategoryQuestion", b =>
                {
                    b.HasOne("Questeloper.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Questeloper.Domain.Entities.Question", null)
                        .WithMany()
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Questeloper.Domain.Entities.Battle", b =>
                {
                    b.HasOne("Questeloper.Domain.Entities.Enemy", "Enemy")
                        .WithMany()
                        .HasForeignKey("EnemyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Questeloper.Domain.Entities.Enemy", null)
                        .WithMany("Battles")
                        .HasForeignKey("EnemyId1");

                    b.HasOne("Questeloper.Domain.Entities.Hero", "Hero")
                        .WithMany()
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Questeloper.Domain.Entities.Hero", null)
                        .WithMany("Battles")
                        .HasForeignKey("HeroId1");

                    b.Navigation("Enemy");

                    b.Navigation("Hero");
                });

            modelBuilder.Entity("Questeloper.Domain.Entities.Question", b =>
                {
                    b.HasOne("Questeloper.Domain.Entities.Enemy", "Enemy")
                        .WithMany("Questions")
                        .HasForeignKey("EnemyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Enemy");
                });

            modelBuilder.Entity("Questeloper.Domain.Entities.Enemy", b =>
                {
                    b.Navigation("Battles");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Questeloper.Domain.Entities.Hero", b =>
                {
                    b.Navigation("Battles");
                });
#pragma warning restore 612, 618
        }
    }
}
