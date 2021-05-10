using System.ComponentModel.DataAnnotations.Schema;

namespace graduate_work.Models.Database
{
    public class ClassImg
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ImgURL { get; set; }
        public string Type { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
