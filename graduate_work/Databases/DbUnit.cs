using graduate_work.Databases.MySQL;
using graduate_work.Interfaces;
using graduate_work.Interfaces.IRepository;

namespace graduate_work.Databases
{
    public class DbUnit : IUnitOfWork
    {
        private readonly MySQLContext db;

        public DbUnit(MySQLContext db, IAuditoriumRepository auditoriumRepository, IAuditoriumImgRepository auditoriumImgRepository,
            IClassRepository classRepository, IClassImgRepository classImgRepository, IFamilyRepository familyRepository,
            IFamilyMemberRepository familyMemberRepository, ILessonRepository lessonRepository, ILessonDurationRepository lessonDurationRepository,
            IPersonalDataRepository personalDataRepository, IPersonalImgRepository personalImgRepository, IProgressRepository progressRepository,
            IScheduleRepository scheduleRepository, ISchoolRepository schoolRepository, IStudentRepository studentRepository,
            ITeacherRepository teacherRepository, IUserAccountRepository userAccountRepository, IHomeworkRepository homeworkRepository)
        {
            this.db = db;

            AuditoriumRepository = auditoriumRepository;
            AuditoriumImgRepository = auditoriumImgRepository;
            ClassRepository = classRepository;
            ClassImgRepository = classImgRepository;
            HomeworkRepository = homeworkRepository;
            FamilyRepository = familyRepository;
            FamilyMemberRepository = familyMemberRepository;
            LessonDurationRepository = lessonDurationRepository;
            LessonRepository = lessonRepository;
            PersonalDataRepository = personalDataRepository;
            PersonalImgRepository = personalImgRepository;
            ProgressRepository = progressRepository;
            ScheduleRepository = scheduleRepository;
            SchoolRepository = schoolRepository;
            StudentRepository = studentRepository;
            TeacherRepository = teacherRepository;
            UserAccountRepository = userAccountRepository;
        }

        public IAuditoriumRepository AuditoriumRepository { get; }

        public IAuditoriumImgRepository AuditoriumImgRepository { get; }

        public IClassRepository ClassRepository { get; }

        public IClassImgRepository ClassImgRepository { get; }

        public IHomeworkRepository HomeworkRepository { get; }

        public IFamilyRepository FamilyRepository { get; }

        public IFamilyMemberRepository FamilyMemberRepository { get; }

        public ILessonDurationRepository LessonDurationRepository { get; }

        public ILessonRepository LessonRepository { get; }

        public IPersonalDataRepository PersonalDataRepository { get; }

        public IPersonalImgRepository PersonalImgRepository { get; }

        public IProgressRepository ProgressRepository { get; }

        public IScheduleRepository ScheduleRepository { get; }

        public ISchoolRepository SchoolRepository { get; }

        public IStudentRepository StudentRepository { get; }

        public ITeacherRepository TeacherRepository { get; }

        public IUserAccountRepository UserAccountRepository { get; }

        public int Complete()
        {
            return db.SaveChanges();
        }
    }
}
