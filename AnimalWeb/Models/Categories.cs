using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalWeb.Models
{
    public class Categories
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CategoryPicture { get; set; }
        public virtual List<Animals> Animals {get; set;}
    }

}
