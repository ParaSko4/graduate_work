using System.ComponentModel.DataAnnotations.Schema;

namespace graduate_work.Models.Database
{
    public class PersonalImg
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ImgURL { get; set; }
        public string Type { get; set; }

        public int PersonalDataId { get; set; }
        public PersonalData PersonalData { get; set; }
    }
}