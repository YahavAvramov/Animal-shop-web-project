using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalWeb.Models
{

    public class Animals
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PictureName { get; set; }
        public string Description { get; set; }
        public Categories Category { get; set; }
        public int Price { get; set; }
        public List<Comments>? Comments { get; set; }
    }
}
