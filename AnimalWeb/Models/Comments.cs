using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalWeb.Models
{
    public class Comments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(50)]
        public string Comment { get; set; }
        public Animals Animal { get; set; }
        public int AnimalID { get; set; }
        public string? CommentWriterName { get; set; }
        public DateTime? CommentDate { get; set; }
    }
}

