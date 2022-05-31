using System;
using System.Collections.Generic;
using System.Text;
using Kessewa.Quiz.Domain.Entities;
using Kessewa.Quiz.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Kessewa.Quiz.Persistence.DatabaseContext
{
    public class KessewaDbContext : DbContext
    {
        public KessewaDbContext()
        {
            
        }
        public KessewaDbContext(DbContextOptions<KessewaDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Submissions> Submissions { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Quizzes> Quizzes { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Lecturers> Lecturers { get; set; }
        public DbSet<Faculties> Faculties { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Courses> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=KessewaQuizDev;Trusted_Connection=True;");
            }
            optionsBuilder.EnableSensitiveDataLogging();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.UserConfig();
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguratioon());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new FacultyConfiguration());
            modelBuilder.ApplyConfiguration(new LecturerConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new QuizConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new SubmissionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
