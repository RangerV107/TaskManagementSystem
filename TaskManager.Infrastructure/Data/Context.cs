using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain;

namespace TaskManager.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public DbSet<ProductionTask> ProductionTasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<OutDocument> OutDocuments { get; set; }
        public DbSet<InDocument> InDocuments { get; set; }
        public DbSet<ProductionSubTask> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductionTask>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<TaskType>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<OutDocument>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<InDocument>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<ProductionSubTask>().Property(e => e.Id).ValueGeneratedNever();
  
            //-------------------------------------------
            modelBuilder.Entity<ProductionTask>()
                .HasOne(pt => pt.TaskType)
                .WithMany(tt => tt.ProductionTasks)
                .IsRequired(true);

            modelBuilder.Entity<ProductionTask>()
                .HasMany(pt => pt.Tasks)
                .WithOne(t => t.ProductionTask)
                .IsRequired(true);

            modelBuilder.Entity<ProductionTask>()
                .OwnsMany(pt => pt.CompletionBasics);

            modelBuilder.Entity<ProductionTask>()
                .OwnsMany(pt => pt.CancellationBasics);

            modelBuilder.Entity<ProductionTask>()
                .HasOne(pt => pt.InputDocs)
                .WithOne(id => id.ProductionTask);

            modelBuilder.Entity<ProductionTask>()
                .HasMany(pt => pt.ReportDocs)
                .WithOne(od => od.ProductionTask);

            modelBuilder.Entity<ProductionTask>()
                .OwnsOne(pt => pt.ResponsibleExecutor);

            modelBuilder.Entity<ProductionTask>()
                .HasMany(pt => pt.Tasks)
                .WithOne(pst => pst.ProductionTask);

            //-------------------------------------------
            modelBuilder.Entity<InDocument>()
                .OwnsOne(pt => pt.RegistrPerson);

            modelBuilder.Entity<InDocument>()
                .OwnsMany(pt => pt.Documents);

            modelBuilder.Entity<OutDocument>()
                .OwnsOne(pt => pt.Executor);

            modelBuilder.Entity<OutDocument>()
                .OwnsOne(pt => pt.RespCommandPerson);

            modelBuilder.Entity<OutDocument>()
                .OwnsOne(pt => pt.ResponsePerson);

            modelBuilder.Entity<OutDocument>()
                .OwnsMany(pt => pt.Documents);


            //-------------------------------------------
            modelBuilder.Entity<ProductionSubTask>()
                .HasOne(t => t.UpperTask)
                .WithMany(ut => ut.SubTasks);

            modelBuilder.Entity<ProductionSubTask>()
                .OwnsOne(pt => pt.Executor);

            modelBuilder.Entity<ProductionSubTask>()
                .OwnsMany(pt => pt.ReportDocs);

        }

    }



}
