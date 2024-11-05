using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SupplyChain.Server.Models;

public partial class TxngContext : DbContext
{
    public TxngContext()
    {
    }

    public TxngContext(DbContextOptions<TxngContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Batch> Batches { get; set; }

    public virtual DbSet<Business> Businesses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<CodeTransport> CodeTransports { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<DiaryActivity> DiaryActivities { get; set; }

    public virtual DbSet<DiaryCategory> DiaryCategories { get; set; }

    public virtual DbSet<DiaryTransport> DiaryTransports { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Factory> Factories { get; set; }

    public virtual DbSet<Imageinfo> Imageinfos { get; set; }

    public virtual DbSet<LogActivestamp> LogActivestamps { get; set; }

    public virtual DbSet<LogScan> LogScans { get; set; }

    public virtual DbSet<LogTransaction> LogTransactions { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Member1> Members1 { get; set; }

    public virtual DbSet<MemberGroup> MemberGroups { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PermissionGroup> PermissionGroups { get; set; }

    public virtual DbSet<ProduceArea> ProduceAreas { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ShareRequest> ShareRequests { get; set; }

    public virtual DbSet<Stamp> Stamps { get; set; }

    public virtual DbSet<StampBatch> StampBatches { get; set; }

    public virtual DbSet<StampOrder> StampOrders { get; set; }

    public virtual DbSet<Transport> Transports { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Name=ConnectionStrings:dbTXNG");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Idadd).IsClustered(false);

            entity.ToTable("ADDRESS");

            entity.HasIndex(e => new { e.Idc, e.Idcy, e.Iddis, e.Idwa }, "RELATIONSHIP_29_FK");

            entity.Property(e => e.Idadd).HasColumnName("IDADD");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Gln)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("GLN");
            entity.Property(e => e.Idc).HasColumnName("IDC");
            entity.Property(e => e.Idcy).HasColumnName("IDCY");
            entity.Property(e => e.Iddis).HasColumnName("IDDIS");
            entity.Property(e => e.Idwa).HasColumnName("IDWA");
            entity.Property(e => e.Lat).HasColumnName("LAT");
            entity.Property(e => e.Lon).HasColumnName("LON");

            entity.HasOne(d => d.Ward).WithMany(p => p.Addresses)
                .HasForeignKey(d => new { d.Idc, d.Idcy, d.Iddis, d.Idwa })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ADDRESS_RELATIONS_WARD");
        });

        modelBuilder.Entity<Batch>(entity =>
        {
            entity.HasKey(e => e.Idbat).IsClustered(false);

            entity.ToTable("BATCHES");

            entity.HasIndex(e => new { e.Idbus, e.Gln }, "BUSINESS_HAVE_FK");

            entity.HasIndex(e => e.Material, "MATERIAL_OF_BATCHE_FK");

            entity.Property(e => e.Idbat).HasColumnName("IDBAT");
            entity.Property(e => e.Backingspecification)
                .HasMaxLength(123)
                .IsUnicode(false)
                .HasColumnName("BACKINGSPECIFICATION");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Dfg)
                .HasColumnType("datetime")
                .HasColumnName("DFG");
            entity.Property(e => e.Exp)
                .HasColumnType("datetime")
                .HasColumnName("EXP");
            entity.Property(e => e.Gln)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("GLN");
            entity.Property(e => e.Idbus).HasColumnName("IDBUS");
            entity.Property(e => e.Material).HasColumnName("MATERIAL");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");
            entity.Property(e => e.Unit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("UNIT");
            entity.Property(e => e.Weigh).HasColumnName("WEIGH");

            entity.HasOne(d => d.MaterialNavigation).WithMany(p => p.InverseMaterialNavigation)
                .HasForeignKey(d => d.Material)
                .HasConstraintName("FK_BATCHES_MATERIAL__BATCHES");

            entity.HasOne(d => d.Business).WithMany(p => p.Batches)
                .HasForeignKey(d => new { d.Idbus, d.Gln })
                .HasConstraintName("FK_BATCHES_BUSINESS__BUSINESS");
        });

        modelBuilder.Entity<Business>(entity =>
        {
            entity.HasKey(e => new { e.Idbus, e.Gln }).IsClustered(false);

            entity.ToTable("BUSINESS");

            entity.HasIndex(e => e.Iddoc, "BUSINESS_HAVE_DOCUMENT_FK");

            entity.HasIndex(e => e.Idadd, "RELATIONSHIP_34_FK");

            entity.HasIndex(e => e.Idmem, "REPRESENT_FK");

            entity.Property(e => e.Idbus)
                .ValueGeneratedOnAdd()
                .HasColumnName("IDBUS");
            entity.Property(e => e.Gln)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("GLN");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Idadd).HasColumnName("IDADD");
            entity.Property(e => e.Iddoc).HasColumnName("IDDOC");
            entity.Property(e => e.Idmem).HasColumnName("IDMEM");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PHONENUMBER");
            entity.Property(e => e.Taxcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TAXCODE");
            entity.Property(e => e.Type)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TYPE");

            entity.HasOne(d => d.IdaddNavigation).WithMany(p => p.Businesses)
                .HasForeignKey(d => d.Idadd)
                .HasConstraintName("FK_BUSINESS_RELATIONS_ADDRESS");

            entity.HasOne(d => d.IddocNavigation).WithMany(p => p.Businesses)
                .HasForeignKey(d => d.Iddoc)
                .HasConstraintName("FK_BUSINESS_BUSINESS__DOCUMENT");

            entity.HasOne(d => d.IdmemNavigation).WithMany(p => p.Businesses)
                .HasForeignKey(d => d.Idmem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BUSINESS_REPRESENT_MEMBER");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Idcg).IsClustered(false);

            entity.ToTable("CATEGORIES");

            entity.HasIndex(e => new { e.Idbus, e.Gln }, "BUSINESS_HAVE_CATEGORY_FK");

            entity.HasIndex(e => e.CatIdcg, "INGREDIENT_HAVE_FK");

            entity.Property(e => e.Idcg).HasColumnName("IDCG");
            entity.Property(e => e.CatIdcg).HasColumnName("CAT_IDCG");
            entity.Property(e => e.Createat)
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Describe)
                .HasMaxLength(123)
                .IsUnicode(false)
                .HasColumnName("DESCRIBE");
            entity.Property(e => e.Gln)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("GLN");
            entity.Property(e => e.Idbus).HasColumnName("IDBUS");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NAME");

            entity.HasOne(d => d.CatIdcgNavigation).WithMany(p => p.InverseCatIdcgNavigation)
                .HasForeignKey(d => d.CatIdcg)
                .HasConstraintName("FK_CATEGORI_INGREDIEN_CATEGORI");

            entity.HasOne(d => d.Business).WithMany(p => p.Categories)
                .HasForeignKey(d => new { d.Idbus, d.Gln })
                .HasConstraintName("FK_CATEGORI_BUSINESS__BUSINESS");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => new { e.Idc, e.Idcy }).IsClustered(false);

            entity.ToTable("CITY");

            entity.HasIndex(e => e.Idc, "RELATIONSHIP_42_FK");

            entity.Property(e => e.Idc).HasColumnName("IDC");
            entity.Property(e => e.Idcy)
                .ValueGeneratedOnAdd()
                .HasColumnName("IDCY");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Type)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TYPE");

            entity.HasOne(d => d.IdcNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.Idc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CITY_RELATIONS_COUNTRY");
        });

        modelBuilder.Entity<CodeTransport>(entity =>
        {
            entity.HasKey(e => e.Idct).IsClustered(false);

            entity.ToTable("CODE_TRANSPORT");

            entity.HasIndex(e => e.Idbat, "BATCHE_HAVE_CODETRANSPORT_FK");

            entity.HasIndex(e => e.Idtra, "SHIPPED_BY_TRANSPORT_FK");

            entity.Property(e => e.Idct).HasColumnName("IDCT");
            entity.Property(e => e.Backingspecification)
                .HasMaxLength(123)
                .IsUnicode(false)
                .HasColumnName("BACKINGSPECIFICATION");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Idbat).HasColumnName("IDBAT");
            entity.Property(e => e.Idtra).HasColumnName("IDTRA");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");
            entity.Property(e => e.Weigh).HasColumnName("WEIGH");

            entity.HasOne(d => d.IdbatNavigation).WithMany(p => p.CodeTransports)
                .HasForeignKey(d => d.Idbat)
                .HasConstraintName("FK_CODE_TRA_BATCHE_HA_BATCHES");

            entity.HasOne(d => d.IdtraNavigation).WithMany(p => p.CodeTransports)
                .HasForeignKey(d => d.Idtra)
                .HasConstraintName("FK_CODE_TRA_SHIPPED_B_TRANSPOR");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Idc).IsClustered(false);

            entity.ToTable("COUNTRY");

            entity.Property(e => e.Idc).HasColumnName("IDC");
            entity.Property(e => e.Continent)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CONTINENT");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<DiaryActivity>(entity =>
        {
            entity.HasKey(e => e.Idda).IsClustered(false);

            entity.ToTable("DIARY_ACTIVITY");

            entity.HasIndex(e => e.Idmem, "CREATE_BY_MEMBER_FK");

            entity.HasIndex(e => e.Idbat, "DIARY_OF_BATCH_FK");

            entity.Property(e => e.Idda).HasColumnName("IDDA");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Idbat).HasColumnName("IDBAT");
            entity.Property(e => e.Idmem).HasColumnName("IDMEM");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Type)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TYPE");

            entity.HasOne(d => d.IdbatNavigation).WithMany(p => p.DiaryActivities)
                .HasForeignKey(d => d.Idbat)
                .HasConstraintName("FK_DIARY_AC_DIARY_OF__BATCHES");

            entity.HasOne(d => d.IdmemNavigation).WithMany(p => p.DiaryActivities)
                .HasForeignKey(d => d.Idmem)
                .HasConstraintName("FK_DIARY_AC_CREATE_BY_MEMBER");
        });

