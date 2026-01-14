using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using api.service.vm.domain.clases;

namespace api.service.vm.infrastructure;

public partial class ProyectoBDContext : DbContext
{
    public ProyectoBDContext(DbContextOptions<ProyectoBDContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleCita> DetalleCita { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
            .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
            .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
            .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn", "phone" })
            .HasPostgresEnum("auth", "oauth_authorization_status", new[] { "pending", "approved", "denied", "expired" })
            .HasPostgresEnum("auth", "oauth_client_type", new[] { "public", "confidential" })
            .HasPostgresEnum("auth", "oauth_registration_type", new[] { "dynamic", "manual" })
            .HasPostgresEnum("auth", "oauth_response_type", new[] { "code" })
            .HasPostgresEnum("auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" })
            .HasPostgresEnum("realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" })
            .HasPostgresEnum("realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in" })
            .HasPostgresEnum("storage", "buckettype", new[] { "STANDARD", "ANALYTICS", "VECTOR" })
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("graphql", "pg_graphql")
            .HasPostgresExtension("vault", "supabase_vault");

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("citas_pkey");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Cita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_citas_cliente");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Cita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_citas_empleado");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("clientes_pkey");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<DetalleCita>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("detalle_cita_pkey");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.IdCitaNavigation).WithMany(p => p.DetalleCita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_cita");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.DetalleCita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_servicio");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("empleados_pkey");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("pagos_pkey");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.FechaPago).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.IdCitaNavigation).WithMany(p => p.Pagos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pagos_cita");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("servicios_pkey");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.CreadoEn).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
