using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission_08.Models;

public partial class TaskItemsContext : DbContext
{
    public TaskItemsContext()
    {
    }

    public TaskItemsContext(DbContextOptions<TaskItemsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<TaskItem> TaskItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=taskItems.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.HasKey(e => e.TaskId);

            entity.ToTable("taskItems");

            entity.Property(e => e.TaskId).HasColumnName("taskId");
            entity.Property(e => e.Completed).HasDefaultValue(0);
            entity.Property(e => e.Task).HasDefaultValue("");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
