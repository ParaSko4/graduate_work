
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace graduate_work.Models.Database
{
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Position { get; set; }
        public string? PersonalCode { get; set; }

        public int PersonalDataId { get; set; }
        public PersonalData PersonalData { get; set; }

        public ICollection<Progress> Progress { get; set; }
        public ICollection<Schedule> Schedule { get; set; }
    }
}
