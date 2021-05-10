using System.ComponentModel.DataAnnotations.Schema;

namespace graduate_work.Models.Database
{
    public class Family
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int FamilyMemberId { get; set; }
        public FamilyMember FamilyMember { get; set; }
    }
}
