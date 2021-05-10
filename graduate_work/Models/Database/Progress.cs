using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace graduate_work.Models.Database
{
    public class Progress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int Mark { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }
    }
}
