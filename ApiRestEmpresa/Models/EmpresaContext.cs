using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiRestEmpresa.Models
{
    public partial class EmpresaContext : DbContext
    {
        public EmpresaContext()
        {
        }

        public EmpresaContext(DbContextOptions<EmpresaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatalogoInventario> CatalogoInventarios { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Estante> Estantes { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<FacturaVistum> FacturaVista { get; set; } = null!;
        public virtual DbSet<MovimientoInventario> MovimientoInventarios { get; set; } = null!;
        public virtual DbSet<Orden> Ordens { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedors { get; set; } = null!;
        public virtual DbSet<TipoMovimientoInventario> TipoMovimientoInventarios { get; set; } = null!;
        public virtual DbSet<TipoOrden> TipoOrdens { get; set; } = null!;
        public virtual DbSet<Ubicacion> Ubicacions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogoInventario>(entity =>
            {
                entity.HasKey(e => e.IdCatalogoInventario);

                entity.ToTable("CatalogoInventario");

                entity.HasIndex(e => e.CodInventario, "IX_CatalogoInventario")
                    .IsUnique();

                entity.Property(e => e.CodInventario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstanteNavigation)
                    .WithMany(p => p.CatalogoInventarios)
                    .HasForeignKey(d => d.IdEstante)
                    .HasConstraintName("FK_CatalogoInventario_Estante");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.CatalogoInventarios)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_CatalogoInventario_Producto");

                entity.HasOne(d => d.IdUbicacionNavigation)
                    .WithMany(p => p.CatalogoInventarios)
                    .HasForeignKey(d => d.IdUbicacion)
                    .HasConstraintName("FK_CatalogoInventario_Ubicacion");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("Cliente");

                entity.HasIndex(e => e.CodCliente, "IX_Cliente")
                    .IsUnique();

                entity.Property(e => e.CodCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoFijo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoMovil)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado);

                entity.ToTable("Estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estante>(entity =>
            {
                entity.HasKey(e => e.IdEstante);

                entity.ToTable("Estante");

                entity.Property(e => e.Estante1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Estante");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.ToTable("Factura");

                entity.HasIndex(e => e.IdFactura, "IX_Factura")
                    .IsUnique();

                entity.Property(e => e.CodFactura)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Factura_Cliente");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdOrden)
                    .HasConstraintName("FK_Factura_Orden");
            });

            modelBuilder.Entity<FacturaVistum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("FacturaVista");

                entity.Property(e => e.CodCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodFactura)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodOrden)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoFijo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoMovil)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoOrden)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MovimientoInventario>(entity =>
            {
                entity.HasKey(e => e.IdMovimientoInventario);

                entity.ToTable("MovimientoInventario");

                entity.HasIndex(e => e.CodMovimientoInventario, "IX_MovimientoInventario")
                    .IsUnique();

                entity.Property(e => e.CodMovimientoInventario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCatalogoInventarioNavigation)
                    .WithMany(p => p.MovimientoInventarios)
                    .HasForeignKey(d => d.IdCatalogoInventario)
                    .HasConstraintName("FK_MovimientoInventario_CatalogoInventario");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithMany(p => p.MovimientoInventarios)
                    .HasForeignKey(d => d.IdOrden)
                    .HasConstraintName("FK_MovimientoInventario_Orden1");

                entity.HasOne(d => d.IdTipoMovInventarioNavigation)
                    .WithMany(p => p.MovimientoInventarios)
                    .HasForeignKey(d => d.IdTipoMovInventario)
                    .HasConstraintName("FK_MovimientoInventario_TipoMovimientoInventario");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.HasKey(e => e.IdOrden)
                    .HasName("PK_Orden_1");

                entity.ToTable("Orden");

                entity.HasIndex(e => e.CodOrden, "IX_Orden")
                    .IsUnique();

                entity.Property(e => e.CodOrden)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoOrdenNavigation)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.IdTipoOrden)
                    .HasConstraintName("FK_Orden_TipoOrden");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.ToTable("Producto");

                entity.HasIndex(e => e.CodProducto, "IX_Producto")
                    .IsUnique();

                entity.Property(e => e.CodProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK_Producto_Estado");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK_Producto_Proveedor");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor);

                entity.ToTable("Proveedor");

                entity.HasIndex(e => e.CodProveedor, "IX_Proveedor")
                    .IsUnique();

                entity.Property(e => e.CodProveedor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoMovimientoInventario>(entity =>
            {
                entity.HasKey(e => e.IdTipoMovInventario);

                entity.ToTable("TipoMovimientoInventario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoOrden>(entity =>
            {
                entity.HasKey(e => e.IdTipoOrden);

                entity.ToTable("TipoOrden");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.HasKey(e => e.IdUbicacion);

                entity.ToTable("Ubicacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
