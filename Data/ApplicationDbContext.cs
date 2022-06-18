using CourseManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<VideoEdu> VideoEdus { get; set; }
        public DbSet<QuizEdu> QuizEdus { get; set; }
        public DbSet<QuizAttempt> QuizAttempts { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<ArticleEdu> ArticleEdu { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Event> Event { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    string ADMIN_ID = "338adea8-ae89-4a2d-ad10-b9e9a893f805";
        //    string ROLE_ID = "47875744-879a-4284-a597-ffe875404bfd";

        //    builder.Entity<IdentityRole>().HasData(new IdentityRole
        //    {
        //        Name = "Admin",
        //        NormalizedName = "ADMIN",
        //        Id = ROLE_ID,
        //        ConcurrencyStamp = ROLE_ID
        //    });

        //    var appUser = new IdentityUser
        //    {
        //        Id = ADMIN_ID,
        //        Email = "admin@admin.pl",
        //        EmailConfirmed = true,
        //        UserName = "admin@admin.pl",
        //        NormalizedUserName = "ADMIN@ADMIN.PL"
        //    };

        //    PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
        //    appUser.PasswordHash = passwordHasher.HashPassword(appUser, "123456");
        //    builder.Entity<IdentityUser>().HasData(appUser);
        //    builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        //    {
        //        RoleId = ROLE_ID,
        //        UserId = ADMIN_ID,
        //    });

        //}
    }
}
