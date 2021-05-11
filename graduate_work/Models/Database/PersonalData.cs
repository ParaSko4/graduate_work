using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace graduate_work.Models.Database
{
    public class PersonalData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }
        public string ResidenceAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }

        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; }

        public ICollection<PersonalImg> PersonalImgs { get; set; }
    }
}
