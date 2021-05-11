using graduate_work.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace graduate_work.Databases.MySQL
{
    public class MySQLContext : DbContext
    {
        public DbSet<Auditorium> Auditoriums { get; set; }
        public DbSet<AuditoriumImg> AuditoriumImgs { get; set; }
        public DbSet<ClassImg> ClassImgs { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<LessonDuration> LessonDurations { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<PersonalData> PersonalDatas { get; set; }
        public DbSet<PersonalImg> PersonalImgs { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        public MySQLContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=dba_school_crm;user=root;password=1244");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(ua => ua.Id);
                entity.Property(ua => ua.Login).IsRequired();
                entity.Property(ua => ua.Password).IsRequired();
                entity.Property(ua => ua.Role).IsRequired();
            })
            .Entity<School>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Name).IsRequired();
                entity.Property(s => s.Location).IsRequired();

                entity.HasOne(s => s.UserAccount).WithOne().OnDelete(DeleteBehavior.Cascade).IsRequired();

                entity.HasMany(s => s.Lessons).WithOne(l => l.School).OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasMany(s => s.LessonsDurations).WithOne(ld => ld.School).OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasMany(s => s.Auditoriums).WithOne(a => a.School).OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasMany(s => s.PersonalDatas).WithOne(pd => pd.School).OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<Lesson>(entity =>
            {
                entity.HasKey(l => l.Id);
                entity.Property(l => l.Name).IsRequired();

                entity.HasMany(l => l.Schedules).WithOne(s => s.Lesson).OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasMany(l => l.Progresses).WithOne(p => p.Lesson).OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<LessonDuration>(entity =>
            {
                entity.HasKey(ld => ld.Id);
                entity.Property(ld => ld.Duration).IsRequired();

                entity.HasMany(ld => ld.Schedules).WithOne(s => s.LessonDuration).OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<Auditorium>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name).IsRequired();
                entity.Property(a => a.Number).IsRequired();

                entity.HasMany(a => a.AuditoriumImg).WithOne(ai => ai.Auditorium).OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasMany(a => a.Schedules).WithOne(s => s.Auditorium).OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<AuditoriumImg>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ImgURL).IsRequired();
                entity.Property(e => e.Type).IsRequired();
            })
            .Entity<PersonalData>(entity =>
            {
                entity.HasKey(pd => pd.Id);
                entity.Property(pd => pd.Name).IsRequired();
                entity.Property(pd => pd.Surname).IsRequired();
                entity.Property(pd => pd.MiddleName).IsRequired();
                entity.Property(pd => pd.Birthday).IsRequired();
                entity.Property(pd => pd.ResidenceAddress).IsRequired();
                entity.Property(pd => pd.Sex).IsRequired();

                entity.HasOne(pd => pd.UserAccount).WithOne().OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(pd => pd.PersonalImgs).WithOne(pi => pi.PersonalData).OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<PersonalImg>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ImgURL).IsRequired();
                entity.Property(e => e.Type).IsRequired();
            })
            .Entity<Teacher>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Position).IsRequired();

                entity.HasOne(t => t.PersonalData).WithOne().OnDelete(DeleteBehavior.Cascade).IsRequired();

                entity.HasMany(t => t.Progresses).WithOne(p => p.Teacher).OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasMany(t => t.Schedules).WithOne(s => s.Teacher).OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<Class>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Number).IsRequired();
                entity.Property(c => c.Letter).IsRequired();

                entity.HasOne(c => c.Teacher).WithOne().OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasOne(c => c.Auditorium).WithOne();

                entity.HasMany(c => c.ClassImgs).WithOne(ci => ci.Class).OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasMany(c => c.Schedules).WithOne(s => s.Class).OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasMany(c => c.Students).WithOne(s => s.Class).OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<ClassImg>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(d => d.ImgURL).IsRequired();
                entity.Property(d => d.Type).IsRequired();
            })
            .Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(d => d.PersonalData).WithOne().OnDelete(DeleteBehavior.Cascade).IsRequired();

                entity.HasMany(d => d.Progresses).WithOne(p => p.Student).OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasMany(d => d.Family).WithOne(f => f.Student).OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<FamilyMember>(entity =>
            {
                entity.HasKey(fm => fm.Id);
                entity.Property(fm => fm.Member).IsRequired();
                entity.Property(fm => fm.WorkName).IsRequired();
                entity.Property(fm => fm.WorkPosition).IsRequired();

                entity.HasOne(fm => fm.PersonalData).WithOne().OnDelete(DeleteBehavior.Cascade).IsRequired();

                entity.HasMany(fm => fm.Family).WithOne(f => f.FamilyMember).OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<Family>(entity =>
            {
                entity.HasKey(f => f.Id);
            })
            .Entity<Progress>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Mark).IsRequired();
            })
            .Entity<Schedule>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Day).IsRequired();
            });
        }
    }
}
