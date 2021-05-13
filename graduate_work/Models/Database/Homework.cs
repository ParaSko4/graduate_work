using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace graduate_work.Models.Database
{
    public class Homework
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Task { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }
        public DateTime CompletionDate  { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
