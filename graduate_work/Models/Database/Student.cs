using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace graduate_work.Models.Database
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string StudentCode { get; set; }

        public int PersonalDataId { get; set; }
        public PersonalData PersonalData { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public ICollection<Progress> Progresses { get; set; }
        public ICollection<Family> Family { get; set; }
    }
}
