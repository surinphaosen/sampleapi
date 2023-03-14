using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleOData.Models;

public partial class SampleApiContext : DbContext
{
    public SampleApiContext()
    {
    }

    public SampleApiContext(DbContextOptions<SampleApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Customer_pkey");

            entity.ToTable("customer");

            entity.Property(e => e.Address)
                .HasMaxLength(1000)
                .HasColumnName("address");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("now()")
                .HasColumnName("created");
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("name");
            entity.Property(e => e.Tel)
                .HasMaxLength(50)
                .HasColumnName("tel");
        });
        modelBuilder.HasSequence<int>("customer_Id_seq");
    }
}