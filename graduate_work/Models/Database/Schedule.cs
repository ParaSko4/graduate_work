using System.ComponentModel.DataAnnotations.Schema;

namespace graduate_work.Models.Database
{
    public class Schedule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int LessonDurationId { get; set; }
        public LessonDuration LessonDuration { get; set; }

        public int AuditoriumId { get; set; }
        public Auditorium Auditorium { get; set; }

        public int Day { get; set; }
    }
}
