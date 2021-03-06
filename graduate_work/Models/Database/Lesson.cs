using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace graduate_work.Models.Database
{
    public class Lesson
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Progress> Progresses { get; set; }
        public ICollection<Homework> Homeworks { get; set; }

    }
}
