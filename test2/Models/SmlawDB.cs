namespace test2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SmlawDB : DbContext
    {
        public SmlawDB()
            : base("name=SmlawDB")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AboutUsTB> AboutUsTBs { get; set; }
        public virtual DbSet<AreasOfActivity> AreasOfActivities { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<AttorneyTB> AttorneyTBs { get; set; }
        public virtual DbSet<BasicInfo> BasicInfoes { get; set; }
        public virtual DbSet<ContactTB> ContactTBs { get; set; }
        public virtual DbSet<HowWeAreTB> HowWeAreTBs { get; set; }
        public virtual DbSet<LabelTB> LabelTBs { get; set; }
        public virtual DbSet<LanguageTB> LanguageTBs { get; set; }
        public virtual DbSet<LoginImageTB> LoginImageTBs { get; set; }
        public virtual DbSet<NewsTB> NewsTBs { get; set; }
        public virtual DbSet<RegisterImageTB> RegisterImageTBs { get; set; }
        public virtual DbSet<ResetImageTB> ResetImageTBs { get; set; }
        public virtual DbSet<ServicesTB> ServicesTBs { get; set; }
        public virtual DbSet<SliderTopTB> SliderTopTBs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasMany(e => e.LabelTBs)
                .WithMany(e => e.Articles)
                .Map(m => m.ToTable("ArticleLable").MapLeftKey("ArticleId").MapRightKey("LabelId"));

            modelBuilder.Entity<LanguageTB>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.LanguageTB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LanguageTB>()
                .HasMany(e => e.AttorneyTBs)
                .WithRequired(e => e.LanguageTB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LanguageTB>()
                .HasMany(e => e.HowWeAreTBs)
                .WithRequired(e => e.LanguageTB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LanguageTB>()
                .HasMany(e => e.SliderTopTBs)
                .WithRequired(e => e.LanguageTB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegisterImageTB>()
                .Property(e => e.RegisterPhoto)
                .IsUnicode(false);

            modelBuilder.Entity<ServicesTB>()
                .Property(e => e.ServicesPhoto)
                .IsUnicode(false);

            modelBuilder.Entity<SliderTopTB>()
                .Property(e => e.SliderContent2)
                .IsFixedLength();
        }
    }
}
