using System.ComponentModel.DataAnnotations;

namespace AnimalWeb.Models
{
    public class Comments
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string Comment { get; set; }
        public Animals Animal { get; set; }
    }
}

