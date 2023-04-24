﻿using Microsoft.EntityFrameworkCore;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;" +
                "Initial Catalog=blogsite;" +
                "integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<match>()
                .HasOne(x => x.homeTeam)
                .WithMany(y => y.HomeMatches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(x => x.homeTeamId);

            modelBuilder.Entity<match>()
                .HasOne(x => x.guestTeam)
                .WithMany(y => y.AwayMatches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(x => x.guestTeamId);

            modelBuilder.Entity<Message2>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.WriterReceiver)
                .HasForeignKey(z => z.RecieverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.WriterSender)
                .HasForeignKey(z => z.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Catergories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRating> BlogRatings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<match> Matches { get; set; }
        public DbSet<team> teams { get; set; }
        public DbSet<Message2> Message2s { get; set; }
    }
}

