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
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Login).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.Role).IsRequired();
            })
            .Entity<School>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Location).IsRequired();
                entity.HasOne(d => d.UserAccount).WithOne().OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(d => d.Lessons).WithOne(e => e.School).OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasMany(d => d.LessonsDurations).WithOne(e => e.School).OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasMany(d => d.Auditoriums).WithOne(e => e.School).OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<Lesson>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();

                entity.HasMany(d => d.Schedule).WithOne(e => e.Lesson).OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<LessonDuration>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Duration).IsRequired();
            })
            .Entity<Auditorium>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Number).IsRequired();

                entity.HasMany(d => d.AuditoriumImg).WithOne().OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasMany(d => d.Schedule).WithOne().OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<AuditoriumImg>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ImgURL).IsRequired();
                entity.Property(e => e.Type).IsRequired();

                entity.HasOne(e => e.Auditorium).WithMany().HasForeignKey(p => p.AuditoriumId).OnDelete(DeleteBehavior.Cascade);
            })
            .Entity<PersonalData>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Surname).IsRequired();
                entity.Property(e => e.MiddleName).IsRequired();
                entity.Property(e => e.Birthday).IsRequired();
                entity.Property(e => e.ResidenceAddress).IsRequired();
                entity.Property(e => e.Sex).IsRequired();

                entity.HasMany(d => d.PersonalImgs).WithOne().OnDelete(DeleteBehavior.Cascade).IsRequired();

                entity.HasOne(d => d.UserAccount).WithOne().OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(d => d.School).WithMany().OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<PersonalImg>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ImgURL).IsRequired();
                entity.Property(e => e.Type).IsRequired();

                entity.HasOne(e => e.PersonalData).WithMany().HasForeignKey(p => p.PersonalDataId).OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(d => d.Position).IsRequired();
                entity.HasOne(d => d.PersonalData).WithOne().IsRequired();

                entity.HasMany(d => d.Progress).WithOne().IsRequired();
                entity.HasMany(d => d.Schedule).WithOne().IsRequired();
            })
            .Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(d => d.Number).IsRequired();
                entity.Property(d => d.Letter).IsRequired();
                entity.HasOne(d => d.Teacher).WithOne().IsRequired();
                entity.HasOne(d => d.Auditorium).WithOne();

                entity.HasMany(d => d.ClassImg).WithOne().OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasMany(d => d.Schedule).WithOne().OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<ClassImg>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(d => d.ImgURL).IsRequired();
                entity.Property(d => d.Type).IsRequired();

                entity.HasOne(e => e.Class).WithMany().HasForeignKey(p => p.ClassId).OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(d => d.PersonalData).WithOne().OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasOne(d => d.Class).WithOne().IsRequired();

                entity.HasMany(d => d.Progress).WithOne().OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasMany(d => d.Family).WithOne().OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<FamilyMember>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(d => d.Member).IsRequired();
                entity.Property(d => d.WorkName).IsRequired();
                entity.Property(d => d.WorkPosition).IsRequired();
                entity.HasOne(d => d.PersonalData).WithOne().OnDelete(DeleteBehavior.Cascade).IsRequired();

                entity.HasMany(d => d.Family).WithOne().OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<Family>(entity =>
            {
                entity.HasKey(f => f.Id);

                entity.HasOne(f => f.FamilyMember).WithMany().HasForeignKey(f => f.FamilyMemberId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(f => f.Student).WithMany().HasForeignKey(f => f.StudentId).OnDelete(DeleteBehavior.Cascade);
            })
            .Entity<Progress>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Mark).IsRequired();

                entity.HasOne(p => p.Lesson).WithMany().HasForeignKey(p => p.LessonId).OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasOne(p => p.Student).WithMany().HasForeignKey(p => p.StudentId).OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasOne(p => p.Teacher).WithMany().HasForeignKey(p => p.TeacherId).OnDelete(DeleteBehavior.Cascade).IsRequired();
            })
            .Entity<Schedule>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Day).IsRequired();

                entity.HasOne(s => s.Lesson).WithMany().HasForeignKey(s => s.LessonId).OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasOne(s => s.LessonDuration).WithMany().HasForeignKey(s => s.LessonDurationId).OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasOne(s => s.Teacher).WithMany().HasForeignKey(s => s.TeacherId).OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasOne(s => s.Auditorium).WithMany().HasForeignKey(s => s.AuditoriumId).OnDelete(DeleteBehavior.Cascade).IsRequired();
                entity.HasOne(s => s.Class).WithMany().HasForeignKey(s => s.ClassId).OnDelete(DeleteBehavior.Cascade).IsRequired();
            });
        }
    }
}
