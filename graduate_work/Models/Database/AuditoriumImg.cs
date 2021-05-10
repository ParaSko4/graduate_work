using System.ComponentModel.DataAnnotations.Schema;

namespace graduate_work.Models.Database
{
    public class AuditoriumImg
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ImgURL { get; set; }
        public string Type { get; set; }

        public int AuditoriumId { get; set; }
        public Auditorium Auditorium { get; set; }
    }
}