        modelBuilder.Entity<DiaryCategory>(entity =>
        {
            entity.HasKey(e => e.Iddc).IsClustered(false);

            entity.ToTable("DIARY_CATEGORY");

            entity.HasIndex(e => e.Idmem, "RELATIONSHIP_44_FK");

            entity.Property(e => e.Iddc).HasColumnName("IDDC");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Describe)
                .HasMaxLength(123)
                .IsUnicode(false)
                .HasColumnName("DESCRIBE");
            entity.Property(e => e.Idmem).HasColumnName("IDMEM");

            entity.HasOne(d => d.IdmemNavigation).WithMany(p => p.DiaryCategories)
                .HasForeignKey(d => d.Idmem)
                .HasConstraintName("FK_DIARY_CA_RELATIONS_MEMBER");
        });

        modelBuilder.Entity<DiaryTransport>(entity =>
        {
            entity.HasKey(e => e.Iddt).IsClustered(false);

            entity.ToTable("DIARY_TRANSPORT");

            entity.HasIndex(e => e.Idct, "RELATIONSHIP_31_FK");

            entity.HasIndex(e => e.Idmem, "RELATIONSHIP_32_FK");

            entity.Property(e => e.Iddt).HasColumnName("IDDT");
            entity.Property(e => e.Arrivetime)
                .HasColumnType("datetime")
                .HasColumnName("ARRIVETIME");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Departtime)
                .HasColumnType("datetime")
                .HasColumnName("DEPARTTIME");
            entity.Property(e => e.Idct).HasColumnName("IDCT");
            entity.Property(e => e.Idmem).HasColumnName("IDMEM");
            entity.Property(e => e.Note)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOTE");
            entity.Property(e => e.Status)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("STATUS");

            entity.HasOne(d => d.IdctNavigation).WithMany(p => p.DiaryTransports)
                .HasForeignKey(d => d.Idct)
                .HasConstraintName("FK_DIARY_TR_RELATIONS_CODE_TRA");

            entity.HasOne(d => d.IdmemNavigation).WithMany(p => p.DiaryTransports)
                .HasForeignKey(d => d.Idmem)
                .HasConstraintName("FK_DIARY_TR_RELATIONS_MEMBER");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => new { e.Idc, e.Idcy, e.Iddis }).IsClustered(false);

            entity.ToTable("DISTRICT");

            entity.HasIndex(e => new { e.Idc, e.Idcy }, "RELATIONSHIP_28_FK");

            entity.Property(e => e.Idc).HasColumnName("IDC");
            entity.Property(e => e.Idcy).HasColumnName("IDCY");
            entity.Property(e => e.Iddis)
                .ValueGeneratedOnAdd()
                .HasColumnName("IDDIS");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Type)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TYPE");

            entity.HasOne(d => d.City).WithMany(p => p.Districts)
                .HasForeignKey(d => new { d.Idc, d.Idcy })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DISTRICT_RELATIONS_CITY");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Iddoc).IsClustered(false);

            entity.ToTable("DOCUMENT");

            entity.Property(e => e.Iddoc).HasColumnName("IDDOC");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Describe)
                .HasMaxLength(123)
                .IsUnicode(false)
                .HasColumnName("DESCRIBE");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Type)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TYPE");
        });

        modelBuilder.Entity<Factory>(entity =>
        {
            entity.HasKey(e => new { e.Idfac, e.Gln }).IsClustered(false);

            entity.ToTable("FACTORY");

            entity.HasIndex(e => e.Iddoc, "FACTORY_HAVE_DOCUMENT_FK");

            entity.HasIndex(e => e.Idadd, "RELATIONSHIP_33_FK");

            entity.Property(e => e.Idfac)
                .ValueGeneratedOnAdd()
                .HasColumnName("IDFAC");
            entity.Property(e => e.Gln)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("GLN");
            entity.Property(e => e.Acreagetotal).HasColumnName("ACREAGETOTAL");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Idadd).HasColumnName("IDADD");
            entity.Property(e => e.Iddoc).HasColumnName("IDDOC");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Sector)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SECTOR");
            entity.Property(e => e.Type)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TYPE");
            entity.Property(e => e.Warehousearea).HasColumnName("WAREHOUSEAREA");
            entity.Property(e => e.Wattage).HasColumnName("WATTAGE");

            entity.HasOne(d => d.IdaddNavigation).WithMany(p => p.Factories)
                .HasForeignKey(d => d.Idadd)
                .HasConstraintName("FK_FACTORY_RELATIONS_ADDRESS");

            entity.HasOne(d => d.IddocNavigation).WithMany(p => p.Factories)
                .HasForeignKey(d => d.Iddoc)
                .HasConstraintName("FK_FACTORY_FACTORY_H_DOCUMENT");
        });

        modelBuilder.Entity<Imageinfo>(entity =>
        {
            entity.HasKey(e => e.Idimg).IsClustered(false);

            entity.ToTable("IMAGEINFO");

            entity.Property(e => e.Idimg)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("IDIMG");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Tittle)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TITTLE");
            entity.Property(e => e.Type)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TYPE");
        });

        modelBuilder.Entity<LogActivestamp>(entity =>
        {
            entity.HasKey(e => e.Idla).IsClustered(false);

            entity.ToTable("LOG_ACTIVESTAMP");

            entity.HasIndex(e => e.Idsb, "RELATIONSHIP_40_FK");

            entity.HasIndex(e => e.Idmem, "RELATIONSHIP_41_FK");

            entity.Property(e => e.Idla).HasColumnName("IDLA");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Idmem).HasColumnName("IDMEM");
            entity.Property(e => e.Idsb).HasColumnName("IDSB");
            entity.Property(e => e.Type)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TYPE");

            entity.HasOne(d => d.IdmemNavigation).WithMany(p => p.LogActivestamps)
                .HasForeignKey(d => d.Idmem)
                .HasConstraintName("FK_LOG_ACTI_RELATIONS_MEMBER");

            entity.HasOne(d => d.IdsbNavigation).WithMany(p => p.LogActivestamps)
                .HasForeignKey(d => d.Idsb)
                .HasConstraintName("FK_LOG_ACTI_RELATIONS_STAMP_BA");
        });

        modelBuilder.Entity<LogScan>(entity =>
        {
            entity.HasKey(e => e.Idlc).IsClustered(false);

            entity.ToTable("LOG_SCAN");

            entity.HasIndex(e => e.Idmem, "RELATIONSHIP_30_FK");

            entity.Property(e => e.Idlc).HasColumnName("IDLC");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Describe)
                .HasMaxLength(123)
                .IsUnicode(false)
                .HasColumnName("DESCRIBE");
            entity.Property(e => e.Idmem).HasColumnName("IDMEM");
            entity.Property(e => e.Type)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TYPE");

            entity.HasOne(d => d.IdmemNavigation).WithMany(p => p.LogScans)
                .HasForeignKey(d => d.Idmem)
                .HasConstraintName("FK_LOG_SCAN_RELATIONS_MEMBER");
        });

        modelBuilder.Entity<LogTransaction>(entity =>
        {
            entity.HasKey(e => e.Idlt).IsClustered(false);

            entity.ToTable("LOG_TRANSACTION");

            entity.HasIndex(e => new { e.Factoryfrom, e.Glnfrom }, "FROM_FACTORY_FK");

            entity.HasIndex(e => e.Ssccinput, "INPUT_SSCC_OF_TRANSACTION_FK");

            entity.HasIndex(e => e.Ssccoutput, "OUTPUT_SSCC_OF_TRANSACTION_FK");

            entity.HasIndex(e => new { e.Businessreciver, e.Glnreciver }, "RECIVER_TRANSACTION_FK");

            entity.HasIndex(e => new { e.Businesssender, e.Glnsender }, "SENDER_TRANSACTION_FK");

            entity.HasIndex(e => new { e.Fatoryto, e.Glnto }, "TO_FATORY_FK");

            entity.Property(e => e.Idlt).HasColumnName("IDLT");
            entity.Property(e => e.Businessreciver).HasColumnName("BUSINESSRECIVER");
            entity.Property(e => e.Businesssender).HasColumnName("BUSINESSSENDER");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Deliveryat)
                .HasColumnType("datetime")
                .HasColumnName("DELIVERYAT");
            entity.Property(e => e.Factoryfrom).HasColumnName("FACTORYFROM");
            entity.Property(e => e.Fatoryto).HasColumnName("FATORYTO");
            entity.Property(e => e.Glnfrom)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("GLNFROM");
            entity.Property(e => e.Glnreciver)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("GLNRECIVER");
            entity.Property(e => e.Glnsender)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("GLNSENDER");
            entity.Property(e => e.Glnto)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("GLNTO");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");
            entity.Property(e => e.Ssccinput).HasColumnName("SSCCINPUT");
            entity.Property(e => e.Ssccoutput).HasColumnName("SSCCOUTPUT");
            entity.Property(e => e.Updateat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("UPDATEAT");
            entity.Property(e => e.Updateby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("UPDATEBY");
            entity.Property(e => e.Weigh).HasColumnName("WEIGH");

            entity.HasOne(d => d.SsccinputNavigation).WithMany(p => p.LogTransactionSsccinputNavigations)
                .HasForeignKey(d => d.Ssccinput)
                .HasConstraintName("FK_LOG_TRAN_INPUT_SSC_CODE_TRA");

            entity.HasOne(d => d.SsccoutputNavigation).WithMany(p => p.LogTransactionSsccoutputNavigations)
                .HasForeignKey(d => d.Ssccoutput)
                .HasConstraintName("FK_LOG_TRAN_OUTPUT_SS_CODE_TRA");

            entity.HasOne(d => d.Business).WithMany(p => p.LogTransactionBusinesses)
                .HasForeignKey(d => new { d.Businessreciver, d.Glnreciver })
                .HasConstraintName("FK_LOG_TRAN_RECIVER_T_BUSINESS");

            entity.HasOne(d => d.BusinessNavigation).WithMany(p => p.LogTransactionBusinessNavigations)
                .HasForeignKey(d => new { d.Businesssender, d.Glnsender })
                .HasConstraintName("FK_LOG_TRAN_SENDER_TR_BUSINESS");

            entity.HasOne(d => d.Factory).WithMany(p => p.LogTransactionFactories)
                .HasForeignKey(d => new { d.Factoryfrom, d.Glnfrom })
                .HasConstraintName("FK_LOG_TRAN_FROM_FACT_FACTORY");

            entity.HasOne(d => d.FactoryNavigation).WithMany(p => p.LogTransactionFactoryNavigations)
                .HasForeignKey(d => new { d.Fatoryto, d.Glnto })
                .HasConstraintName("FK_LOG_TRAN_TO_FATORY_FACTORY");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Idmem).IsClustered(false);

            entity.ToTable("MEMBER");

            entity.HasIndex(e => new { e.Hostbusiness, e.Gln }, "MEMBER_OF_FK");

            entity.Property(e => e.Idmem).HasColumnName("IDMEM");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Gln)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("GLN");
            entity.Property(e => e.Hostbusiness).HasColumnName("HOSTBUSINESS");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PHONENUMBER");

            entity.HasOne(d => d.Business).WithMany(p => p.Members)
                .HasForeignKey(d => new { d.Hostbusiness, d.Gln })
                .HasConstraintName("FK_MEMBER_MEMBER_OF_BUSINESS");
        });

        modelBuilder.Entity<Member1>(entity =>
        {
            entity.HasKey(e => new { e.Idmem, e.Idmg }).IsClustered(false);

            entity.ToTable("MEMBERS");

            entity.HasIndex(e => e.Idmem, "MEMBERS2_FK");

            entity.HasIndex(e => e.Idmg, "MEMBERS_FK");

            entity.Property(e => e.Idmem).HasColumnName("IDMEM");
            entity.Property(e => e.Idmg).HasColumnName("IDMG");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");

            entity.HasOne(d => d.IdmemNavigation).WithMany(p => p.Member1s)
                .HasForeignKey(d => d.Idmem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MEMBERS_MEMBERS2_MEMBER");

            entity.HasOne(d => d.IdmgNavigation).WithMany(p => p.Member1s)
                .HasForeignKey(d => d.Idmg)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MEMBERS_MEMBERS_MEMBER_G");
        });

        modelBuilder.Entity<MemberGroup>(entity =>
        {
            entity.HasKey(e => e.Idmg).IsClustered(false);

            entity.ToTable("MEMBER_GROUP");

            entity.Property(e => e.Idmg).HasColumnName("IDMG");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Type)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TYPE");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Idpm).IsClustered(false);

            entity.ToTable("PERMISSION");

            entity.HasIndex(e => e.Idpg, "RELATIONSHIP_45_FK");

            entity.Property(e => e.Idpm).HasColumnName("IDPM");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Describe)
                .HasMaxLength(123)
                .IsUnicode(false)
                .HasColumnName("DESCRIBE");
            entity.Property(e => e.Idpg).HasColumnName("IDPG");

            entity.HasOne(d => d.IdpgNavigation).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.Idpg)
                .HasConstraintName("FK_PERMISSI_RELATIONS_PERMISSI");
        });

        modelBuilder.Entity<PermissionGroup>(entity =>
        {
            entity.HasKey(e => e.Idpg).IsClustered(false);

            entity.ToTable("PERMISSION_GROUP");

            entity.Property(e => e.Idpg).HasColumnName("IDPG");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
        });

        modelBuilder.Entity<ProduceArea>(entity =>
        {
            entity.HasKey(e => e.Idpa).IsClustered(false);

            entity.ToTable("PRODUCE_AREA");

            entity.HasIndex(e => e.Iddoc, "PRODUCEAREA_HAVE_DUCUMENT_FK");

            entity.HasIndex(e => e.Idadd, "RELATIONSHIP_35_FK");

            entity.Property(e => e.Idpa).HasColumnName("IDPA");
            entity.Property(e => e.Acreage).HasColumnName("ACREAGE");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Gln)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("GLN");
            entity.Property(e => e.Idadd).HasColumnName("IDADD");
            entity.Property(e => e.Iddoc).HasColumnName("IDDOC");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Production).HasColumnName("PRODUCTION");
            entity.Property(e => e.Sector)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("SECTOR");

            entity.HasOne(d => d.IdaddNavigation).WithMany(p => p.ProduceAreas)
                .HasForeignKey(d => d.Idadd)
                .HasConstraintName("FK_PRODUCE__RELATIONS_ADDRESS");

            entity.HasOne(d => d.IddocNavigation).WithMany(p => p.ProduceAreas)
                .HasForeignKey(d => d.Iddoc)
                .HasConstraintName("FK_PRODUCE__PRODUCEAR_DOCUMENT");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Idpro).IsClustered(false);

            entity.ToTable("PRODUCT");

            entity.HasIndex(e => e.Idcg, "CATEGORY_HAVE_PRODUCT_FK");

            entity.HasIndex(e => e.Idpa, "MADE_BY_AREA_FK");

            entity.HasIndex(e => new { e.Idfac, e.Gln }, "PRODUCT_IN_FACTORY_FK");

            entity.HasIndex(e => e.Idbat, "PRODUCT_OF_BATCHE_FK");

            entity.HasIndex(e => e.Iddoc, "RELATIONSHIP_46_FK");

            entity.Property(e => e.Idpro).HasColumnName("IDPRO");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Describe)
                .HasMaxLength(123)
                .IsUnicode(false)
                .HasColumnName("DESCRIBE");
            entity.Property(e => e.Gln)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("GLN");
            entity.Property(e => e.Idbat).HasColumnName("IDBAT");
            entity.Property(e => e.Idcg).HasColumnName("IDCG");
            entity.Property(e => e.Iddoc).HasColumnName("IDDOC");
            entity.Property(e => e.Idfac).HasColumnName("IDFAC");
            entity.Property(e => e.Idpa).HasColumnName("IDPA");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Type)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TYPE");

            entity.HasOne(d => d.IdbatNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Idbat)
                .HasConstraintName("FK_PRODUCT_PRODUCT_O_BATCHES");

            entity.HasOne(d => d.IdcgNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Idcg)
                .HasConstraintName("FK_PRODUCT_CATEGORY__CATEGORI");

            entity.HasOne(d => d.IddocNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Iddoc)
                .HasConstraintName("FK_PRODUCT_RELATIONS_DOCUMENT");

            entity.HasOne(d => d.IdpaNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Idpa)
                .HasConstraintName("FK_PRODUCT_MADE_BY_A_PRODUCE_");

            entity.HasOne(d => d.Factory).WithMany(p => p.Products)
                .HasForeignKey(d => new { d.Idfac, d.Gln })
                .HasConstraintName("FK_PRODUCT_PRODUCT_I_FACTORY");

            entity.HasMany(d => d.Businesses).WithMany(p => p.Idpros)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductBusiness",
                    r => r.HasOne<Business>().WithMany()
                        .HasForeignKey("Idbus", "Gln")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PRODUCT__PRODUCT_B_BUSINESS"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("Idpro")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PRODUCT__PRODUCT_B_PRODUCT"),
                    j =>
                    {
                        j.HasKey("Idpro", "Idbus", "Gln").IsClustered(false);
                        j.ToTable("PRODUCT_BUSINESS");
                        j.HasIndex(new[] { "Idpro" }, "PRODUCT_BUSINESS2_FK");
                        j.HasIndex(new[] { "Idbus", "Gln" }, "PRODUCT_BUSINESS_FK");
                        j.IndexerProperty<int>("Idpro").HasColumnName("IDPRO");
                        j.IndexerProperty<int>("Idbus").HasColumnName("IDBUS");
                        j.IndexerProperty<string>("Gln")
                            .HasMaxLength(13)
                            .IsUnicode(false)
                            .HasColumnName("GLN");
                    });
        });

        modelBuilder.Entity<ShareRequest>(entity =>
        {
            entity.HasKey(e => e.Idsr).IsClustered(false);

            entity.ToTable("SHARE_REQUEST");

            entity.HasIndex(e => e.Idmem, "RELATIONSHIP_43_FK");

            entity.Property(e => e.Idsr).HasColumnName("IDSR");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Describe)
                .HasMaxLength(123)
                .IsUnicode(false)
                .HasColumnName("DESCRIBE");
            entity.Property(e => e.Idmem).HasColumnName("IDMEM");
            entity.Property(e => e.Status)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.Tittle)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TITTLE");

            entity.HasOne(d => d.IdmemNavigation).WithMany(p => p.ShareRequests)
                .HasForeignKey(d => d.Idmem)
                .HasConstraintName("FK_SHARE_RE_RELATIONS_MEMBER");
        });

        modelBuilder.Entity<Stamp>(entity =>
        {
            entity.HasKey(e => e.Idsta).IsClustered(false);

            entity.ToTable("STAMP");

            entity.HasIndex(e => e.Idsb, "RELATIONSHIP_36_FK");

            entity.HasIndex(e => e.Idpro, "RELATIONSHIP_37_FK");

            entity.Property(e => e.Idsta).HasColumnName("IDSTA");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Describe)
                .HasMaxLength(123)
                .IsUnicode(false)
                .HasColumnName("DESCRIBE");
            entity.Property(e => e.Idpro).HasColumnName("IDPRO");
            entity.Property(e => e.Idsb).HasColumnName("IDSB");

            entity.HasOne(d => d.IdproNavigation).WithMany(p => p.Stamps)
                .HasForeignKey(d => d.Idpro)
                .HasConstraintName("FK_STAMP_RELATIONS_PRODUCT");

            entity.HasOne(d => d.IdsbNavigation).WithMany(p => p.Stamps)
                .HasForeignKey(d => d.Idsb)
                .HasConstraintName("FK_STAMP_RELATIONS_STAMP_BA");
        });

        modelBuilder.Entity<StampBatch>(entity =>
        {
            entity.HasKey(e => e.Idsb).IsClustered(false);

            entity.ToTable("STAMP_BATCHES");

            entity.HasIndex(e => e.Idso, "RELATIONSHIP_38_FK");

            entity.Property(e => e.Idsb).HasColumnName("IDSB");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Idso).HasColumnName("IDSO");
            entity.Property(e => e.Tittle)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TITTLE");

            entity.HasOne(d => d.IdsoNavigation).WithMany(p => p.StampBatches)
                .HasForeignKey(d => d.Idso)
                .HasConstraintName("FK_STAMP_BA_RELATIONS_STAMP_OR");
        });

        modelBuilder.Entity<StampOrder>(entity =>
        {
            entity.HasKey(e => e.Idso).IsClustered(false);

            entity.ToTable("STAMP_ORDER");

            entity.HasIndex(e => new { e.Idbus, e.Gln }, "RELATIONSHIP_39_FK");

            entity.Property(e => e.Idso).HasColumnName("IDSO");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Fromdateso)
                .HasColumnType("datetime")
                .HasColumnName("FROMDATESO");
            entity.Property(e => e.Gln)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("GLN");
            entity.Property(e => e.Idbus).HasColumnName("IDBUS");
            entity.Property(e => e.Tittleso)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TITTLESO");
            entity.Property(e => e.Todateso)
                .HasColumnType("datetime")
                .HasColumnName("TODATESO");

            entity.HasOne(d => d.Business).WithMany(p => p.StampOrders)
                .HasForeignKey(d => new { d.Idbus, d.Gln })
                .HasConstraintName("FK_STAMP_OR_RELATIONS_BUSINESS");
        });

        modelBuilder.Entity<Transport>(entity =>
        {
            entity.HasKey(e => e.Idtra).IsClustered(false);

            entity.ToTable("TRANSPORT");

            entity.HasIndex(e => new { e.Hostunit, e.Gln }, "BUSINESS_HAVE_TRANSPORT_FK");

            entity.HasIndex(e => e.Vehicleowner, "MEMBER_HOST_TRANSPORT_FK");

            entity.HasIndex(e => e.License, "TRANSPORT_HAVE_CERTIFICATION_FK");

            entity.Property(e => e.Idtra).HasColumnName("IDTRA");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CODE");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Gln)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("GLN");
            entity.Property(e => e.Hostunit).HasColumnName("HOSTUNIT");
            entity.Property(e => e.License).HasColumnName("LICENSE");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PHONENUMBER");
            entity.Property(e => e.Vehicle)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("VEHICLE");
            entity.Property(e => e.Vehicleowner).HasColumnName("VEHICLEOWNER");

            entity.HasOne(d => d.LicenseNavigation).WithMany(p => p.Transports)
                .HasForeignKey(d => d.License)
                .HasConstraintName("FK_TRANSPOR_TRANSPORT_DOCUMENT");

            entity.HasOne(d => d.VehicleownerNavigation).WithMany(p => p.Transports)
                .HasForeignKey(d => d.Vehicleowner)
                .HasConstraintName("FK_TRANSPOR_MEMBER_HO_MEMBER");

            entity.HasOne(d => d.Business).WithMany(p => p.Transports)
                .HasForeignKey(d => new { d.Hostunit, d.Gln })
                .HasConstraintName("FK_TRANSPOR_BUSINESS__BUSINESS");
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => new { e.Idc, e.Idcy, e.Iddis, e.Idwa }).IsClustered(false);

            entity.ToTable("WARD");

            entity.HasIndex(e => new { e.Idc, e.Idcy, e.Iddis }, "RELATIONSHIP_27_FK");

            entity.Property(e => e.Idc).HasColumnName("IDC");
            entity.Property(e => e.Idcy).HasColumnName("IDCY");
            entity.Property(e => e.Iddis).HasColumnName("IDDIS");
            entity.Property(e => e.Idwa)
                .ValueGeneratedOnAdd()
                .HasColumnName("IDWA");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATEAT");
            entity.Property(e => e.Createby)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CREATEBY");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Type)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TYPE");

            entity.HasOne(d => d.District).WithMany(p => p.Wards)
                .HasForeignKey(d => new { d.Idc, d.Idcy, d.Iddis })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WARD_RELATIONS_DISTRICT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
