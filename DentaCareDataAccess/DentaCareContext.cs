using DentaCareDataAccess.Configurations;
using DentaCare.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentaCareDataAccess
{
    public class DentaCareContext : DbContext
    {

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users{ get; set; }

        public DbSet<Appointment> Appointments{ get; set; }

        public DbSet<ServiceType> ServiceTypes{ get; set; }

        public DbSet<Jaw> Jaws { get; set; }

        public DbSet<JawSide> JawSides { get; set; }

        public DbSet<Teeth> Teeth { get; set; }

        public DbSet<JawJawSideTooth> JawJawSideTeeth { get; set; }

        public DbSet<Dentist> Dentists { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<EKarton> EKarton { get; set; }

        public DbSet<UseCaseLog> UseCaseLog { get; set; }

        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries())
            {
                if(entry.Entity is EntityBase e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.Now;
                            e.IsDeleted = false;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            break;

                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-856E52S;Initial Catalog=DentaCareApi;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new JawConfiguration());
            modelBuilder.ApplyConfiguration(new JawSideConfiguration());
            modelBuilder.ApplyConfiguration(new TeethConfiguration());
            modelBuilder.ApplyConfiguration(new DentistConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new JawJawSideToothConfiguration());
            modelBuilder.ApplyConfiguration(new EKartonConfiguration());

            modelBuilder.Entity<Role>().HasQueryFilter(r => !r.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            //modelBuilder.Entity<EKarton>().HasQueryFilter(u => !u.IsDeleted);

            //modelBuilder.Entity<User>()
            //    .HasOne(a => a.Ekarton)
            //    .WithOne(b => (User)b.Users)
            //    .HasForeignKey<EKarton>(b => b.Users);
        }
    }
}
