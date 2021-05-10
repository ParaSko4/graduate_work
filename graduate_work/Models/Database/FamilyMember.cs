using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace graduate_work.Models.Database
{
    public class FamilyMember
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Email { get; set; }
        public string Member { get; set; }
        public string WorkName { get; set; }
        public string WorkPosition { get; set; }

        public int PersonalDataId { get; set; }
        public PersonalData PersonalData { get; set; }

        public ICollection<Family> Family { get; set; }
    }
}
