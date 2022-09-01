using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalWeb.Models
{
    public class Categories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }
        public int ID { get; set; }
        public string CategoryPicture { get; set; }
        public virtual ICollection<Animals> Animals {get; set;}
    }

}
