﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using tasks.Models;

namespace tasks.Context;

public partial class pubsContext : DbContext
{
    public pubsContext()
    {
    }

    public pubsContext(DbContextOptions<pubsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<publisher> publishers { get; set; }

    public virtual DbSet<title> titles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=pubs;Integrated Security=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<publisher>(entity =>
        {
            entity.HasKey(e => e.pub_id).HasName("UPKCL_pubind");

            entity.Property(e => e.pub_id).IsFixedLength();
            entity.Property(e => e.country).HasDefaultValueSql("('USA')");
            entity.Property(e => e.state).IsFixedLength();
        });

        modelBuilder.Entity<title>(entity =>
        {
            entity.HasKey(e => e.title_id).HasName("UPKCL_titleidind");

            entity.Property(e => e.pub_id).IsFixedLength();
            entity.Property(e => e.pubdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.type)
                .HasDefaultValueSql("('UNDECIDED')")
                .IsFixedLength();

            entity.HasOne(d => d.pub).WithMany(p => p.titles).HasConstraintName("FK__titles__pub_id__1A14E395");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}