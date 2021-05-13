using graduate_work.Interfaces.IRepository;

namespace graduate_work.Interfaces
{
    public interface IUnitOfWork
    {
        IAuditoriumRepository AuditoriumRepository { get; }
        IAuditoriumImgRepository AuditoriumImgRepository { get; }
        IClassRepository ClassRepository { get; }
        IClassImgRepository ClassImgRepository { get; }
        IHomeworkRepository HomeworkRepository { get; }
        IFamilyRepository FamilyRepository { get; }
        IFamilyMemberRepository FamilyMemberRepository { get; }
        ILessonRepository LessonRepository { get; }
        ILessonDurationRepository LessonDurationRepository { get; }
        IPersonalDataRepository PersonalDataRepository { get; }
        IPersonalImgRepository PersonalImgRepository { get; }
        IProgressRepository ProgressRepository { get; }
        IScheduleRepository ScheduleRepository { get; }
        ISchoolRepository SchoolRepository { get; }
        IStudentRepository StudentRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        IUserAccountRepository UserAccountRepository { get; }

        int Complete();
    }
}
