using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace graduate_work.Models.Database
{
    public class School
    {
        public School() { }

        public School(string Name, string Location, string Email, string Number, int UserAccountId)
        {
            this.Name = Name;
            this.Location = Location;
            this.Email = Email;
            this.Number = Number;
            this.UserAccountId = UserAccountId;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }

        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }

        public ICollection<Auditorium> Auditoriums { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<LessonDuration> LessonsDurations { get; set; }
        public ICollection<PersonalData> PersonalDatas { get; set; }
    }
}